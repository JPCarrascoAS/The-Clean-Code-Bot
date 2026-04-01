import os
from groq import Groq
from dotenv import load_dotenv

class GroqService:
    def __init__(self, skill: str = "code_reviewer"):
        load_dotenv()
        self.client = Groq(api_key=os.getenv("GROQ_API_KEY"))
        skill_path = os.path.join(os.path.dirname(__file__), "skills", f"{skill}.txt")
        self.system_prompt = open(skill_path, "r").read()

    def chat(self, message: str) -> str:
        chat_completion = self.client.chat.completions.create(
            messages=[
                {
                    "role": "system",
                    "content": self.system_prompt,
                },
                {
                    "role": "user",
                    "content": message,
                }
            ],
            model="llama-3.3-70b-versatile",
            temperature=0.3,
            seed=42,
        )

        return chat_completion.choices[0].message.content
