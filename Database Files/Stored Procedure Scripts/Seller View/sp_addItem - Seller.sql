use BuyGrandSeller;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/08/05
-- Description:	Stored procedure for adding an item in seller view 
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_addItem] 
	@description varchar(200),
	@name varchar(50),
	@price numeric(5,2),
	@imagePath varchar(100),
	@quantityAvailable int,
	@categoryName varchar(15),
	@subcategoryName varchar(15)
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

		DECLARE @itemID int, @categoryID int, @rows int;
		SELECT @itemID = (select top(1) itemID from dbo.item order by itemID desc);
		SET @itemID = @itemID + 1;
		SET @rows = 0;
		SELECT @categoryID = (select categoryID from dbo.itemCategory where category=@categoryName and subcategory=@subcategoryName);


		insert into dbo.item(itemID,description,name,price,imagePath,quantityAvailable,categoryID)
					values(@itemID,@description,@name,@price,@imagePath,@quantityAvailable,@categoryID);
		SET @rows = @rows + 1;

		IF @transactionCount=0
			COMMIT TRANSACTION;
			return @rows;
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
GO
