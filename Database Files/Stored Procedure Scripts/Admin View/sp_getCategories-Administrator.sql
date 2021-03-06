USE [BuyGrandAdministrator]
GO
/****** Object:  StoredProcedure [dbo].[sp_getCategories]    Script Date: 5/8/2020 7:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/03/29>
-- Altered date: <2020/05/08>
-- Description:	<Procedure for retrieving categories and their item counts for datatable in BuyGrand Administrator view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getCategories]
	@offset int,
	@rowsToReturn int
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

		create table #getCategories
		(
			category varchar(100),
			subcategoryCount int,
			itemCount int
		);

		create table #TempCategoryList
		(
			rowid int identity(1,1),
			category varchar(15)
		);

		declare @counter int, @rowNum int;
		declare @categoryName varchar(15);
		
		insert into #TempCategoryList
		select distinct category from dbo.itemCategory;

		set @counter = 0;
		set @rowNum = (select count(*) from #TempCategoryList)

		while(@counter <= @rowNum)
		begin
			set @categoryName = (select category from #TempCategoryList where rowid=@counter);
			declare @count int;
			set @count = (select count(*) from #getCategories where category = @categoryName);
			if(@count=0 and @categoryName !='')
			begin
				insert into #getCategories 
				values((@categoryName),
				(select count(subcategory) from dbo.itemCategory where category=@categoryName), 
				(select count(*) from dbo.item inner join dbo.itemCategory on item.categoryID = itemCategory.categoryID
				where itemCategory.category=@categoryName group by dbo.itemCategory.categoryID))
			end
			set @counter = @counter + 1;
		end

		select * from #getCategories
		order by category
		offset @offset rows fetch next @rowsToReturn rows only;

		drop table #getCategories;
		drop table #TempCategoryList;

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
