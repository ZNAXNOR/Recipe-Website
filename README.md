# Recipe Website <sup>2 <sup>MIGRATED</sup> </sup>
<sub>_migrating repository [RecipeWebsite](https://github.com/ZNAXNOR/RecipeWebsite) complete. Further project progress will be made here_<sub>

### This project is being created using [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) ([MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/))

**The aim of this project** is to create a website for users to be able to create, view, edit and delete recipes. The created recipes can be made public, shared to select few, or be kept private.

**The goal of this project** is to create a website that can provide all possible tools to the user that can allow them to store the recipe safely. 

---


## Changes from [RecipeWebsite](https://github.com/ZNAXNOR/RecipeWebsite)
- [Cards](https://getbootstrap.com/docs/5.3/components/card/) are shared.
  - Same cards are shared to all pages making code maintainence easier.
  - **_Post cards_** and **_Collection cards_** are seperated.


- [Enum files](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) are replaced by database tables.
  - **Categories** uses database tables now.
  - Categories can be managed (_Create, Edit, Delete_) directly by the users.
 
- **Files re-named** to be:
  - Unique
  - Easier to distinguish.
  - Not confusing.
  - Not hard to keep track of when mentioned.
  - Example:
    - `Post` file in **Models directory** used to be named `Post`. Renamed to `PostModel`.
    
---

## TASK
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

## [NuGet Packages](https://www.nuget.org/) <sup>Version</sup>
- Bootstrap <sup>[5.3.2](https://www.nuget.org/packages/bootstrap)<sup>
- CloudinaryDotNet <sup>[1.23.0](https://www.nuget.org/packages/CloudinaryDotNet)</sup>
- Microsoft.AspNetCore.Identity.EntityFrameworkCore <sup>[8.0.0](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore)</sup>
- Microsoft.EntityFrameworkCore <sup>[8.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)</sup>
- Microsoft.EntityFrameworkCore.SqlServer <sup>[8.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)</sup>
- Microsoft.EntityFrameworkCore.Tools <sup>[8.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)</sup>
