# CoreBankingApplication

CoreBankingApplication is a secure banking application built with ASP.NET Core, Entity Framework Core, SQL Server, and ASP.NET Core Identity. The application allows users to create and manage bank accounts, perform financial transactions, and securely access banking features through a modern web interface.

## Live Demo

Application URL:

https://bankapplication-d8dtepfje8e9dsds.centralus-01.azurewebsites.net/

## Demo Access

Username: admin

Password: password

## Features

* Account creation and management
* Deposit funds
* Withdraw funds
* Transaction history and account activity
* Responsive user interface
* Server-side validation
* Azure cloud deployment

## Technologies

* ASP.NET Core
* ASP.NET Core Identity
* Entity Framework Core
* SQL Server
* Razor Pages / MVC (update to match your project)
* Bootstrap
* Azure App Service

## Architecture

The application follows a layered architecture that separates presentation, business logic, and data access concerns.

### Authentication & Security

* ASP.NET Core Identity
* Secure password hashing
* Role-based authorization
* Protected routes and resources
* Authentication cookies

### Data Access

* Entity Framework Core
* SQL Server database
* Code First Migrations

### User Interface

* Bootstrap responsive design
* Form validation
* Error handling and user feedback

## Security Features

* Password hashing and salting
* Authentication and authorization
* Input validation
* Protection against unauthorized access
* Secure user management

## Database

The application uses SQL Server with Entity Framework Core migrations to manage database schema changes.

Key entities include:

* Users
* Bank Accounts
* Transactions
* Account Activity

## Running Locally

1. Clone the repository.
2. Update the connection string in `appsettings.json`.
3. Apply Entity Framework Core migrations:

```bash
dotnet ef database update
```

4. Run the application.

## Future Enhancements

* Two-Factor Authentication (2FA)
* Email notifications
* Account statements and PDF exports
* Audit logging
* Advanced reporting
* Transaction search and filtering
* Mobile-friendly enhancements

## Screenshots

Add screenshots of:

* Login page
* Registration page
* Dashboard
* Account Details
* Transfer Funds page
* Transaction History

## Author

Ronald Rex

## License

This project is intended for educational and portfolio purposes.
