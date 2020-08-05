use BuyGrandAdministratorReadReplica;

create index ix_itemCategory_categoryID on dbo.itemCategory(categoryID);
create index ix_itemCategory_category on dbo.itemCategory(category);
