# QuotationMinderApi

QuotationMinderApi is a RESTful API built with C# 8, utilizing ASP.NET Core, Entity Framework Core, and the Repository Pattern. This API is designed to manage quotations, authors, and categories efficiently.

## Project Structure

The project is organized into several key directories:

- **Controllers**: Contains the API controllers that handle HTTP requests.
- **Data**: Contains the database context, migrations, and repository interfaces and implementations.
- **Models**: Contains the data models for Authors, Categories, and Quotations.
- **Properties**: Contains project properties, including launch settings.
- **Configuration Files**: Includes `appsettings.json` for application settings and `Program.cs` and `Startup.cs` for application startup configuration.

## Features

- **CRUD Operations**: The API supports Create, Read, Update, and Delete operations for quotations, authors, and categories.
- **Swagger Integration**: The API is documented using Swagger, providing an interactive interface for testing endpoints.
- **Entity Framework Core**: Utilizes EF Core for database interactions, ensuring a robust data access layer.

## Setup Instructions

1. **Clone the Repository**: 
   ```
   git clone <repository-url>
   cd QuotationMinderApi
   ```

2. **Install Dependencies**: 
   Ensure you have the .NET SDK installed. Run the following command to restore the necessary packages:
   ```
   dotnet restore
   ```

3. **Database Migration**: 
   Apply the migrations to set up the database:
   ```
   dotnet ef database update
   ```

4. **Run the Application**: 
   Start the API using:
   ```
   dotnet run
   ```

5. **Access Swagger UI**: 
   Open your browser and navigate to `http://localhost:5000/swagger` to view the API documentation and test the endpoints.

## Usage

- **Quotations**: Access endpoints to manage quotations, including retrieving all quotations, getting a specific quotation by ID, creating new quotations, updating existing ones, and deleting quotations.
- **Authors**: Manage authors with similar CRUD operations.
- **Categories**: Handle categories through the API.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.