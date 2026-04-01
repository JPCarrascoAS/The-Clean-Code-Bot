import os
from src.file_validator import FileValidator

class CodeAnalyzer:
    """
    Analyzes the provided code and saves the improved version to the specified output path.
    """

    def __init__(self, llm_service):
        """
        Initializes the CodeAnalyzer with the provided LLM service.

        Args:
            llm_service: The LLM service used for code improvement.
        """
        self.file_validator = FileValidator()
        self.llm_service = llm_service

    def analyze(self, input_file: str, output_path: str) -> str:
        """
        Analyzes the provided code and saves the improved version to the specified output path.

        Args:
            input_file (str): The path to the input file.
            output_path (str): The path where the improved code will be saved.

        Returns:
            str: A message indicating that the analyzed code has been saved to the output path.

        Raises:
            ValueError: If the input file is invalid.
        """
        if not self.file_validator.is_valid(input_file):
            raise ValueError(f"Invalid input file: {self.file_validator.get_errors()}")

        try:
            with open(input_file, "r") as file:
                input_code = file.read()
        except OSError as e:
            raise OSError(f"Failed to read input file: {e}")

        improved_code = self.llm_service.chat(input_code)

        try:
            with open(output_path, "w") as file:
                file.write(improved_code)
        except OSError as e:
            raise OSError(f"Failed to write to output file: {e}")

        return f'Analyzed code saved to {output_path}'