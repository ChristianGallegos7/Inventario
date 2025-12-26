resource "azurerm_container_app_environment" "my-cg-inventario-eus-acae" {
  name                       = "cg-inventario-${var.env_id}-eus-acae"
  location                   = azurerm_resource_group.my-cg-inventario-dev-eus-rg.location
  resource_group_name        = azurerm_resource_group.my-cg-inventario-dev-eus-rg.name
  log_analytics_workspace_id = azurerm_log_analytics_workspace.cg-inventario-eus-law.id


  tags = {
    environment = var.env_id
    src = var.src_key
  }
}
