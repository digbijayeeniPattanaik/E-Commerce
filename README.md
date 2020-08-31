# E-Commerce
Build a proof of concept e-commerce store using Angular, .Net Core and Stripe for payment processing

Some of the scripts used to create the solution and the API architecture.

- dotnet help
- dotnet new --help
- dotnet new sln
- dotnet new webapi -o API
ls - to view the list of files present in the folder

- dotnet sln add API

- dotnet run
- dotnet dev-certs -h
- dotnet dev-certs -t
This will reflect the changes while running the application -  dotnet watch run
Go to terminal - dotnet --info
Check the host version and install the same version of EntityFramework core , else we might get issues later

- dotnet tool install --global dotnet-ef --version 3.1.302

- dotnet new classlib -o Infrastructure
- dotnet new classlib -o Core
- dotnet add reference --/Core

Important steps to do Initial Migrations
- Install EntityFramework Core. design in the Startup project. Else migration will not work.

- dotnet ef database drop -p Infrastructure -s API 
Infrastructure because thats where our StoreContext is and API because of the start up file as it mentions which database.

To remove our existing migrations
- dotnet ef migrations remove -p Infrastructure -s API 

Generate a new migrations
- dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations

cd..To update the migration
- dotnet ef database update

API controller attributes validates the routes
