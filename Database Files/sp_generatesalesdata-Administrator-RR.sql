USE [BuyGrandAdministratorReadReplica]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/03/21>
-- Description:	<Procedure for generating data for Sales Report in BuyGrand Administrator view>
-- =============================================
CREATE PROCEDURE sp_generatesalesdata
	@StartDate nvarchar(50),
	@EndDate nvarchar(50)
AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_generatesalesdata;

		SELECT item.itemID, item.name,item.price, item.orderCount,itemCategory.category, itemCategory.subcategory
		FROM item INNER JOIN itemCategory
		ON item.categoryID = itemCategory.categoryID
		ORDER BY itemCategory.category;

LBEXIT:
		IF @trancount = 0
			COMMIT;
	END TRY
	BEGIN CATCH
		DECLARE @error int, @message varchar(max), @xstate int
		SELECT @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		IF @xstate = -1
			ROLLBACK;
		IF @xstate = 1 and @trancount = 0
			ROLLBACK;
		IF @xstate = 1 and @trancount > 0
			ROLLBACK TRANSACTION sp_generatesalesdata;

		RAISERROR('sp_generatesalesdata: %d: %s',16,1,@error, @message);

	END CATCH
    
END
GO
