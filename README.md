# OrderManagement

Application is developed using <br />
1. API Core (A separate API application for backend)<br />
  ==> This application uses SOLID principles with Disconnected Architecture using MediatR<br />
  ==> Application is using the Domain Driven patter<br />
  ==> Application uses CQRS<br />
2. Blazor Web App<br />
  ==> Application is used to do UI operation with very basic applications
  ==> UI calls API for all the backend operation with Login (JWT Token) authentication
3. Architecture Overview
  3.1 Entity Project
    ==> This project contains all the DBContext classes, Entity Classes and also contains Migration files
    ==> You can use the Database Folder where the actual database is located
  3.2 Repository Project
    ==> This project contains all LINQ queries to do all DB operations on Entity project context classes
  3.3 Model Project
    ==> This project contains following classes
      3.3.1 Configuration
        ==> This folder contains class for AppSettings properties which will be injected in API project
      3.3.2 Constant
        ==> Contains Message class files for all the messages to show (i.e Success, Duplicate etc)
      3.3.3 Factory
        ==> This contains classes to convert from View Model to Entity model and vice versa
      3.3.4 Request
        ==> Contains Request View Model classes used by UI as well as API Controller
      3.3.5 Response
        ==> Contains Response View Model classes used by UI as well as API controller
      3.3.6 Routes
        ==> All restfull Routes are declared and defined in this class
  3.4 Domain Project
    ==> This project contains Commands and Queries which uses MediatR disconnected architecture to Send and Handle the requests from Controller
    ==> Command / Query will call the Repo methods to do the DB operations
  3.5 API Project
    ==> This prohject is in .Net Core 6.0 framework and contains restfull services for all Supplier operations
  3.6 Web Project
    ==> This project is developed in Blazor with .net Core 6.0 framework, which calls the APIs directory for all operations.
    
    
How to Run
1. Right click on the solution and Go To Properties
2. On Start Up project >> select Multiple Startup project
3. Select Supplier.API with Start and Select Supplier.Web with start
4. Run the project, it will open two instances, one with API swagger and another one with UI
5. You can also use swagger to do all the operation
6. For any api call, first Login needs to be called where you can pass default user name and password admin:admin
7. After getting token from the response of login, click on Authorize in the swagger window >> a popup will apprear where you can put "Bearer {your token}" to authorize the swagger
8. Run any other api and it will authorize and return the response
