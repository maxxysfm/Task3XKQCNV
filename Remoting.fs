namespace Task3XKQCNV

open WebSharper

[<JavaScript>]
module Dto =
    type Weight =
        {
            Username: string
            Weight: int
            Published: System.DateTime
        }
    type User =
        {
            Username: string
            Name: string
            Password: string
        }

module Database =
    
    open FSharp.Data.Sql
    open Dto
    type DB = SqlDataProvider<
                  ConnectionString = "Server=localhost;Database=Task3;Trusted_Connection=True;",
                  DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
                  UseOptionTypes = true>

    // Az órán említett példa alapján
    let AllUsers () =
        let ctx = DB.GetDataContext()
        query {
            for user in ctx.Dbo.Users do
            select user
        }
        |> Seq.map (fun user ->
            {
                Username = user.Username.Value
                Name = user.Name.Value
                Password = user.Password.Value
            }
        )
        |> Seq.toList
        
    // Belépéskor csak egy user adatait keressük
    let Login (username: string,password: string) =
        let ctx = DB.GetDataContext()
        query {
            for user in ctx.Dbo.Users do
            where (username = user.Username.Value)
            where (password = user.Password.Value)
            select user
        }
        |> Seq.map (fun user ->
            {
                Username = user.Username.Value
                Name = user.Name.Value
                Password = user.Password.Value
            }
        )

        // https://stackoverflow.com/questions/17246001/f-invalidoperationexception-the-input-sequence-has-an-insufficient-number-of
        // Ezt meg csak így lehet
        |> Seq.tryHead
        
    // Regisztrálás
    let NameExists (username: string) =
        let ctx = DB.GetDataContext()
        query {
            for user in ctx.Dbo.Users do
            where (username = user.Username.Value)
            select user
        }
        |> Seq.map (fun user ->
            {
                Username = user.Username.Value
                Name = user.Name.Value
                Password = user.Password.Value
            }
        )

        // https://stackoverflow.com/questions/17246001/f-invalidoperationexception-the-input-sequence-has-an-insufficient-number-of
        // Ezt meg csak így lehet
        |> Seq.isEmpty
        
        // True helyett false legyen, mivel azt nézzük létezik-e ilyen rekord
        |> not

    // Új user
    let Register(username: string,name: string,password: string) =

        let ctx = DB.GetDataContext()
        let User = ctx.Dbo.Users

        // Feltöltés
        // https://fsprojects.github.io/SQLProvider/core/crud.html
        let row = User.Create()
        
        // Ahoz hogy olyan fajta típus legyen, bele kell rakni egy Some()-ba
        row.Username <- Some(username)
        row.Name <- Some(name)
        row.Password <- Some(password)
        ctx.SubmitUpdates()
        
    // A mentett súlyok
    let AllWeights () =
        let ctx = DB.GetDataContext()
        query {
            for weight in ctx.Dbo.Weights do
            select weight
        }
        |> Seq.map (fun weight ->
            {
                Username = weight.Username.Value
                Weight = weight.Weight.Value
                Published = weight.Published.Value
            }
        )
        |> Seq.toList
        
    // 
    let AllWeightsChart () =
        let ctx = DB.GetDataContext()
        query {
            for weight in ctx.Dbo.Weights do
            select weight
        }
        |> Seq.map (fun weight ->
            {
                Username = weight.Username.Value
                Weight = weight.Weight.Value
                Published = weight.Published.Value
            }
        )
        |> Seq.sortBy(fun x->x.Published)
        |> Seq.toList
    
    // Új Weight rekord
    let AddWeight(username: string,weight: int,published: System.DateTime) =

        let ctx = DB.GetDataContext()
        let Weight = ctx.Dbo.Weights

        // Feltöltés
        // https://fsprojects.github.io/SQLProvider/core/crud.html
        let row = Weight.Create()
        
        // Ahoz hogy olyan fajta típus legyen, bele kell rakni egy Some()-ba
        row.Username <- Some(username)
        row.Weight <- Some(weight)
        row.Published <- Some(published)
        ctx.SubmitUpdates()

module Server =
      
    [<Rpc>]
    let Register(username: string,name: string,password: string) =
            Database.Register (username,name,password)

    [<Rpc>]
    let AllUsers() =
        async {
            return Database.AllUsers()
        }
        
    [<Rpc>]
    let AddWeight(username: string,weight: int,published: System.DateTime) =
        Database.AddWeight (username,weight,published)
            
    [<Rpc>]
    let Login(username: string,password: string) =
        Database.Login (username,password)
            
    [<Rpc>]
    let NameExists(username: string) =
        Database.NameExists (username)

    [<Rpc>]
    let AllWeights() =
        Database.AllWeights()
            
    [<Rpc>]
    let AllWeightsChart() =
        Database.AllWeightsChart()
