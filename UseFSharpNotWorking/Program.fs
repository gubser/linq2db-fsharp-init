module UseFSharpNotWorking.Program

open Npgsql
open LinqToDB.DataProvider.PostgreSQL
open LinqToDB
open LinqToDB.FSharp

let connectionString = "..."
let dataSource = NpgsqlDataSourceBuilder(connectionString).Build()

let dataProvider =
    PostgreSQLTools.GetDataProvider(connectionString = connectionString)

let dataOptions =
    (new DataOptions())
        .UseConnectionFactory(dataProvider, (fun _ -> dataSource.CreateConnection()))
        // The following line gives a compiler error: "The type 'DataOptions' does not define the field, constructor or member 'UseFSharp'."
        .UseFSharp()

// Workaround:
// let dataOptions = LinqToDB.FSharp.Methods.UseFSharp dataOptions
