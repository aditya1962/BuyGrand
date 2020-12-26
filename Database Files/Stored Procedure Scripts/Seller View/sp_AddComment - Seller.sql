USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddComment]    Script Date: 12/26/2020 13:13:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/26
-- Description:	Stored procedure for adding a review in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_AddComment]
(
    @itemID int,
    @originalID int,
    @username nvarchar(15),
    @review nvarchar(max)
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
			SAVE TRANSACTION sp_AddComment

    declare @reviewId int, @originalUsername nvarchar(15);
    set @reviewID = (select top(1) reviewId from dbo.review order by reviewId desc);
    set @reviewId = @reviewId + 1;
		IF @originalID=-1
      insert into dbo.review (itemID,originalReviewID,username,originalUsername,message,submittedDate)
        values(@itemID,@reviewID,@username,@username,@review,GETDATE());
    ELSE
      set @originalUsername = (select username from dbo.review where originalReviewID=@originalID);
      insert into dbo.review (itemID,originalReviewID,username,originalUsername,message,submittedDate)
        values(@itemID,@originalID,@username,@originalUsername,@review,GETDATE());

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
				ROLLBACK TRANSACTION sp_AddComment;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
