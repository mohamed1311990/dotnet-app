# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ASP.NET Core 10.0 minimal API web application ("Helloweb") with CI/CD via Jenkins and Docker, deployed to Kubernetes (Minikube).

## Build & Run Commands

```bash
# Build
dotnet build

# Run locally (http://localhost:5280)
dotnet run --project Helloweb

# Publish release build
dotnet publish Helloweb -c Release -o out

# Docker build & run
docker build -t helloweb -f Helloweb/dockerfile Helloweb/
docker run -p 8080:8080 helloweb
```

## Architecture

- **Solution**: `dotnet.sln` contains a single project `Helloweb/Helloweb.csproj`
- **Entry point**: `Helloweb/Program.cs` — minimal API with a single GET `/` endpoint
- **Target framework**: .NET 10.0 with nullable references and implicit usings enabled

## CI/CD

- **Jenkinsfile**: Multi-stage pipeline (checkout → Docker build → push to DockerHub → deploy to Minikube). Pushes and deploys only on `dev`, `test`, and `prod` branches. Images are tagged with `{branch}-{short-sha}`.
- **Docker**: Multi-stage Dockerfile in `Helloweb/dockerfile` — SDK build stage, then ASP.NET runtime stage. Container listens on port 8080.
- **K8s deployment**: Uses `kubectl` with per-branch namespaces. Manifests expected in `k8s/` directory with `__IMAGE__` placeholder in `deployment.yaml`.

## Branch Strategy

- `main` is the base branch for PRs
- `dev`, `test`, `prod` are deployment branches that trigger CI/CD pipeline stages
