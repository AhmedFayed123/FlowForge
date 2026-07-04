# FlowForge

Smart Automation & Workflow Platform built with .NET 9, Clean Architecture, and CQRS.

## Overview
FlowForge lets users build automated workflows (similar to n8n/Zapier) that trigger on events (Webhooks, Schedules) and execute a chain of actions automatically.

## Tech Stack
- ASP.NET Core 9
- PostgreSQL + EF Core
- MediatR (CQRS)
- JWT Authentication
- Docker

## Status
🚧 Work in progress — MVP under active development.

## Getting Started
1. `docker compose up -d`
2. `Update-Database` (EF Core migrations)
3. Run `FlowForge.API`