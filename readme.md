# GovPredict Software Engineering Take-home Test

## Introduction

This application follow the instructions from GovPredict software engineering test, showing a list of posts from social networks as Facebook and Twitter. The posts can be filtered by date range, lists of account (one or more), social networks (one or more) and post content.

Were created as fake data:

- 999 posts
- 2 social networks
- 3 users
- 8 accounts (profiles)
- 3 lists

### Application

Backend and frontend are decoupled, and communicate using the REST API at http://localhost:5000.

SQLite was used, because is the simplest solution for database and provide the easiest way to run the application in any enviroment. Nevertheless it's easy to change the database provider. Just install the correct Entity Framework dotnet package for your database and run the migrations

### Tech Stack

- .Net Core 3.1

  - Entity Framework
  - Bogus (Faker)

- Sqlite Database

- ReactJS
  - Material-UI
  - Axios

## Install Instruction

[Download](https://dotnet.microsoft.com/download/dotnet-core/3.1) and install .Net Core 3.1 SDK

Unzip the project source.

In the root path of the folder, run the following commands:

- To restore project packages: `dotnet restore`
- To build: `dotnet build`
- To run: `dotnet run`

When you run the project, navigate to http://localhost:5000

Thats all you need to test the solution.

## Backend notes

- The HTTPS (https://localhost:5001) was disabled, because caused certificate problems in one different test enviroment than the developer. If you wants to enable, uncomment the two commented lines in Staptup.cs file and change the URL in the config.js file, inside gpapp/src folder.

### Migrations

- The migrations were created and already applied in the database.
- Any changes in the model or in the seed file needs to be apply. To do this you can:
- `dotnet ef migration add NAME` To add a new migration
- `dotnet ef migration remove` To remove one migration
- `dotnet ef database update Initial` To revert to Initial migration
- `dotnet ef database update 0` To unapply all migrations
- `dotnet ef database update` To Apply the migrations

## Frontend notes

- The frontend were build with ReactJS, using create-react-app as base.
- The running frontend app served by the app, are in wwwroot folder and is the builded version, so you don't need to have NodeJS and install the npm packages. Everything it's ready to test.

### Change the frontend code

- For work with the frontend code, you need to install NodeJS (version ^10.0.0) and, in gpapp folder, run `npm install`
- In the gpapp folder and run `npm start` to run the frontend in developer mode.
- Any changes in code, needs to be updated and copied to wwwwroot folder. For this, in gpapp folder, run `npm build` and `npm deploy` for unix systems or `npm deploy-windows` in Windows.
