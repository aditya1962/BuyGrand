USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_addItem]    Script Date: 8/11/2020 6:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/08/11
-- Description:	Stored procedure for retrieving category and subcategory names in seller view 
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getCategories] 
	
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_addItem

		select category,subcategory from dbo.itemCategory;

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
				ROLLBACK TRANSACTION sp_addItem;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH
    
END
