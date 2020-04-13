USE [BuyGrandAdministrator]
GO
/****** Object:  StoredProcedure [dbo].[sp_viewFeedbacks]    Script Date: 4/12/2020 4:23:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/04/12>
-- Description:	<Procedure for retrieving feedbacks for datatable in BuyGrand Administrator view>
-- =============================================
CREATE PROCEDURE [dbo].[sp_viewFeedbacks]

AS
 
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_viewFeedbacks;

		select feedbackID, feedback.username, message,submittedDate, login.role
		from viewFeedback as feedback inner join login 
		on feedback.username = login.username;

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
			ROLLBACK TRANSACTION sp_viewFeedbacks;

		RAISERROR('sp_viewFeedbacks: %d: %s',16,1,@error, @message);

	END CATCH
    
END
