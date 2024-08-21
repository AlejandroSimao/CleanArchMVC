# Clean Architecture

### Solution Structure

The final solution was divided into five main projects, each with well-defined responsibilities:
1. Domain: Defines the application's entities and business rules.
2. Application: Contains the application logic and use cases.
3. Infrastructure: Responsible for implementing technical details, such as data persistence and external services.
4. IoC (Inversion of Control): Dependency injection settings.
5. Presentation: The presentation layer, implemented in ASP .NET Core MVC, where the user interface and presentation logic are managed.

### Main Concepts Learned
* Clean Architecture: We learned to organize the code so that each layer of the application is independent, facilitating maintenance and scalability.
* Domain Driven Design (DDD): The use of DDD to structure code around domain concepts was explored, increasing project clarity and cohesion.
* SOLID Principles and Design Patterns: We implement SOLID principles and patterns like Repository and CQRS, which help keep code modular and testable.
* Entity Framework Core (EF Core): Configuration and use of EF Core for database management, including the use of Migrations.
* Dependency Injection: Practical application of inversion of control to decouple dependencies between application modules.

### Future Steps
* Refinement and Expansion: Continue refining the application, implementing new features while maintaining adherence to Clean Architecture principles.
* Automated Tests: Implement automated tests to ensure code robustness and facilitate regression detection.
* Performance Improvements: Analyze and optimize critical points of the application, especially in the infrastructure and data access layer.
* Exploration of New Technologies: Keep up to date with new versions and improvements of the .NET platform and incorporate them into the application as necessary.

