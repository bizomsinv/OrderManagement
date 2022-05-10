# OrderManagement

Application is developed using <br />
1. API Core (A separate API application for backend)<br />
  ==> This application uses SOLID principles with Disconnected Architecture using MediatR<br />
  ==> Application is using the Domain Driven patter<br />
  ==> Application uses CQRS<br />
2. Blazor Web App<br />
  ==> Application is used to do UI operation with very basic applications<br />
  ==> UI calls API for all the backend operation with Login (JWT Token) authentication<br />
3. Architecture Overview<br />
  3.1 Entity Project<br />
    ==> This project contains all the DBContext classes, Entity Classes and also contains Migration files<br />
    ==> You can use the Database Folder where the actual database is located<br />
  3.2 Repository Project<br />
    ==> This project contains all LINQ queries to do all DB operations on Entity project context classes<br />
  3.3 Model Project<br />
    ==> This project contains following classes<br />
      3.3.1 Configuration<br />
        ==> This folder contains class for AppSettings properties which will be injected in API project<br />
      3.3.2 Constant<br />
        ==> Contains Message class files for all the messages to show (i.e Success, Duplicate etc)<br />
      3.3.3 Factory<br />
        ==> This contains classes to convert from View Model to Entity model and vice versa<br />
      3.3.4 Request<br />
        ==> Contains Request View Model classes used by UI as well as API Controller<br />
      3.3.5 Response<br />
        ==> Contains Response View Model classes used by UI as well as API controller<br />
      3.3.6 Routes<br />
        ==> All restfull Routes are declared and defined in this class<br />
  3.4 Domain Project<br />
    ==> This project contains Commands and Queries which uses MediatR disconnected architecture to Send and Handle the requests from Controller<br />
    ==> Command / Query will call the Repo methods to do the DB operations<br />
  3.5 API Project<br />
    ==> This prohject is in .Net Core 6.0 framework and contains restfull services for all Supplier operations<br />
  3.6 Web Project<br />
    ==> This project is developed in Blazor with .net Core 6.0 framework, which calls the APIs directory for all operations.<br />
    
    <br /><br />
How to Run<br />
1. Right click on the solution and Go To Properties<br />
2. On Start Up project >> select Multiple Startup project<br />
3. Select Supplier.API with Start and Select Supplier.Web with start<br />
4. Run the project, it will open two instances, one with API swagger and another one with UI<br />
5. You can also use swagger to do all the operation<br />
6. For any api call, first Login needs to be called where you can pass default user name and password admin:admin<br />
7. After getting token from the response of login, click on Authorize in the swagger window >> a popup will apprear where you can put "Bearer {your token}" to authorize the swagger<br />
8. Run any other api and it will authorize and return the response<br />
