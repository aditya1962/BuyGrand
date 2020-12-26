USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getSales]    Script Date: 12/26/2020 14:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Aditya Abeysinghe>
-- Create date: <2020/12/26>
-- Description:	<Procedure for generating data for Sales Report in BuyGrand Seller view>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_getSales]
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
			SAVE TRANSACTION sp_getSales;

		SELECT * FROM dbo.sales
		where submittedDate between @StartDate and @EndDate
		order by submittedDate;

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
			ROLLBACK TRANSACTION sp_getSales;

		RAISERROR('sp_getSales: %d: %s',16,1,@error, @message);

	END CATCH

END
