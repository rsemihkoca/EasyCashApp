cd /home/rsemihkoca/Projects/EasyCashApp
dotnet ef migrations add InitialCreate --project EasyCashIdentityProject/DataAccessLayer --startup-project EasyCashIdentityProject/PresentationLayer
dotnet ef database update --project EasyCashIdentityProject/DataAccessLayer --startup-project EasyCashIdentityProject/PresentationLayer
