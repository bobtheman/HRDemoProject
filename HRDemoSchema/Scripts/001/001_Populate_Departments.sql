DECLARE @BeginScript DATETIME
DECLARE @EndScript DATETIME
DECLARE @Status SMALLINT
DECLARE @Error NVARCHAR(2000)

-- Start Timer
SET @BeginScript = GETDATE()

PRINT 'Script _001_Populate_Departments.sql [9743D1A5-E84A-4330-A221-31C91A0FDB37]'

IF NOT EXISTS(SELECT Id FROM ScriptSetupLog WHERE [Code] = '9743D1A5-E84A-4330-A221-31C91A0FDB37' AND [Status] = 1)
	BEGIN		
		BEGIN TRY
			PRINT 'Script _001_Populate_Departments.sql [9743D1A5-E84A-4330-A221-31C91A0FDB37] started.'	
			BEGIN TRANSACTION
			-- ************************************************************************************************************************************
			-- Script goes here
			-- ************************************************************************************************************************************	
				INSERT INTO Departments (Name) VALUES ('IT');
				INSERT INTO Departments (Name) VALUES ('Sales');
				INSERT INTO Departments (Name) VALUES ('Accounts');
				INSERT INTO Departments (Name) VALUES ('HR');
				INSERT INTO Departments (Name) VALUES ('Admin');
			-- ************************************************************************************************************************************
			-- Script End			
			-- ************************************************************************************************************************************
			SET @Status = 1
			COMMIT TRANSACTION
			PRINT 'Script _001_Populate_Departments.sql [9743D1A5-E84A-4330-A221-31C91A0FDB37] ran successfully.'
		END TRY
		BEGIN CATCH
			SET @Status = 2
			SET @Error ='Nr: '+CAST(ERROR_NUMBER() AS NVARCHAR(10))+'| Line: '+CAST(ERROR_LINE() AS NVARCHAR(10))+'| MSG: '+ERROR_MESSAGE()
			ROLLBACK TRANSACTION
			PRINT 'Error in Script _001_Populate_Departments.sql [9743D1A5-E84A-4330-A221-31C91A0FDB37]: '+@Error
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
											('9743D1A5-E84A-4330-A221-31C91A0FDB37','_001_Populate_Departments.sql', @BeginScript, DATEDIFF(ms, @BeginScript, @EndScript), @Status, @Error)
	END
	ELSE
		PRINT 'Script _001_Populate_Departments.sql [9743D1A5-E84A-4330-A221-31C91A0FDB37] was not executed because it already exists.'
GO
PRINT '------------------------------------------------------------------------------------------------------'
GO
