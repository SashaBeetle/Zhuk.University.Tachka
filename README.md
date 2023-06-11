# [Tachka](https://carsharing.azurewebsites.net)
### Project for `'Web Technology'` course in Lviv National University of Ivan Franko
Contacts:
* [Telegram](https://t.me/zhuk_sasha) 
* Email: zuks01123@gmail.com
## Stack
* [.NET](https://dotnet.microsoft.com/) - free, open-source, cross-platform framework for building modern apps and powerful cloud services.
* [Azure](https://azure.microsoft.com/) - cloud computing platform and a set of services provided by Microsoft for building, deploying, and managing applications and services through Microsoft-managed data centers.
* [MS SQL Server](https://www.microsoft.com/sql-server/sql-server-2019) - relational database management system (RDBMS) developed by Microsoft that uses SQL (Structured Query Language) to manage and manipulate data, including storing, querying, and retrieving data.
* [Entity Framework](https://learn.microsoft.com/uk-ua/ef/) - object-relational mapping (ORM) framework for .NET developers that enables them to work with databases using .NET objects, simplifying the process of data access and manipulation.
* [MSTest](https://learn.microsoft.com/uk-ua/dotnet/core/testing/unit-testing-with-mstest) - unit testing framework for .NET developers that allows them to write and execute automated tests to ensure the correctness and reliability of their code.
* [App Service](https://azure.microsoft.com/en-us/products/app-service/) - set of cloud-based services provided by Microsoft that enable developers and businesses to build, deploy, and manage applications and services in the cloud, including computing, storage, networking, databases, analytics, and more.
* [NuGet packages](https://learn.microsoft.com/uk-ua/nuget/) - type of software package used in the Microsoft .NET ecosystem, containing compiled code and other resources, and are used by developers to easily add functionality to their projects and share code between teams.
* [Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio) - Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views.
* [Bootstrap](https://getbootstrap.com/) - Build fast, responsive sites.
## How to run project
Open your system terminal and run commands:
```sh
git clone https://github.com/SashaBeetle/Zhuk.University.Tachka.git
cd Zhuk.University.Tachka
```
Add your already deployed database connection string to files:
In `SashaBeetle/Zhuk.University.Tachka.Database/TachkaDbContext.cs` method `OnConfiguring(DbContextOptionsBuilder options)` add line of code which below. Instead of ConnectionString add your database connection string. Line of code: `options.UseSqlServer("ConnectionString")`;. Method should look like that:
```sh
protected override void OnConfiguring(DbContextOptionsBuilder options)
{
  options.UseLazyLoadingProxies();
  options.UseSqlServer("ConnectionString");
}
```
In `SashaBeetle/Zhuk.University.Web/appsettings.json` in `"ConnectionStrings"` add line: `"NetworkConnection": "ConnectionString"`. Instead of `ConnectionString` add your database connection string. Code shluld look like this:
```sh
  "ConnectionStrings": {
    "NetworkConnection": "ConnectionString"
  }
```
Than (if you have App Services) add line of your connection string to application insights. Code in `SashaBeetle/Zhuk.University.Web/appsettings.json` should look something like that, but also instead of `ConnectionString` should be yours.
```sh
  "ApplicationInsights": {
    "LogLevel": {
      "Default": "Information"
    },
    "ConnectionString": "ConnectionString"
  },
```
## Decomposition of tasks
### 1. Frontend
* ✅ Display Database
* ✅/🔳 Display API
* ✅ Display User register and login
* ✅ Display User profile
* 🔳 Display beautiful main page
* 🔳 Create beautiful site design

### 2. Database
* ✅ Create Database
* ✅ Connect Database
* ✅ Connect ORM Entity
* ✅ Create Schemas for objects

### 3. API
* 🔳/✅ User Avatar API
* 🔳 User Avatar API Controller
* ✅ User Location API
* ✅ User Location API Controller


### 4. Authorization
* ✅ Create Login and Register Pages
* ✅ Create Controller
* ✅ Create Service
* ✅ Create Models

### 5. Order
* ✅ Controllers
* ✅ Inividual Pages
* ✅ Features
* 🔳 Tracker

### 6. Suggestion(Algorithm)
* ✅ Page
* ✅ Controller
* 🔳 Filter

### 7. Loggs
* 🔳 Add logs for Authorization
* 🔳 Add logs for Orders
* 🔳 Add logs for User Profile

### 8. Test
* 🔳 Test Authorization
* 🔳 Test Orders
* 🔳 Test User Profile

### 9. Azure
* ✅ Deploy the project
* ✅ Connect Application Insights
* ✅ Connect Azure Database
* ✅ CI/CD

### 10. Git
* ✅ Add README on GIT
* ✅ CI/CD

# 📒 Lab 3 
- Task: I introduce a new feature on the website - Dark Mode. This feature will enable users to switch the website's interface to a darker color scheme that is easier on the eyes in low light environments.
- Name: Vitalii Synytskyi
- [My project](https://github.com/VitaliySynytskyi/CodeFlow)
- [Pull Request 1](https://github.com/SashaBeetle/Zhuk.University.Tachka/commit/851a4a7e8d9b94422127ae645520be15eeae0765)
- [Pull Request 2](https://github.com/SashaBeetle/Zhuk.University.Tachka/commit/46954eb068c609e2f13a6cc9d344a6c3034379a8)

# 📒 Lab 4
Zakala Oleksandr
- [My project](https://github.com/Rovikido/SafeRoute)
- [Pull request link](https://github.com/Rovikido/Zhuk.University.Tachka/pull/1#pullrequestreview-1441765335)

Blystsiv Ostap
- [My project](https://github.com/blystsiv/connectify)
- [Pull request link](https://github.com/blystsiv/Zhuk.University.Tachka/pull/1)
