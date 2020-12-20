USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getDashboardData]    Script Date: 12/20/2020 8:12:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/12/20>
-- Description:	<Procedure for generating data for dashboard in BuyGrand Seller view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getDashboardData]

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_getDashboardData;

		declare @items int;
		declare @categories int;
		declare @subcategories int;
		declare @orders int;
		declare @sales numeric(10,2);

		set @sales = 0.0;

		set @items = (select count(itemID) from dbo.item where available=1);
		set @categories = (select count(distinct category) from dbo.itemCategory);
		set @subcategories = (select count(subcategory) from dbo.itemCategory);
		set @orders = (select count(numberOfItems) from dbo.sales);
		if(@orders > 0)
			set @sales = (select sum(totalPrice) from dbo.sales);

		create table #dashboard
		(
			items int,
			categories int,
			subcategories int,
			orders int,
			sales numeric(10,2)
		);

		insert into #dashboard
		values(@items,@categories,@subcategories,@orders,@sales);

		select * from #dashboard;

		drop table #dashboard;

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
			ROLLBACK TRANSACTION sp_getDashboardData;

		RAISERROR('sp_getDashboardData: %d: %s',16,1,@error, @message);

	END CATCH

END
