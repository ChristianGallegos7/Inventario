resource "azurerm_log_analytics_workspace" "cg-inventario-eus-law" {
  location            = azurerm_resource_group.my-cg-inventario-dev-eus-rg.location
  name                = "cg-inventario-${var.env_id}-eus-law"
  resource_group_name = azurerm_resource_group.my-cg-inventario-dev-eus-rg.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
}
