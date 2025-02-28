module UseFSharpFixed.Program

open Npgsql
open LinqToDB.DataProvider.PostgreSQL
open LinqToDB
open UseFSharpFixed.UseFSharpFix

let connectionString = "..."
let dataSource = NpgsqlDataSourceBuilder(connectionString).Build()

let dataProvider =
    PostgreSQLTools.GetDataProvider(connectionString = connectionString)

let dataOptions =
    (new DataOptions())
        .UseConnectionFactory(dataProvider, (fun _ -> dataSource.CreateConnection()))
        .UseFSharp()
