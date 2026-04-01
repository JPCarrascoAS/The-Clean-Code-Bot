# "The Clean Code Bot" (Automated Refactorer)

## Setup
The application is dockerized (for practice purposes) so please run:
```
docker build -t clean-code-bot .
```

Now you have two approaches, you can run the code using docker commands (too much effort) or use my wrapper script written in bash. Here is how to run this using my wrapper script:

```
sh code-analizer.sh -i {input_file} -o {output_file}
```

## Project goal

Create a CLI (Command Line Interface) tool that accepts a "dirty" or undocumented code file and returns an optimized version that follows **SOLID principles** and includes comprehensive technical documentation (such as Docstrings or JSDoc).

## Step-by-Step Process:

1. **Environment Setup:** Set up a local development environment using **Python**.
2. **Prompt Engineering:** Implement a **Prompt Template** system using the **Chain of Thought (CoT)** technique. This ensures the AI first performs a logical analysis of the code before proposing specific improvements.
3. **Security Integration:** Implement input validation and sanitization to prevent **Prompt Injection** attacks (e.g., ensuring the user cannot inject malicious commands through the input code).

## Resources:

* **LLM Access:** OpenAI API (Pay-as-you-go, requires ~$5 USD credit) or **Groq Cloud** (Free Tier available, high-speed inference).
* **Language:** Python.
* **Libraries:** `click` or `argparse` for the CLI structure.

## Deliverables:

* A **GitHub repository** containing the source script.
* A `requirements.txt` file for easy environment replication.
* An `examples/` folder showcasing "before and after" samples of the processed code.