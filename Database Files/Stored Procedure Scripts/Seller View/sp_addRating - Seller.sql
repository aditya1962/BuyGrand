USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_addRatings]    Script Date: 12/25/2020 18:05:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/25
-- Description:	Stored procedure for adding a rating for a product in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_addRatings]
(
    @id int,
    @rating int
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
			SAVE TRANSACTION sp_addRatings

    declare @ratingOld numeric(3,2), @ratingCount int, @ratingTotal numeric(3,2), @ratingNew numeric(3,2);
    set @ratingOld = (select rating from dbo.item where itemID=@id);
    set @ratingCount = (select ratingCount from dbo.item where itemID=@id);
    set @ratingTotal = @ratingOld * @ratingCount;
    set @ratingNew = (@ratingTotal + @rating)/(@ratingCount + 1);

		update dbo.item set rating=@ratingNew where itemID = @id;
    update dbo.item set ratingCount=(@ratingCount+1) where itemID = @id;

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
				ROLLBACK TRANSACTION sp_addRatings;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
