/****** Script for SelectTopNRows command from SSMS  ******/
use BuyGrandAdministrator;

create index ix_itemCategory_categoryID on dbo.itemCategory(categoryID)
