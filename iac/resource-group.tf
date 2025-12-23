resource "azurerm_resource_group" "my-cg-inventario-dev-eus-rg" {

  location = var.location
  name     = "cg-inventario-dev-eus-rg"

  tags = {
    environment = var.env_id
    src         = var.src_key
  }
}
