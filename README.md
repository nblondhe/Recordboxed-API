## Commands

#### On first run
`dotnet dev-certs https --trust`

#### Startup
```
dotnet restore
<!-- dotnet ef database update -->
dotnet build
dotnet run --project Recordboxed
```
#### Optional Run

`dotnet run --launch-profile https`