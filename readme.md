# a demo for ids4 

## todo list

- setup basic identity server
- add identity support
- add identity ui support
- add efcore MySql/SqlServer support
- 


dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
dotnet ef migrations add InitApplicationDb -c ApplicationDbContext -o Data/Migrations/Identity