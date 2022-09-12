dotnet tool restore
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 6.0.8

dotnet ef dbcontext scaffold "{ConnectionString}" Microsoft.EntityFrameworkCore.SqlServer --namespace "Company.Product.Module.Entity" --context "CoreDbContext" --context-namespace "Company.Product.Module.Repository.Data" --force
