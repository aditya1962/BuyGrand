USE [BuyGrandAdministratorReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getChartDetails]    Script Date: 5/16/2020 4:57:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/05/16>
-- Description:	<Procedure for retrieving data for chart in dashboard in BuyGrand Administrator view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getChartDetails]
(
	@monthRange int	
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
			SAVE TRANSACTION sp_getChartDetails;

		declare @startDate varchar(10);
		declare @endDate varchar(10);
		declare @year int;
		declare @month int;

		set @year = YEAR(GETDATE());
		set @month = MONTH(GETDATE());

		set @endDate = CONCAT(@year,'-',@month,'-',DAY(GETDATE()));

		if(@month < @monthRange)
			begin
				set @year = @year - 1;
				set @month = 12-(@monthRange-@month);
			end
		else
			begin
				set @month = @month - 6;
			end

		set @startDate = CONCAT(@year,'-',@month,'-',1);

		select sum(totalPrice) as 'TotalPrice', cast(year(submittedDate) as varchar(4)) +  '-' + cast(month(submittedDate) as varchar(2)) as 'SubmittedDate'
		from dbo.userReport
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
			ROLLBACK TRANSACTION sp_getChartDetails;

		RAISERROR('sp_getChartDetails: %d: %s',16,1,@error, @message);

	END CATCH
    
END
