USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_editProduct]    Script Date: 12/25/2020 19:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/25
-- Description:	Stored procedure for editing product details in seller view
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_editProduct]
(
    @productVal int,
    @category nvarchar(100),
    @subcategory nvarchar(100),
    @name nvarchar(90),
    @description nvarchar(500),
    @price numeric(10,2),
    @discount numeric(7,2),
    @quantity int,
    @filePath nvarchar(200)
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
			SAVE TRANSACTION sp_editProduct

		declare @categoryID int;
    set @categoryID = (select categoryID from dbo.item where itemID=@productVal);

    update dbo.item set name=@name, description=@description, price=@price, discount=@discount,
      quantity=@quantity, imagePath=@filePath
        where itemID=@productVal;

    update dbo.itemCategory set category=@category, subcategory=@subcategory
      where categoryID=@categoryID;


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
				ROLLBACK TRANSACTION sp_editProduct;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
