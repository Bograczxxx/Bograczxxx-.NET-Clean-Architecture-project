# Clean Architecture Sample

This repository contains a sample .NET solution following a simplified Clean Architecture structure. It includes three presentation layers:

- **REST API** (`src/Presentation/API`) with CRUD endpoints for `Author`, `Book` and `Review`. It uses EF Core InMemory, JWT authentication and a simple middleware checking for `X-Requested-With` header.
- **gRPC Service** (`src/Presentation/GrpcService`) exposing a simple `Greeter` service.
- **Razor Pages Admin** (`src/Presentation/Admin`) providing a minimal admin panel and login page.

The domain, application and infrastructure projects are located under `src/` and basic unit tests reside in `tests/`.

Run `curl_test.sh` to execute a few example API calls.
