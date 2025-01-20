****About Project****

  This project is a demo project of a simple Employee management page where a user can add, edit and create employees

****Built With****

    .Net Core 8

    Bootstrap 5

    JQuery

    JQuery DataTables

****How to setup the project****

  You will need either SQLSrver or SQLExpress installed to run the database

    SQLExpress: https://www.microsoft.com/en-gb/download/details.aspx?id=101064

    SQLServer: https://www.microsoft.com/en-gb/sql-server/sql-server-downloads
  
  1. Download and extract the project

  2. Open the project folder and click HRDemoProject.sln to run it
     
     (To run the project, you will need Visual Studio or a similar editing tool)

  3. To create the database, expand HRDEmo.Schema -> DbSetupScript (open the file location of the folder)
     
  5. Select either SqlExpressDbSetup.bat or SqlServerDbSetup.bat depending on your setup and double-click to run it

  6. Build, then publish HRDEmo.Schema project, this will create the required tables and populate them with some test data
     
****How to run the project****

  1. The HRDemoProject is set to run on localhost:7240, HRDemo.Api is set to run on localhost:7110. This can be updated in the launchSettings.json under each project if required
  
  2. HRDemoProject and HRDemo.Api both need to be run to use the application, ensure "Multiple startup project" action for HRDemoProject and HRDemo.Api is set to Start

  3. The default page size is set to 25, this can be updated by editing appsettings.Development.json -> DataTableSettings -> PageLength to a valid number
     
  4. Start the project and enjoy
     
****See it in action****

https://jam.dev/c/ff733a64-a633-4af8-a767-65f64d36e2ef
