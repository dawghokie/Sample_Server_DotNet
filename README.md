# Overview
.net Backend Server that exposes a REST API and queries data from a PostgreSQL table
- Swagger API Information available @ - `https://localhost:7004/swagger/index.html`

# Endpoints 
- `/customers` : get all customers stored in the SQL Database
- `/orders` : get all orders customers have placed

# Quick Points
- Application Start Up code located in `Program.cs`
    - CORS policies setup here
    - Registering of Services for dependency injection is initiated here
- This server runs locally at `https://localhost:7004/`

# Design Decisions
- [Dapper](https://www.nuget.org/packages/Dapper) is being used for
object-relational mapping (ORM). It lets us execute raw sql, easily map
sql output to objects, and reduce boiler-plate code. The Entity Framework is
another good choice for an ORM because it can be easier to use due to its
higher level of abstraction (you don't write raw sql).
- [FakeItEasy](https://www.nuget.org/packages/FakeItEasy/8.0.0-alpha.1.10) is being used for Mocking in Unit Testing
- [FluentAssertions](https://www.nuget.org/packages/FluentAssertions/) is being used
for Asserting Equality


# Moving Forward
- The same Model classes are used in the DAL and BL for simplicity. Moving forward
the DAL and BL should have their own Model class so only the required data is returned
- Leverage tool to version control manage Database Schemas. [Liquibase](https://www.liquibase.com/)
would be a nice option
- Continue building out testing suite

