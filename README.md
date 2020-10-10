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
