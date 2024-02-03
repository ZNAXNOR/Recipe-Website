<h1 align='center'> Recipe Website <sup>2</sup> </h1>

<!-- Tools -->
<div align='center'>

<table>
  
<tr> </tr>

  <!-- Frontend -->
  <td valign="top">
    <h2 align='center'> Frontend </h2>
    <div align="center">      
      <a href="https://getbootstrap.com/" title="Bootstrap">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/bootstrap-plain.svg" alt="Bootstrap" height="50">
      </a>  
      &nbsp;
      <a href="https://www.w3schools.com/css/" title="CSS3">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/css3-original-wordmark.svg" alt="CSS3" height="50">
      </a>  
      <br>
      <a href="https://html.com/" title="HTML5">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/html5-original-wordmark.svg" alt="HTML5" height="50">
      </a>  
      &nbsp;
      <a href="https://www.javascript.com/" title="JavaScript">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/javascript-original.svg" alt="JavaScript" height="50">
      </a>  
    </div>  
  </td>

  <!-- Backend -->
  <td valign="top">
    <h2 align='center'> Backend </h2>
    <div align="center">      
      <a href="https://www.javascript.com/" title="JavaScript">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/javascript-original.svg" alt="JavaScript" height="50">
      </a>
      &nbsp;
      <a href="https://docs.microsoft.com/en-us/dotnet/csharp/" title="C#">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/csharp-original.svg" alt="C#" height="50">
      </a> 
    </div>  
  </td>
  
  <!-- Database -->
  <td valign="top">
    <h2 align='center'> Database </h2>
    <div align="center">      
      <a href="https://www.microsoft.com/en-in/sql-server/sql-server-downloads" title="MSSQL">
        <img src="https://github.com/ZNAXNOR/Simple-Website/assets/121810601/fdeff82c-eba0-4f3c-82a8-8a2b3e9d0678"  alt="MSSQL" height="50"/>
      </a>  
    </div>
  </td>
  
  <!-- Framework -->
  <td valign="top">
    <h2 align='center'> Framework </h2>
    <div align="center">      
      <a href="https://dotnet.microsoft.com/download" title=".Net Core">
        <img style="margin: 10px" src="https://profilinator.rishav.dev/skills-assets/dotnetcore.png" alt=".Net Core" height="50">
      </a> 
    </div>

  </td>
  
  <!-- Thirdparty-->
  <td valign="top">
    <h2 align='center'> Thirdparty</h2>
    <div align="center">      
      <a href="https://myaccount.google.com/apppasswords" title="Google SMTP">
        <img style="margin: 10px" src="https://github.com/ZNAXNOR/Recipe-Website/assets/121810601/a88cbf32-9cd0-4cf7-8312-40f10ad18ff3" alt="Gmail SMTP" height="50">
      </a>  
      &nbsp;&nbsp;
      <a href="https://cloudinary.com/" title="Cloudinary">
        <img style="margin: 10px" src="https://github.com/ZNAXNOR/Recipe-Website/assets/121810601/24107e67-a68f-4a2b-8a56-eba4cafb0298" alt="Cloudinary" height="50">
      </a>
    </div>
  </td>

</table> 

</div>

<br/>

### This project is being created using [ASP.NET Core] ( [MVC] )

*The primary objective* is to establish a website enabling users to create, view, edit, and delete recipes. Users will have the flexibility to make their recipes public, share them with specific individuals, or keep them private.

*The overarching aim* of this project is to construct a comprehensive website equipped with various tools, enabling users to securely store their recipes.

[ASP.NET Core]: https://dotnet.microsoft.com/en-us/apps/aspnet
[MVC]: https://learn.microsoft.com/en-us/aspnet/core/mvc/

---

## Changes from [RecipeWebsite]
***[Cards] are shared.***
  - Same cards are shared to all pages making code maintainence easier.
  - **_Post cards_** and **_Collection cards_** are seperated.

<br>

***[Enum files] are replaced by database tables.***
  - **Categories** uses database tables now.
  - Categories can be managed (_Create, Edit, Delete_) directly by the users.

<br>
 
***Files re-named to be:***
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
*Tasks are located in **[Issues]**. Click/Hover over them for more information*
- **[Posts]**
- **[Recipe Videos]**
- **[Recipe Collection]**
- **[Blogs]**
- **[Filter]**
- **[User Accounts]**
- **[User Feedback]**
- **[UI/UX]**

[Issues]: https://github.com/ZNAXNOR/Recipe-Website/issues
[Posts]: https://github.com/ZNAXNOR/Recipe-Website/issues/1
[Recipe Videos]: https://github.com/ZNAXNOR/Recipe-Website/issues/8
[Recipe Collection]: https://github.com/ZNAXNOR/Recipe-Website/issues/3
[Blogs]: https://github.com/ZNAXNOR/Recipe-Website/issues/11
[Filter]: https://github.com/ZNAXNOR/Recipe-Website/issues/2
[User Accounts]: https://github.com/ZNAXNOR/Recipe-Website/issues/9
[User Feedback]: https://github.com/ZNAXNOR/Recipe-Website/issues/7
[UI/UX]: https://github.com/ZNAXNOR/Recipe-Website/issues/10

---

## [NuGet Packages]

**[CloudinaryDotNet]**
> The Cloudinary .NET SDK allows you to quickly and easily integrate your application with Cloudinary. Effortlessly optimize, transform, upload and manage your cloud's assets.
- Documentation [here](https://cloudinary.com/documentation/)

<br>

**[Microsoft.AspNetCore.Identity.EntityFrameworkCore]**
> ASP.NET Core Identity provider that uses Entity Framework Core.
- The package was built from this [source code](https://github.com/dotnet/aspnetcore/tree/3f1acb59718cadf111a0a796681e3d3509bb3381)

<br>

**[Microsoft.EntityFrameworkCore]**
> Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. EF Core works with SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL, PostgreSQL, and other databases through a provider plugin API.
- Commonly Used Types:
  - Microsoft.EntityFrameworkCore.DbContext
  - Microsoft.EntityFrameworkCore.DbSet

<br>

**[Microsoft.EntityFrameworkCore.SqlServer]**
> Microsoft SQL Server database provider for Entity Framework Core.

<br>

**[Microsoft.EntityFrameworkCore.Tools]**
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
**[Cloudinary]**
> **Used as image database.**
- Resources used
  - CloudName
  - ApiKey
  - ApiSecret

[Cloudinary]: https://cloudinary.com/

<br>

**[Google SMTP]**
> **Used for sending emails.**
- Resources used
  - Host: smtp.gmail.com [^Host]
  - Port: 587 [^Port] 
  - Username: _App secret account Email_
  - Password: _App secret_  
- Source Code: [GitHub Repository for Google SMTP].

[Google SMTP]: https://myaccount.google.com/apppasswords
[GitHub Repository for Google SMTP]: https://github.com/ZNAXNOR/EmailSMTP

---

[RecipeWebsite]: https://github.com/ZNAXNOR/RecipeWebsite

[^Host]: Default Google Host
[^Port]: Default Port recomended
