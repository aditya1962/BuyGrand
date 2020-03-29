USE [BuyGrandAdministratorReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getCategories]    Script Date: 3/29/2020 6:32:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/03/29>
-- Description:	<Procedure for retrieving categories and their item counts for datatable in BuyGrand Administrator view>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getCategories]
	@category varchar(15)
AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_getCategories;

		select categoryID, category, count(subcategory) as 'subcategoryCount', 
		(select count(*) from dbo.item inner join dbo.itemCategory on item.categoryID = itemCategory.categoryID
		where itemCategory.category=@category group by dbo.itemCategory.categoryID) as 'itemCount' from dbo.itemCategory
		group by itemCategory.category, itemCategory.categoryID;

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
			ROLLBACK TRANSACTION sp_getCategories;

		RAISERROR('sp_getCategories: %d: %s',16,1,@error, @message);

	END CATCH
    
END
