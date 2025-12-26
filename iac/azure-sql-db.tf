resource "azurerm_mssql_server" "sql_server" {
  location                     = var.location2
  name                         = "cg-inventario-dev-eus-sqlserver-main"
  resource_group_name          = azurerm_resource_group.my-cg-inventario-dev-eus-rg.name
  version                      = "12.0"
  administrator_login          = "nuadmin"
  administrator_login_password = var.sql_pass

  tags = {
    environment = var.env_id
    src         = var.src_key
  }
}


resource "azurerm_mssql_database" "db" {
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 2
  sku_name       = "Basic"
  zone_redundant = false
  name           = "cg-inventario-${var.env_id}-eus-sqldb"
  server_id      = azurerm_mssql_server.sql_server.id

  lifecycle {
    prevent_destroy = false
  }

  tags = {
    environment = var.env_id
    src         = var.src_key
  }
}

resource "azurerm_mssql_firewall_rule" "sql-rule" {
  start_ip_address = "0.0.0.0"
  end_ip_address = "0.0.0.0"
  server_id = azurerm_mssql_server.sql_server.id
  name = "cg-inventario-${var.env_id}-eus-sqlserver-rule"
}
