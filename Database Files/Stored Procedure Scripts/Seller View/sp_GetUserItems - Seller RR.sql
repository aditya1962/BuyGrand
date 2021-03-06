USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getUserItems]    Script Date: 10/5/2020 3:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/10/05
-- Description:	Stored procedure for retrieving items in seller view 
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getUserItems] 
	@offset int,
	@rowsToReturn int,
	@username varchar(15)
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_getUserItems

		select itemID,description,name,price,imagePath from item
		where username = @username
		order by itemID
		offset @offset rows fetch next @rowstoreturn rows only;

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
				ROLLBACK TRANSACTION sp_getUserItems;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH
    
END
