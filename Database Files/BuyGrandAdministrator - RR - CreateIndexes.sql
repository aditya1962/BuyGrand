/****** Script for SelectTopNRows command from SSMS  ******/
use BuyGrandAdministratorReadReplica;

create index ix_itemCategory_categoryID on dbo.itemCategory(categoryID)
