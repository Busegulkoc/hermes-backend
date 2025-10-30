## Hermes Backend (Sample .NET Web API)

This repository contains a small, self-contained ASP.NET Core Web API built with .NET 7 and Entity Framework Core. It is meant to serve as a straightforward example of general code design and structure.

### Project Purpose
 Hermes is a compact backend demonstrating how to structure a travel-agency style domain. It models core resources often seen in travel operations—such as tours, hotels, travelers, transportation vehicles/workers, cities/countries, admins/managers, and comments—and exposes conventional CRUD APIs to manage them. The focus is on clean layering (controllers → services → data), DTO mapping, and EF Core usage rather than on full production features.

 The name “Hermes” references the Greek mythological figure associated with travel and journeys, echoing the domain theme.
 
### Highlights
- **Purpose**: Demonstrate clean, readable code structure and common backend patterns (controllers → services → data access) using DTOs and AutoMapper.
- **Tech Stack**: .NET 7, ASP.NET Core Web API, Entity Framework Core, AutoMapper.
- **Domains Covered**: Admin, Manager, Traveler, Tour, Hotel, City/Country, Transportation Vehicles, Transportation Workers, Comment.

### Project Structure
```
Controllers/                // API endpoints (REST controllers)
Services/                   // Business logic and interfaces
  <Feature>Service/
Dtos/                       // DTOs for requests/responses
Models/                     // EF Core entity models
Data/                       // DbContext (EF Core)
Migrations/                 // EF Core migrations
AutoMapperProfile.cs        // Mapping between Models and DTOs
Program.cs                  // App bootstrap & dependency injection
```

### Architecture Overview
- **Controllers** expose REST endpoints and depend on service interfaces.
- **Services** encapsulate business logic and interact with the `DataContext` through EF Core.
- **DTOs** define boundary contracts; **AutoMapper** handles model ↔ DTO mapping.
- **Models** are persisted via EF Core; **Migrations** track schema changes.

### Getting Started
#### Prerequisites
- .NET SDK 7.x (`dotnet --version`)
- A SQL Server instance (LocalDB or full SQL Server). Alternatively, update the connection string for another provider.

#### Configuration
1. Copy or update `appsettings.Development.json` (or `appsettings.json`) connection string. Example key:
   - `ConnectionStrings:DefaultConnection`
2. Ensure the database exists or let EF create it via migrations.

#### Restore, Build, and Run
```bash
dotnet restore
dotnet build
dotnet run
```
The API will start on the ports configured in `launchSettings.json` (commonly `http://localhost:5000` or `https://localhost:7000`).

### Database and Migrations
This project uses Entity Framework Core Code-First Migrations.
```bash
# Add a new migration
dotnet ef migrations add <MigrationName>

# Apply migrations to the database
dotnet ef database update
```
If `dotnet ef` is not available, install the tools:
```bash
dotnet tool install --global dotnet-ef
```

 ### Database
 - **Provider**: SQL Server by default (configurable). Update the connection string under `ConnectionStrings:DefaultConnection` in `appsettings.Development.json` or `appsettings.json`.
 - **Schema**: Tables map 1:1 with entities under `Models/` (e.g., `Admin`, `Manager`, `Traveler`, `Tour`, `Hotel`, `CityCountry`, `TransportationVehicle`, `TransportationWorkers`, `Comment`).
 - **Creation/Updates**: Use EF Core migrations (see section above) to create and evolve the database.
 - **Seeding**: No seed data is included by default.
 - **Alternative providers**: You can switch to another EF Core provider (e.g., SQLite or PostgreSQL) by updating the package reference and the `Use<Provider>()` call in the application startup configuration.

### Example Endpoints
The controllers follow a conventional CRUD style. Examples (routes may vary slightly by controller):
- `GET /api/Hotel` – list hotels
- `GET /api/Hotel/{id}` – get one hotel
- `POST /api/Hotel` – create hotel
- `PUT /api/Hotel/{id}` – update hotel
- `DELETE /api/Hotel/{id}` – delete hotel

Similar endpoints exist for other domains like `Tour`, `Traveler`, `Comment`, `Admin`, `Manager`, `CityCountry`, `TransportationVehicle`, and `TransportationWorkers`.

### Sample Request Body
```json
{
  "name": "Sample Hotel",
  "cityId": 1,
  "countryId": 1,
  "address": "123 Example St",
  "stars": 5
}
```

### Notes
- This codebase is a compact, educational example to showcase general backend design patterns and overall structure.
- For brevity, cross-cutting concerns (global error handling, auth, logging, validation pipelines, etc.) are minimal.

### How This Project Relates to the Job Posting
I am sharing this repository as a concise demonstration of my approach to structuring .NET Core backend projects (controllers/services/DTOs/EF Core). It reflects clean code practices, separation of concerns, and conventional Web API design—aligned with the skills requested (C#, .NET Core, OOP, EF Core, SQL, API development).



