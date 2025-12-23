resource "azurerm_container_app" "cg-inventario-eus-aca" {
  name                         = "cg-inventario-${var.env_id}-eus-aca"
  container_app_environment_id = azurerm_container_app_environment.my-cg-inventario-eus-acae.id
  resource_group_name          = azurerm_resource_group.my-cg-inventario-dev-eus-rg.name
  revision_mode                = "Multiple"

  template {
    min_replicas = 1
    max_replicas = 3
    container {
      name   = "cg-inventario-dev-eus-app"
      cpu    = 0.25
      memory = "0.5Gi"
      image  = "mcr.microsoft.com/k8se/quickstart:latest"
    }
  }

  ingress {
    allow_insecure_connections = false
    external_enabled          = true
    target_port = 8080
    traffic_weight {
      percentage = 100
    }
  }

}
