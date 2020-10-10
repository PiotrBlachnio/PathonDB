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
