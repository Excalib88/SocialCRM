dotnet ef migrations add name -c DataContext --project ../SocialCRM.DAL.Migrations
dotnet ef database update -c DataContext --project ../SocialCRM.DAL.Migrations