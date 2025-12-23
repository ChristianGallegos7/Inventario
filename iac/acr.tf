resource "azurerm_container_registry" "acr" {

  location                      = azurerm_resource_group.my-cg-inventario-dev-eus-rg.location
  name                          = "cginventario${var.env_id}eusacr"
  resource_group_name           = azurerm_resource_group.my-cg-inventario-dev-eus-rg.name
  sku                           = "Standard"
  admin_enabled                 = true
  public_network_access_enabled = true

  tags = {
    environment = var.env_id
    src         = var.src_key
  }
}
