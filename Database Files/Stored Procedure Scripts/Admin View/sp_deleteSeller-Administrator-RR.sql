USE [BuyGrandAdministratorReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteSeller]    Script Date: 5/7/2020 4:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/05/07>
-- Description:	<Procedure for delete a seller in BuyGrand Administrator view>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteSeller]
	@username varchar(15)
AS
BEGIN	
	SET NOCOUNT OFF;
	DECLARE @trancount int,@rows int;
	SET @trancount = @@TRANCOUNT;
	SET @rows = 0;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_deleteSeller;

		delete from dbo.loggedUser where username=@username;
		SET @rows = @rows + 1;
		delete from dbo.feedbackAdmin where username=@username;
		SET @rows = @rows + 1;
		delete from dbo.login where username=@username;
		SET @rows = @rows + 1;
		

LBEXIT:
		IF @trancount = 0
			COMMIT;
			return @rows;		
	END TRY
	BEGIN CATCH
		DECLARE @error int, @message varchar(max), @xstate int
		SELECT @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		IF @xstate = -1
			ROLLBACK;
		IF @xstate = 1 and @trancount = 0
			ROLLBACK;
		IF @xstate = 1 and @trancount > 0
			ROLLBACK TRANSACTION sp_deleteSeller;

		RAISERROR('sp_deleteSeller: %d: %s',16,1,@error, @message);

	END CATCH
    
END
