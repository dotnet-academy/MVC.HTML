# Introduction
In this lecture we learn about developing web applications using the popular MVC (Model-View-Controller) pattern and specifically the [ASP.NET Core MVC 2.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1) framework.

## Web Terminology

We start by learning the basic terminology used in the web. Differences between web pages/sites (static, simpler) and web applications (dynamic content based on logged in user, usually database powered, built with performance, security, availability in mind).

We then learn what a web server is and how the term is used to denote both the *physical machine* where our web application is hosted and the *software* running our application, e.g. [IIS Web Server](https://docs.microsoft.com/en-us/iis/get-started/introduction-to-iis/iis-web-server-overview) or the more light-weight variant [IIS Express](https://docs.microsoft.com/en-us/iis/extensions/introduction-to-iis-express/iis-express-overview) used locally for our development.

We learn the concept of a URL and how it's used to point to a resource with the form `protocol://path-to-resource` (at its basic form).

First part ends with a demo of an actual request made from a web browser to a popular [search engine](`http://google.com`) and inspecting the various details of the HTTP requests/responses, using [Chrome Developer Tools (DevTools)](https://developers.google.com/web/tools/chrome-devtools/).

## HTTP Protocol

We learn about HTTP (and its secure variant HTTPS), the protocol used to communicate content between web servers and clients (e.g. browsers).

Basic parts of the HTTP Protocol are:

- Verbs (used to convey meaning, e.g. `GET`, `POST`)
- Headers (used in request/responses, e.g. `Content-Type: application/json`)
- Body (used by some verbs, to pass additional information, e.g. `{ "name": "kostas" }`)
- Status Codes (to give more information about the result, e.g. `200 (Success)`, `404 (Not Found)`)

## MVC Pattern

We learn about the most popular pattern used right now by all major web frameworks ([Express JS](https://expressjs.com/) [Django](https://www.djangoproject.com/), [Ruby on Rails](https://rubyonrails.org/), [Spring](https://rubyonrails.org/)) to develop web applications.

Based on the separation of concerns principle, it helps us develop a web application by focusing each time to one of its three components:

- Model: *Independent* of the other two. Holds our *domain/business model*.
- Controller: Used for routing request and *mapping/routing* URLs to our methods.
- Views: Displays a *representation (view model)* of the model to the user.

## ASP.NET Core MVC

We begin by creating a new web application from scratch step-by-step and explain what happens at each step.

We demonstrate *conventional routing* (used by default) and the differences between *attribute routing*, that we suggest.

We inspect the shape of a **`Controller`** class and see various sample actions returning Views, Files, JSON etc.

We discuss about **Views** and how they are structured using `Layout.cshtml` and `ViewStart.cshtml`.

We learn how to pass data from the controller to the view, using two techniques:
- Loosely-Typed *(bad)*
- Strongly-Typed *(good)*

We learn the concept of `.cshtml` and how they combine C# code with HTML to form the, what is called, [Razor Syntax](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-2.1).

We finally see the concept of a **Model** (or view model) and how we can decorate our class using Validation [attributes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/) (`Required`, `DataType`, `EmailAddress`, etc) to gain for free both client side and server side validation.

We also see how to make the View *aware* of the model, using the `@model` directive and using [Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-2.1) to produce HTML that is *binded* to our Model.

## Create a demo web app from scratch

### Create database

The model we suggest for developing your websites is by putting the database model first, as it's very important to learn to create your own basic schemas and be able to interact with a database engine (here we use [Local DB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb?view=sql-server-2017)).

We first [create](https://github.com/dotnet-academy/Mvc/blob/master/src/sql/MoviesDb.sql)  our database and [feed](https://github.com/dotnet-academy/Mvc/blob/master/src/sql/MoviesFeed.sql) it with *system* data.

### Creating DataContext and Models

Having the database ready, next step is to create our Models (classes that will represent database objects in our code) and also configure our `DataContext`. We use [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/).

Remember, `DataContext` is the gateway from your database to your application. This class:

> manages the entity objects during run time, which includes populating objects with data from a database, change tracking, and persisting data to the database.

The above two steps can be done for you, by using the `Scaffold-DbContext` tool, available as a nuget package.

To be able to run it, you first need to install the following [NuGet](https://docs.microsoft.com/en-us/nuget/what-is-nuget) packages:

- `Install-Package Microsoft.EntityFrameworkCore.SqlServer` 

`LocalDb` uses the SqlServer engine, so we need to make aware EF Core for the db engine we're using.

- `Install-Package Microsoft.EntityFrameworkCore.Tools`

Thas is the NuGet package containing the actual command (`Scaffold-DbContext`).

- `Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design`

This package will be used in the following section for scaffolding the controller and the views.

After installing the above three packages in your project, you need to run the actual command which will scaffold the models and the datacontext for you.

Remember that `Server=` and `Database=` parameters, must match the ones used to connect using Sql Server Management Studio to your database:

- `Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Movies;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`


![SSMS Connect to server screen](/img/sql-server.png)

### Creating the Controller and the Views

After creating the models and the data context, you can also scaffold a `Controller` along with all the standard CRUD (Create-Read-Update-Delete) Views, by following the steps below:

![Controller Scaffolding](/img/controller-scaffolding.gif)

After you complete this step, you should see a `MoviesController` inside the `Controllers` folder and a `Movies` folder under the `Views` folder with the `Create/Delete/Details/Edit/Index` pages (of course, naming will vary if you choose different Controller name):

![Controller Scaffolding](/img/controller-scaffolding-after.png)

## Tips & Tricks

- [Learn](http://visualstudioshortcuts.com/2017/) your IDE. Shortcuts are invaluable to save you time and make you more productive.
- Start small. Improve later. Focus on one thing at a time. E.g. focus on Controllers, without worrying on the appearance of your views.
- Google it/Stackoverflow it. [Stackoverflow](https://stackoverflow.com/) has made a significant impact on how we work and how we communicate. If a question seems overly stupid to ask it to a person (you shouldn't feel this way, by the way), try asking Stackoverflow first. It won't judge you.
- [Read](https://github.com/) other peoples code. Coding is like writing a book (but like 1000 harder :blush: ). You need insipiration and techniques to help you develop your own style.
- Your code should be clear and convey *meaning*. If *you* can't read the code you've written some days later, imagine some pure guy reading it a few months (or years) later.