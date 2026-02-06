#!/usr/bin/env bash
set -euo pipefail

TARGET_DIR="${1:-/workspace/SIteEglise}"
REPO_NAME="${2:-SIteEglise}"

SRC_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"

rm -rf "$TARGET_DIR"
mkdir -p "$TARGET_DIR"

cp "$SRC_DIR/docker-compose.yml" "$TARGET_DIR/"
cp "$SRC_DIR/.env.example" "$TARGET_DIR/"
cp "$SRC_DIR/.gitignore" "$TARGET_DIR/"
cp "$SRC_DIR/README.md" "$TARGET_DIR/"

cd "$TARGET_DIR"

if [ ! -d .git ]; then
  git init
fi

git add .
if ! git diff --cached --quiet; then
  git commit -m "feat: initialize ${REPO_NAME} wordpress starter"
fi

echo "Standalone repository ready at: $TARGET_DIR"
echo "Next: create remote on GitHub then run:"
echo "  cd $TARGET_DIR"
echo "  git branch -M main"
echo "  git remote add origin git@github.com:<TON_USER>/${REPO_NAME}.git"
echo "  git push -u origin main"
