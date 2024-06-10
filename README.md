# PrzykladowyKolosAPBD2

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design

dotnet new tool-manifest
dotnet tool install dotnet-ef

dotnet ef migrations add NAME
dotnet ef database update
dotnet ef migrations remove

"ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=APBD1;Integrated Security=True;Encrypt=False"
  },

  <InvariantGlobalization>false</InvariantGlobalization>
