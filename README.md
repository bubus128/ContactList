[![LinkedIn][linkedin-badge]][linkedin-url]

# ContactList
ContactList is an ASP.NET 10 MVC web application structured with a 3-tier architecture. It provides basic CRUD operations for managing contacts, using Entity Framework and PostgreSQL as the persistence layer. Automapper is used to map between domain/data models and view models.

## Launch instructions
1. Clone
2. Fill .env with your values (or use default)
3. Run docker-compose up in src folder (or use run.ps1)
4. Applay migrations (dotnet ef database update --project ContactList.Data --startup-project ContactList.Web)
5. If you want to fill databse with data you can use insert scripts from src\DbScripts
6. Go to http://localhost:8080/

## Tech stack
| Layer                     | Technology / Components             |
| ------------------------- | ----------------------------------- |
| Framework                 | .NET 10                             |
| Web / Presentation        | ASP.NET MVC                         |
| Business Logic / Service  | Custom service layer                |
| Data Access               | Entity Framework Core, PostgreSQL   |
| Mapping                   | AutoMapper                          |
| Infrastructure / Database | PostgreSQL (containerizable)        |
| Deployment / DevOps       | Docker / Docker Compose (suggested) |

## Architecture
3-Tier Architecture
1. Presentation Layer: MVC Controllers, Views. Handles HTTP requests, routing, user interaction.
2. Business/Service Layer: Contains business logic or services (validation, orchestration), mediates between controllers and data layer.
3. Data Access Layer: Entity Framework DbContext, entity classes, migrations, etc.

[linkedin-badge]: https://img.shields.io/badge/LinkedIn-Świsłocki-blue?logo=linkedin
[linkedin-url]: https://www.linkedin.com/in/jakub-swislocki/
