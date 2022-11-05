resource "aws_security_group" "Joan-Bency-Monitoring" {
  name        = "Joan-Bency-Monitoring"
  description = "allow ssh and http traffic"

  ingress
    {
      from_port   = 22
      to_port     = 22
      protocol    = "tcp"
      cidr_blocks = "0.0.0.0/0"
    },
    ingress
    {
      from_port   = 8080
      to_port     = 8080
      protocol    = "tcp"
      cidr_blocks = "0.0.0.0/0"
    }
}