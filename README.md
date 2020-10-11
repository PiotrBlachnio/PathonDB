[![Netlify Status](https://api.netlify.com/api/v1/badges/89000ba4-f1bf-4527-a201-9abe8eaa4a26/deploy-status)](https://app.netlify.com/sites/pathondb/deploys)
[![BCH compliance](https://bettercodehub.com/edge/badge/PiotrBlachnio/PathonDB?branch=master)](https://bettercodehub.com/)

# Pathon Database
In-memory database created using C# language. It allows you to make changes using various queries. The client side was written in React. The application has simple key-based authorization system. Availabe queries: CREATE, INSERT and SELECT.

## Technologies used
* C#
* .NET Core
* React
* Typescript
* CSS

## Available queries
### CREATE
```
  CREATE TABLE <table_name> (<column_name_1> <type_1>, <column_name_2>, <type_2>);
```
- Column name must not contain any special characters
- Type must be one of these: text, int, boolean
- ID column is not allowed. It's generated automatically.

### INSERT
```
  INSERT INTO <table_name> (<column_name_1>, <column_name_2>) VALUES (<value_1>, <value_2>);
```

- Order of the column names does not matter
- Value must have the type matching the column one

### SELECT
```
  SELECT * FROM <table_name>;
```

```
  SELECT (<column_name_1>) FROM <table_name>;
```

```
  SELECT (<column_name_2>, <column_name_1>) FROM <table_name> WHERE id = 7;
```

- All the columns can be selected using __*__ character
- Individual columns have to be listed inside the parentheses
- Condition can be applied using WHERE keyword and giving column name with the corresponding value

## Running on localhost
### Client
****
**_Make sure you added corresponding variables from .env.example file in the client directory_**

****
```
git clone https://github.com/PiotrBlachnio/PathonDB.git
```

```
cd PathonDB/client
```

```
npm install
```

```
npm run start
```

### Server
```
git clone https://github.com/PiotrBlachnio/PathonDB.git
```

```
cd PathonDB/server
```

```
dotnet build
```

```
dotnet run
```

## Running using bash script
****
**_Make sure you added corresponding variables from .env.example file in the client directory_**

****

```
bash dev.sh
```
## Contributing
1. Fork it (https://github.com/PiotrBlachnio/PathonDB/fork)
1. Create your feature branch (git checkout -b feature/fooBar)
1. Commit your changes (git commit -am 'Add some fooBar')
1. Push to the branch (git push origin feature/fooBar)
1. Create a new Pull Request

## Check it by yourself
[Netlify](https://come-and-eat.netlify.com/#/home) - There might be some latency on the first request due to server deployment on Heroku
