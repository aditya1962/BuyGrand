USE [BuyGrandAdministratorReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getSubCategories]    Script Date: 4/7/2020 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/04/07>
-- Description:	<Procedure for retrieving subcategories and their item counts for datatable in BuyGrand Administrator view>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getSubCategories]
(
	@category varchar(15)
)
AS
 
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_getSubCategories;

		select ic.categoryID,ic.subcategory,count(itemID) as 'itemCount'
		from dbo.itemCategory ic left join dbo.item i
		on ic.categoryID = i.categoryID
		where ic.category = @category
		group by ic.categoryID, subcategory;

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
			ROLLBACK TRANSACTION sp_getSubCategories;

		RAISERROR('sp_getSubCategories: %d: %s',16,1,@error, @message);

	END CATCH
    
END
