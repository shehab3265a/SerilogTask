# SerilogTask

ASP.NET Core Web API (.NET 8) demonstrating logging with Serilog.

## Features
- Serilog configured from `appsettings.json`
- Console and rolling File sinks (daily, 7 files retained)
- Structured logging with `ILogger<T>`
- Exception logging with stack trace
- HTTP request logging via `UseSerilogRequestLogging`

## Run
dotnet run

## Test
GET /api/products/5   -> Information
GET /api/products/0   -> Warning
GET /api/products/99  -> Error + stack trace

Logs are written to the `logs/` folder (ignored by Git).
