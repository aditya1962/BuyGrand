USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getFeedbacks]    Script Date: 12/20/2020 10:20:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/20
-- Description:	Stored procedure for retrieving feedbacks in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getFeedbacks]
(
    @username nvarchar(15)
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
			SAVE TRANSACTION sp_getFeedbacks

		select concat(firstName,' ', lastName) as 'username', feedbackID, message, submittedDate
      from dbo.login l inner join dbo.feedback f
        on l.username=f.username
          where f.username=@username;

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
				ROLLBACK TRANSACTION sp_getFeedbacks;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
