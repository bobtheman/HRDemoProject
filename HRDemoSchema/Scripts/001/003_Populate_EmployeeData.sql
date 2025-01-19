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
				
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Anderson','1986-01-01',5,1,'WA003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Anderson','1986-03-04',5,1,'WA006');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('John','Doe','1985-02-02',1,1,'JD001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jane','Doe','1979-01-13',2,1,'JD002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jim','Doe','1963-03-17',3,2,'JD003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jill','Doe','1999-12-21',4,1,'JD004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jack','Doe','1992-10-31',5,2,'JD005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Bob','Smith','1975-08-22',2,1,'BS002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Charlie','Smith','1990-11-30',3,1,'CS003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('David','Smith','1988-07-07',4,1,'DS004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Eve','Smith','1995-09-19',5,1,'ES005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Grace','Brown','1978-02-14',2,3,'GB002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Hank','Brown','1983-03-03',3,1,'HB003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Karen','Johnson','1981-06-06',1,1,'KJ001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Leo','Johnson','1976-10-18',2,1,'LJ002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Mia','Johnson','1993-01-27',3,1,'MJ003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Nina','Johnson','1989-05-05',4,1,'NJ004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Oscar','Johnson','1984-12-23',5,3,'OJ005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Paul','Williams','1986-10-10',1,1,'PW001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Quinn','Williams','1977-04-16',2,1,'QW002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Sam','Williams','1983-02-12',4,1,'SW004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Tina','Williams','1990-08-20',5,1,'TW005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Uma','Jones','1981-03-28',1,1,'UJ001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Victor','Jones','1979-09-04',2,1,'VJ002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Jones','1992-06-13',3,1,'WJ003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Xander','Jones','1985-01-21',4,1,'XJ004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Yara','Jones','1988-11-09',5,1,'YJ005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Zane','Jones','1980-07-17',1,1,'ZJ001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Amy','Davis','1977-05-25',2,1,'AD002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Brian','Davis','1991-02-02',3,1,'BD003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Cathy','Davis','1984-10-30',4,1,'CD004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ella','Miller','1986-06-06',1,1,'EM001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Frank','Miller','1978-02-14',2,1,'FM002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Grace','Miller','1983-03-03',3,2,'GM003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Hank','Miller','1991-11-11',4,1,'HM004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ivy','Miller','1987-04-29',5,1,'IM005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jack','Wilson','1981-06-06',1,2,'JW001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Karen','Wilson','1976-10-18',2,2,'KW002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Leo','Wilson','1993-01-27',3,1,'LW003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Mia','Wilson','1989-05-05',4,3,'MW004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Oliver','Taylor','1980-12-12',1,1,'OT001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Penny','Taylor','1985-03-23',2,1,'PT002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Quincy','Taylor','1990-07-14',3,1,'QT003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Rita','Taylor','1995-11-05',4,1,'RT004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Steve','Taylor','1982-02-26',5,1,'ST005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Tina','Taylor','1987-06-17',1,1,'TT001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Uma','Taylor','1992-10-08',2,1,'UT002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Vince','Taylor','1979-01-29',3,1,'VT003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Taylor','1984-05-20',4,1,'WT004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Xander','Taylor','1989-09-11',5,1,'XT005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Yara','Taylor','1994-12-02',1,1,'YT001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Zane','Taylor','1981-03-23',2,1,'ZT002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Amy','Anderson','1986-07-14',3,1,'AA001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Brian','Anderson','1991-11-05',4,1,'BA002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Cathy','Anderson','1978-02-26',5,2,'CA003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Derek','Anderson','1983-06-17',1,1,'DA004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ella','Anderson','1988-10-08',2,1,'EA005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Frank','Anderson','1993-01-29',3,1,'FA001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Grace','Anderson','1979-05-20',4,1,'GA002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Hank','Anderson','1984-09-11',5,1,'HA003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Ivy','Anderson','1989-12-02',1,1,'IA004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Jack','Anderson','1994-03-23',2,2,'JA005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Karen','Anderson','1981-07-14',3,1,'KA001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Leo','Anderson','1986-11-05',4,1,'LA002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Mia','Anderson','1991-02-26',5,1,'MA003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Nina','Anderson','1978-06-17',1,1,'NA004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Oscar','Anderson','1983-10-08',2,1,'OA005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Paul','Anderson','1988-01-29',3,1,'PA001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Quinn','Anderson','1993-05-20',4,1,'QA002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Rachel','Anderson','1979-09-11',5,1,'RA003');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Sam','Anderson','1984-12-02',1,3,'SA004');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Tina','Anderson','1989-03-23',2,1,'TA005');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Uma','Anderson','1994-07-14',3,1,'UA001');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Victor','Anderson','1981-11-05',4,1,'VA002');
				INSERT INTO EmployeeData (FirstName,LastName,DateOfBirth,DepartmentId,EmployeeStatusId,EmployeeNumber) VALUES ('Wendy','Anderson','1986-02-26',5,3,'WA003');

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
