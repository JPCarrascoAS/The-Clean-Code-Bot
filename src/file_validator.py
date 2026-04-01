import os

class FileValidator:
    def __init__(self):
        self.errors = []

    def is_valid(self, file_path: str) -> bool:
        if not file_path or file_path.strip() == "":
            self.errors.append("File path not provided")
            return False

        if not os.path.exists(file_path):
            self.errors.append(f"File {file_path} not found")
            return False

        if not os.path.isfile(file_path):
            self.errors.append(f"File {file_path} is not a file")
            return False

        return True

    def get_errors(self) -> list[str]:
        return self.errors
