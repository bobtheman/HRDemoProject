DECLARE @BeginScript DATETIME
DECLARE @EndScript DATETIME
DECLARE @Status SMALLINT
DECLARE @Error NVARCHAR(2000)

-- Start Timer
SET @BeginScript = GETDATE()

PRINT 'Script _003_Populate_UserData.sql [1D35BA93-07EB-47CE-8AD0-00E4B9547BD0]'

IF NOT EXISTS(SELECT Id FROM ScriptSetupLog WHERE [Code] = '1D35BA93-07EB-47CE-8AD0-00E4B9547BD0' AND [Status] = 1)
	BEGIN		
		BEGIN TRY
			PRINT 'Script _003_Populate_UserData.sql [1D35BA93-07EB-47CE-8AD0-00E4B9547BD0] started.'	
			BEGIN TRANSACTION
			-- ************************************************************************************************************************************
			-- Script goes here
			-- ************************************************************************************************************************************	
				
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Anderson','wendy.anderson@email.com','1986-01-01',5,1,'WA003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('John','Doe','john.doe@email.com','1985-02-02',1,1,'JD001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jane','Doe','jane.doe@email.com','1979-01-13',2,1,'JD002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jim','Doe','jim.doe@email.com','1963-03-17',3,2,'JD003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jill','Doe','jill.doe@email.com','1999-12-21',4,1,'JD004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jack','Doe','jack.doe@email.com','1992-10-31',5,2,'JD005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Bob','Smith','bob.smith@email.com','1975-08-22',2,1,'BS002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Charlie','Smith','charlie.smith@email.com','1990-11-30',3,1,'CS003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('David','Smith','david.smith@email.com','1988-07-07',4,1,'DS004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Eve','Smith','eve.smith@email.com','1995-09-19',5,1,'ES005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Grace','Brown','grace.brown@email.com','1978-02-14',2,3,'GB002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Hank','Brown','hank.brown@email.com','1983-03-03',3,1,'HB003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Karen','Johnson','karen.johnson@email.com','1981-06-06',1,1,'KJ001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Leo','Johnson','leo.johnson@email.com','1976-10-18',2,1,'LJ002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Mia','Johnson','mia.johnson@email.com','1993-01-27',3,1,'MJ003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Nina','Johnson','nina.johnson@email.com','1989-05-05',4,1,'NJ004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Oscar','Johnson','oscar.johnson@email.com','1984-12-23',5,3,'OJ005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Paul','Williams','paul.williams@email.com','1986-10-10',1,1,'PW001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Quinn','Williams','quinn.williams@email.com','1977-04-16',2,1,'QW002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Sam','Williams','sam.williams@email.com','1983-02-12',4,1,'SW004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Tina','Williams','tina.williams@email.com','1990-08-20',5,1,'TW005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Uma','Jones','uma.jones@email.com','1981-03-28',1,1,'UJ001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Victor','Jones','victor.jones@email.com','1979-09-04',2,1,'VJ002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Jones','wendy.jones@email.com','1992-06-13',3,1,'WJ003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Xander','Jones','xander.jones@email.com','1985-01-21',4,1,'XJ004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Yara','Jones','yara.jones@email.com','1988-11-09',5,1,'YJ005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Zane','Jones','zane.jones@email.com','1980-07-17',1,1,'ZJ001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Amy','Davis','amy.davis@email.com','1977-05-25',2,1,'AD002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Brian','Davis','brian.davis@email.com','1991-02-02',3,1,'BD003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Cathy','Davis','cathy.davis@email.com','1984-10-30',4,1,'CD004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ella','Miller','ella.miller@email.com','1986-06-06',1,1,'EM001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Frank','Miller','frank.miller@email.com','1978-02-14',2,1,'FM002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Grace','Miller','grace.miller@email.com','1983-03-03',3,2,'GM003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Hank','Miller','hank.miller@email.com','1991-11-11',4,1,'HM004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ivy','Miller','ivy.miller@email.com','1987-04-29',5,1,'IM005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jack','Wilson','jack.wilson@email.com','1981-06-06',1,2,'JW001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Karen','Wilson','karen.wilson@email.com','1976-10-18',2,2,'KW002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Leo','Wilson','leo.wilson@email.com','1993-01-27',3,1,'LW003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Mia','Wilson','mia.wilson@email.com','1989-05-05',4,3,'MW004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Oliver','Taylor','oliver.taylor@email.com','1980-12-12',1,1,'OT001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Penny','Taylor','penny.taylor@email.com','1985-03-23',2,1,'PT002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Quincy','Taylor','quincy.taylor@email.com','1990-07-14',3,1,'QT003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Rita','Taylor','rita.taylor@email.com','1995-11-05',4,1,'RT004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Steve','Taylor','steve.taylor@email.com','1982-02-26',5,1,'ST005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Tina','Taylor','tina.taylor@email.com','1987-06-17',1,1,'TT001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Uma','Taylor','uma.taylor@email.com','1992-10-08',2,1,'UT002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Vince','Taylor','vince.taylor@email.com','1979-01-29',3,1,'VT003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Taylor','wendy.taylor@email.com','1984-05-20',4,1,'WT004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Xander','Taylor','xander.taylor@email.com','1989-09-11',5,1,'XT005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Yara','Taylor','yara.taylor@email.com','1994-12-02',1,1,'YT001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Zane','Taylor','zane.taylor@email.com','1981-03-23',2,1,'ZT002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Amy','Anderson','amy.anderson@email.com','1986-07-14',3,1,'AA001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Brian','Anderson','brian.anderson@email.com','1991-11-05',4,1,'BA002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Cathy','Rees','cathy.rees@email.com','1978-02-26',5,2,'CA003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Derek','Anderson','derek.anderson@email.com','1983-06-17',1,1,'DA004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ella','Anderson','ella.anderson@email.com','1988-10-08',2,1,'EA005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Frank','Morley','frank.morley@email.com','1993-01-29',3,1,'FA001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Grace','Owen','grace.owen@email.com','1979-05-20',4,1,'GA002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Hank','Anderson','hank.anderson@email.com','1984-09-11',5,1,'HA003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ivy','Anderson','ivy.anderson@email.com','1989-12-02',1,1,'IA004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jack','Anderson','jack.anderson@email.com','1994-03-23',2,2,'JA005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Karen','Jones','karen.jones@email.com','1981-07-14',3,1,'KA001');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Leo','Anderson','leo.anderson@email.com','1986-11-05',4,1,'LA002');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Mia','Anderson','mia.anderson@email.com','1991-02-26',5,1,'MA003');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Nina','Smith','nina.smith@email.com','1978-06-17',1,1,'NA004');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Oscar','Anderson','oscar.anderson@email.com','1983-10-08',2,1,'OA005');
				INSERT INTO EmployeeData (FirstName,LastName,EmailAddress,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Paul','Anderson','paul.anderson@email.com','1988-01-29',3,1,'BG005');

			-- ************************************************************************************************************************************
			-- Script End			
			-- ************************************************************************************************************************************
			SET @Status = 1
			COMMIT TRANSACTION
			PRINT 'Script _003_Populate_UserData.sql [1D35BA93-07EB-47CE-8AD0-00E4B9547BD0] ran successfully.'
		END TRY
		BEGIN CATCH
			SET @Status = 2
			SET @Error ='Nr: '+CAST(ERROR_NUMBER() AS NVARCHAR(10))+'| Line: '+CAST(ERROR_LINE() AS NVARCHAR(10))+'| MSG: '+ERROR_MESSAGE()
			ROLLBACK TRANSACTION
			PRINT 'Error in Script _003_Populate_UserData.sql [1D35BA93-07EB-47CE-8AD0-00E4B9547BD0]: '+@Error
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			RAISERROR (@ErrorMessage, -- Message text.
        @ErrorSeverity, -- Severity.
        @ErrorState -- State.
        );
		END CATCH;		
		
		-- Timer End
		SET @EndScript = GETDATE()			
		
		INSERT INTO ScriptSetupLog ([Code], Name, Started, Duration, [Status], Error) VALUES 
											('1D35BA93-07EB-47CE-8AD0-00E4B9547BD0','_003_Populate_UserData.sql', @BeginScript, DATEDIFF(ms, @BeginScript, @EndScript), @Status, @Error)
	END
	ELSE
		PRINT 'Script _003_Populate_UserData.sql [1D35BA93-07EB-47CE-8AD0-00E4B9547BD0] was not executed because it already exists.'
GO
PRINT '------------------------------------------------------------------------------------------------------'
GO
