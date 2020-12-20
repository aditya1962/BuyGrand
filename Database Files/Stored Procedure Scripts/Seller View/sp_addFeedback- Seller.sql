USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_addFeedback]    Script Date: 12/20/2020 10:44:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/20
-- Description:	Stored procedure for adding a feedback in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_addFeedback]
(
    @username nvarchar(15),
    @originalID int,
    @reply nvarchar(max),
    @submittedDate datetime
)
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_addFeedback

    declare @originalUsersname nvarchar(15);

    set @originalUsersname = (select originalUsername from dbo.feedback where originalFeedbackID=@originalID);

		insert into dbo.feedback (originalFeedbackID,username,originalUsername,message,submittedDate)
      values(@originalID,@username,@originalUsersname,@reply,@submittedDate);

		IF @transactionCount=0
			COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH
		DECLARE @errorNo int, @message varchar(max), @xstate int
		SELECT @errorNo = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		IF @transactionCount = 0
			ROLLBACK TRANSACTION;
		ELSE
			IF @xstate = 1
				ROLLBACK TRANSACTION sp_addFeedback;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
