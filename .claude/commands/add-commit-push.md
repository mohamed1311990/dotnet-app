Follow these steps exactly:

1. Run `git status` to see all changed and untracked files
2. Run `git diff` to understand what actually changed
3. Run `git add .` to stage all new and modified files
4. Generate a commit message based on the actual changes:
   - Use conventional commit format: type(scope): description
   - Types: feat, fix, chore, refactor, docs, test
   - Keep the description concise and accurate to the diff
5. Run `git commit -m "your generated message"`
6. Run `git branch --show-current` to confirm the current branch
7. Run `git push origin <current-branch>`

Do not ask for confirmation, execute all steps sequentially.