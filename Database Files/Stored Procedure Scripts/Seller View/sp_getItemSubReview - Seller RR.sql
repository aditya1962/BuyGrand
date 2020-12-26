USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getItemSubReview]    Script Date: 12/26/2020 13:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/26
-- Description:	Stored procedure for getting item sub reviews in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getItemSubReview]
(
    @productId int,
    @reviewID int
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
			SAVE TRANSACTION sp_getItemSubReview

		select reviewID, message as 'description',
      (select imagePath from dbo.login as l
        inner join dbo.review as r
          on l.username=r.originalUsername),
            submittedDate,
            (select concat(firstName,'',lastName) as 'name'  from dbo.login as l
              inner join dbo.review as r
                on l.username=r.originalUsername)
                    from dbo.review where itemId=@productId and originalReviewID=@reviewId;


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
				ROLLBACK TRANSACTION sp_getItemSubReview;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
