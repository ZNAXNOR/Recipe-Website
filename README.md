# Recipe Website <sup>2</sup>
> <sub>_migrating repository [RecipeWebsite] complete. Further project progress will be made here_<sub>

### This project is being created using [ASP.NET Core] ( [MVC] )

**The aim of this project** is to create a website for users to be able to create, view, edit and delete recipes. The created recipes can be made public, shared to select few, or be kept private.

**The goal of this project** is to create a website that can provide all possible tools to the user that can allow them to store the recipe safely. 

[ASP.NET Core]: https://dotnet.microsoft.com/en-us/apps/aspnet
[MVC]: https://learn.microsoft.com/en-us/aspnet/core/mvc/

---


## Changes from [RecipeWebsite]
### [Cards] are shared.
  - Same cards are shared to all pages making code maintainence easier.
  - **_Post cards_** and **_Collection cards_** are seperated.

### [Enum files] are replaced by database tables.
  - **Categories** uses database tables now.
  - Categories can be managed (_Create, Edit, Delete_) directly by the users.
 
### *Files re-named* to be:
  - Unique
  - Easier to distinguish.
  - Not confusing.
  - Not hard to keep track of when mentioned.
  - Example:
    - Post file in **Models directory** used to be named `Post`. It is now renamed to `PostModel`.
    
[Cards]: https://getbootstrap.com/docs/5.3/components/card/
[Enum files]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum

---

## Task
- [x] Recipe Post
- [ ] Recipe Videos
- [ ] Recipe Collection
- [ ] Blogs
- [x] Filter
- [x] User Accounts
- [ ] User Settings
- [x] User Feedback
- [ ] UI/UX

---

## [NuGet Packages]
### [Bootstrap]
> The most popular front-end framework for developing responsive, mobile first projects on the web.

### [CloudinaryDotNet]
> The Cloudinary .NET SDK allows you to quickly and easily integrate your application with Cloudinary. Effortlessly optimize, transform, upload and manage your cloud's assets.
- Documentation [here](https://cloudinary.com/documentation/)

### [Microsoft.AspNetCore.Identity.EntityFrameworkCore]
> ASP.NET Core Identity provider that uses Entity Framework Core.
- The package was built from this [source code](https://github.com/dotnet/aspnetcore/tree/3f1acb59718cadf111a0a796681e3d3509bb3381)

### [Microsoft.EntityFrameworkCore]
> Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. EF Core works with SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL, PostgreSQL, and other databases through a provider plugin API.
- Commonly Used Types:
  - Microsoft.EntityFrameworkCore.DbContext
  - Microsoft.EntityFrameworkCore.DbSet

### [Microsoft.EntityFrameworkCore.SqlServer]
> Microsoft SQL Server database provider for Entity Framework Core.

### [Microsoft.EntityFrameworkCore.Tools]
> Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.
- Enables these commonly used commands:
  - Add-Migration
  - Bundle-Migration
  - Drop-Database
  - Get-DbContext
  - Get-Migration
  - Optimize-DbContext
  - Remove-Migration
  - Scaffold-DbContext
  - Script-Migration
  - Update-Database

[NuGet Packages]: https://www.nuget.org/
[Bootstrap]: https://www.nuget.org/packages/bootstrap
[CloudinaryDotNet]: https://www.nuget.org/packages/CloudinaryDotNet
[Microsoft.AspNetCore.Identity.EntityFrameworkCore]: https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore
[Microsoft.EntityFrameworkCore]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore
[Microsoft.EntityFrameworkCore.SqlServer]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer
[Microsoft.EntityFrameworkCore.Tools]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools

---

## API's
### [Cloudinary]
> **Used as image database.**
- **Resources used**
  - CloudName
  - ApiKey
  - ApiSecret

[Cloudinary]: https://cloudinary.com/

### [Google SMTP]
> **Used for sending emails.**
- **Resources used**
  - Host: smtp.gmail.com [^Host]
  - Port: 587 [^Port] 
  - Username": _App secret account Email_
  - Password": _App secret_  
- Source Code: [GitHub Repository for Google SMTP].

[Google SMTP]: https://myaccount.google.com/apppasswords
[GitHub Repository for Google SMTP]: https://github.com/ZNAXNOR/EmailSMTP

---

[RecipeWebsite]: https://github.com/ZNAXNOR/RecipeWebsite

[^Host]: Default Google Host
[^Port]: Default Port recomended
