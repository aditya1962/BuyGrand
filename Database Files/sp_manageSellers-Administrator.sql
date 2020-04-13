USE [BuyGrandAdministrator]
GO
/****** Object:  StoredProcedure [dbo].[sp_manageSellers]    Script Date: 4/13/2020 7:35:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/04/13>
-- Description:	<Procedure for generating data for manage sellers in BuyGrand Administrator view>
-- =============================================
CREATE PROCEDURE [dbo].[sp_manageSellers]

AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_manageSellers;

		select lu.username, firstName, lastName, country, gender, emailAddress 
		from dbo.loggedUser lu inner join dbo.login l
		on lu.username = l.username
		where l.role = 'seller';

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
			ROLLBACK TRANSACTION sp_manageSellers;

		RAISERROR('sp_manageSellers: %d: %s',16,1,@error, @message);

	END CATCH
    
END
