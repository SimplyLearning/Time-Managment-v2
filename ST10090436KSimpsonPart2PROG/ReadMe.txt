

		*** How to run the application. ***


1.  Open the file containing the code, once opened in Visual Studio there will be a play button next to
	the file name. Click that button to build and start the application. 

2.  Once the application has opened, Click either Register or Login, If you have never used the application 
	before then you will have to Register but if you already have an account you may click on Login.
2.1 If you have chosen register create a username and password then click submit once submitted you will be 
	send to the login Page where you must re enter the credentials.
2.2 If you have chosen Login, if your infromation is correct you will be sent to the Modules Page where it 
	will only have your infromation and no one elses.

3.  If you would like to enter modules linked to you, enter the infromation required on screen and click 
	contine and follow the promt after that.
3.2 If you are not entering any new infromation you may click view Modules as this will take you to the 
	Module Display page where you can see all previously entered modules. 

4.	All of your modules will be displayed on this page the user have entered with the amount of self study 
	hours required per week for each module. You can click Next when you are ready for the application to 
	persist.

5.	Provide all the infromation required by the application to ensure there are no errors. Onces you, the 
	user has entered the 3 fields of infromation by clicking display the application will the calculate how 
	much time left you have to self study in that week. This will be displayed in the list box bellow the button.

6.  Once you have entered all your modules and see how much more time you have left, you may click the exit 
	button to exit the application. 


		*** How to Interact with the Sql Database Data. ***


1.  When opening the Visual Studio, you will want to click on view at the top left of the VS application then 
	click on SQL SERVER OBJECT EXPLORER, go to the local database and see that the database is ther called UserData.
	IF the database is not there you can create the database and add the following code this is just to ensure the 
	aplication works on your end. 

	*** This is for the Table Users ***
	CREATE TABLE [dbo].[tblUser] (
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (20) NOT NULL
);
	
	*** This is for the Table Modules ***
	CREATE TABLE [dbo].[tblModules] (
    [ModuleCode]   VARCHAR (8)   NOT NULL,
    [ModuleName]   VARCHAR (150) NOT NULL,
    [NumOfCredits] INT           NOT NULL,
    [HoursPerWeek] INT           NOT NULL,
    [StartDate]    DATE          NOT NULL,
    [NumOfWeeks]   INT           NOT NULL,
    [Username]     VARCHAR (50)  NOT NULL,
    CONSTRAINT [FK_UserModule] FOREIGN KEY ([Username]) REFERENCES [dbo].[tblUser] ([Username])
);

2. Once both of the tables have been created you may update the database and run the application. 