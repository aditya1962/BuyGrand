USE [BuyGrandAdministratorReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getDashboardValues]    Script Date: 5/15/2020 7:17:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/05/15>
-- Description:	<Procedure for generating data for dashboard in BuyGrand Administrator view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getDashboardValues]

AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE 
			SAVE TRANSACTION sp_getDashboardValues;

		declare @users int;
		declare @sellers int;
		declare @items int;
		declare @categories int;
		declare @subcategories int;
		declare @orders int;
		declare @sales numeric(10,2);

		set @sales = 0.0;

		set @users = (select count(username) from dbo.login where role='user' and activated=1);
		set @sellers = (select count(username) from dbo.login where role='seller' and activated=1);
		set @items = (select count(itemID) from dbo.item where available=1);
		set @categories = (select count(distinct category) from dbo.itemCategory);
		set @subcategories = (select count(subcategory) from dbo.itemCategory);
		set @orders = (select count(rowID) from dbo.userReport);
		if(@orders > 0)
			set @sales = (select sum(totalPrice) from dbo.userReport);

		create table #dashboard
		(
			users int,
			sellers int,
			items int,
			categories int,
			subcategories int,
			orders int,
			sales numeric(10,2)
		);

		insert into #dashboard
		values(@users,@sellers,@items,@categories,@subcategories,@orders,@sales);

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
			ROLLBACK TRANSACTION sp_getDashboardValues;

		RAISERROR('sp_getDashboardValues: %d: %s',16,1,@error, @message);

	END CATCH
    
END
