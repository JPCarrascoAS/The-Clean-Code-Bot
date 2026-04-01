#!/bin/bash
SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

docker run --rm \
  -v "$(pwd):/workspace" \
  --env-file "$SCRIPT_DIR/.env" \
  clean-code-bot "$@"