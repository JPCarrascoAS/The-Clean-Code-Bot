import argparse
from src.code_analyzer import CodeAnalyzer
from src.groq_service import GroqService

def main():
    groq_service = GroqService()
    code_analyzer = CodeAnalyzer(groq_service)

    parser = argparse.ArgumentParser(
        description="A CLI Code Analyzer Tool",
        epilog="Example: code_analyzer analyze -i ./examples/dirty_code.py -o ./examples/clean_code.py"
    )

    parser.add_argument("-i", "--input", type=str, required=True, help="Input code file")
    parser.add_argument("-o", "--output", type=str, required=True, help="Output code file")

    args = parser.parse_args()

    try:
        output = code_analyzer.analyze(args.input, args.output)
        print(output)
    except Exception as e:
        print(f"Unexpected error: {e}")
        exit(1)

if __name__ == "__main__":
    main()
