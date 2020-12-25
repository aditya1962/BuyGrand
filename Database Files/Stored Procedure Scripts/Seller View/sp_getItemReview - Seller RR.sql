USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getItemReview]    Script Date: 12/25/2020 20:06:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/25
-- Description:	Stored procedure for getting item reviews in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getItemReview]
(
    @productId int
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
			SAVE TRANSACTION sp_getItemReview

		select reviewID, message as 'description',
      (select imagePath from dbo.login as l
        inner join dbo.review as r
          on l.username=r.originalUsername),
            submittedDate,
            (select concat(firstName,'',lastName) as 'name'  from dbo.login as l
              inner join dbo.review as r
                on l.username=r.originalUsername),
                (select count(*) as 'subreviewCount'
                  from dbo.review where originalReviewID=reviewID)
                    from dbo.review where itemId=@productId


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
				ROLLBACK TRANSACTION sp_getItemReview;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
