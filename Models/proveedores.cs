using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.Models;
public class Proveedor
{
    public int IdProveedor { get; set; }
    public string Nit { get; set; }
    public string Proveedor { get; set; }
    public string Direccion { get; set; }
    public string RazonSocial { get; set; }
    public DateTime FechaCreacion { get; set; }
}