DECLARE @BeginScript DATETIME
DECLARE @EndScript DATETIME
DECLARE @Status SMALLINT
DECLARE @Error NVARCHAR(2000)

-- Start Timer
SET @BeginScript = GETDATE()

PRINT 'Script _002_Populate_EmployeeStatus.sql [F745E97E-C3E4-4F42-B508-14D57C02B91B]'

IF NOT EXISTS(SELECT Id FROM ScriptSetupLog WHERE [Code] = 'F745E97E-C3E4-4F42-B508-14D57C02B91B' AND [Status] = 1)
	BEGIN		
		BEGIN TRY
			PRINT 'Script _002_Populate_EmployeeStatus.sql [F745E97E-C3E4-4F42-B508-14D57C02B91B] started.'	
			BEGIN TRANSACTION
			-- ************************************************************************************************************************************
			-- Script goes here
			-- ************************************************************************************************************************************	
				INSERT INTO EmployeeStatus (Name) VALUES ('Approved');
				INSERT INTO EmployeeStatus (Name) VALUES ('Pending');
				INSERT INTO EmployeeStatus (Name) VALUES ('Disabled');
			-- ************************************************************************************************************************************
			-- Script End			
			-- ************************************************************************************************************************************
			SET @Status = 1
			COMMIT TRANSACTION
			PRINT 'Script _002_Populate_EmployeeStatus.sql [F745E97E-C3E4-4F42-B508-14D57C02B91B] ran successfully.'
		END TRY
		BEGIN CATCH
			SET @Status = 2
			SET @Error ='Nr: '+CAST(ERROR_NUMBER() AS NVARCHAR(10))+'| Line: '+CAST(ERROR_LINE() AS NVARCHAR(10))+'| MSG: '+ERROR_MESSAGE()
			ROLLBACK TRANSACTION
			PRINT 'Error in Script _002_Populate_EmployeeStatus.sql [F745E97E-C3E4-4F42-B508-14D57C02B91B]: '+@Error
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
											('F745E97E-C3E4-4F42-B508-14D57C02B91B','_002_Populate_EmployeeStatus.sql', @BeginScript, DATEDIFF(ms, @BeginScript, @EndScript), @Status, @Error)
	END
	ELSE
		PRINT 'Script _002_Populate_EmployeeStatus.sql [F745E97E-C3E4-4F42-B508-14D57C02B91B] was not executed because it already exists.'
GO
PRINT '------------------------------------------------------------------------------------------------------'
GO
