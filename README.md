# Lyrnics


## Entity Framework Model Configuration
The context model configuration with separated files was chosen to make the project more readable and organized. There is one file for each Model class of the context.

On each configuration file was preferred specify the name of each structure in the database (table, column, constraints, etc), because according to the PostgreSQL ["Don't Do This" Page](https://wiki.postgresql.org/wiki/Don't_Do_This) isn't recommended to give names with uppercase letters as the EF Core Npgsql automatically does. Inside of postgresql, every query with uppercase names must be between double quotes to the case sensitive work, so in order to make easier to deal with the database queries outside the application I opted to specify every database structures names in lowercase on each EF Configuration Class.

**Ex:**
```sql
select * from foo, select * from "Bar";
```
