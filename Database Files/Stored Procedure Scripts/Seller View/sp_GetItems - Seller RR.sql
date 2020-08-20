USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getItems]    Script Date: 8/20/2020 7:10:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/08/20
-- Description:	Stored procedure for retrieving items in seller view 
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getItems] 
	@offset int,
	@rowsToReturn int
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_getItems

		select description,name,price,imagePath from item
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
				ROLLBACK TRANSACTION sp_getItems;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH
    
END
