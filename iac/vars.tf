variable "env_id" {
  type        = string
  description = "environment id"
  default     = "dev"
}

variable "sql_pass" {
  type = string
  description = "Sql server pass"

}

variable "location" {
  type        = string
  description = "Resource location"
  default     = "East US"
}

variable "location2" {
  type = string
  description = "Resource location"
  default = "East US 2"
}

variable "src_key" {
  type        = string
  description = "Infraestructure key"
  default     = "terraform"
}




















variable "subscription_id" {
  type        = string
  description = "Azure subscription id"
  default     = "efcd7ee6-9405-4933-8151-e85050696985"
}

