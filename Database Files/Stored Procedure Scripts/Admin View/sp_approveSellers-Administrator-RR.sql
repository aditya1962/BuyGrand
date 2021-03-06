USE [BuyGrandAdministratorReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_approveSellers]    Script Date: 5/11/2020 11:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/04/10>
-- Modified date: <2020/05/11>
-- Description:	<Procedure for generating data for approving sellers in BuyGrand Administrator view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_approveSellers]
(
	@offset int,
	@rowsToReturn int
)

AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_approveSellers;

		select lu.username, firstName, lastName, country, gender, emailAddress 
		from dbo.loggedUser lu inner join dbo.login l
		on lu.username = l.username
		where l.activated = 0 and l.role = 'seller'
		order by lu.username
		offset @offset rows fetch next @rowsToReturn rows only;

LBEXIT:
		IF @trancount = 0
			COMMIT;
	END TRY
	BEGIN CATCH
		DECLARE @error int, @message varchar(max), @xstate int
		SELECT @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		IF @xstate = -1
			ROLLBACK;
		IF @xstate = 1 and @trancount = 0
			ROLLBACK;
		IF @xstate = 1 and @trancount > 0
			ROLLBACK TRANSACTION sp_approveSellers;

		RAISERROR('sp_approveSellers: %d: %s',16,1,@error, @message);

	END CATCH
    
END
