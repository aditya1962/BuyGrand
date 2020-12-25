USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteProduct]    Script Date: 12/25/2020 19:51:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/25
-- Description:	Stored procedure for deleting product details in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_deleteProduct]
(
    @productVal int
)
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_deleteProduct

		delete from dbo.item
      where itemID=@productVal;


		IF @transactionCount=0
			COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH
		DECLARE @errorNo int, @message varchar(max), @xstate int
		SELECT @errorNo = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		IF @transactionCount = 0
			ROLLBACK TRANSACTION;
		ELSE
			IF @xstate = 1
				ROLLBACK TRANSACTION sp_deleteProduct;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
