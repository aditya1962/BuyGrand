USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getChartData]    Script Date: 12/20/2020 8:27:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/12/20>
-- Description:	<Procedure for retrieving data for chart in dashboard in BuyGrand Seller view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getChartData]

AS

BEGIN
	SET NOCOUNT ON;
	DECLARE @trancount int;
	SET @trancount = @@TRANCOUNT;
	BEGIN TRY
		IF @trancount = 0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_getChartData;

		declare @startDate varchar(10);
		declare @endDate varchar(10);
		declare @year int;
		declare @month int;

		set @year = YEAR(GETDATE());
		set @month = MONTH(GETDATE());

		set @endDate = CONCAT(@year,'-',@month,'-',DAY(GETDATE()));

		if(@month < 6)
			begin
				set @year = @year - 1;
				set @month = 12-(6-@month);
			end
		else
			begin
				set @month = @month - 6;
			end

		set @startDate = CONCAT(@year,'-',@month,'-',1);

		select sum(totalPrice) as 'TotalPrice', cast(year(submittedDate) as varchar(4)) +  '-' + cast(month(submittedDate) as varchar(2)) as 'SubmittedDate'
		from dbo.sales
		where submittedDate between @startDate and @endDate
		group by cast(year(submittedDate) as varchar(4)) +  '-' + cast(month(submittedDate) as varchar(2))
		order by cast(year(submittedDate) as varchar(4)) +  '-' + cast(month(submittedDate) as varchar(2));

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
			ROLLBACK TRANSACTION sp_getChartData;

		RAISERROR('sp_getChartData: %d: %s',16,1,@error, @message);

	END CATCH

END
