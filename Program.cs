using System.Xml.Linq;
using ferreteria.Extensions;
using ferreteria.Models;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Producto> Productos = new List<Producto>(){
            new Producto(){Id = 1, Nombre = "Martillo", PrecioUnit = 10, Cantidad = 20, StockMax = 30, StockMin = 5},
            new Producto(){Id = 2, Nombre = "Metro", PrecioUnit = 13, Cantidad = 10, StockMax = 70, StockMin = 30},
            new Producto(){Id = 3, Nombre = "Tornillo", PrecioUnit = 3, Cantidad = 200, StockMax = 500, StockMin = 100},
            new Producto(){Id = 4, Nombre = "Cautin", PrecioUnit = 15, Cantidad = 20, StockMax = 30, StockMin = 8}
        };
        List<ProductoDetalle> ProductosDetalles = new List<ProductoDetalle>(){};
        foreach (Producto p in Productos){
            var pd = new ProductoDetalle(){Id = p.Id, Cantidad = p.Cantidad, Valor = p.PrecioUnit};
            ProductosDetalles.Add(pd);
        }
        List<Factura> Facturas = new List<Factura>(){
            new Factura(){NFactura = 1, Fecha = new DateOnly(2023, 1, 1), IdCliente = 1, TotalFactura = 20},
            new Factura(){NFactura = 2, Fecha = new DateOnly(2023, 9, 17), IdCliente = 2, TotalFactura = 100},
            new Factura(){NFactura = 3, Fecha = new DateOnly(2019, 2, 2), IdCliente = 3, TotalFactura = 20}
        };
        List<DetalleFactura> DetalleFacturas = new List<DetalleFactura>(){
            new DetalleFactura(){NFactura = Facturas[0].NFactura, ProductosDetalle = new List<ProductoDetalle>{
                ProductosDetalles[0],
                ProductosDetalles[2]
            }},
            new DetalleFactura(){NFactura = Facturas[1].NFactura, ProductosDetalle = new List<ProductoDetalle>{
                ProductosDetalles[1],
                ProductosDetalles[3]
            }},
            new DetalleFactura(){NFactura = Facturas[0].NFactura, ProductosDetalle = new List<ProductoDetalle>{
                ProductosDetalles[2],
                ProductosDetalles[3]
            }}
        };
        Core initCore = new Core();
        while (true){
            Console.Clear();
            initCore.Menu();
            Console.Write("Opcion: ");
            var opcionMenu = Console.ReadLine();
            switch(opcionMenu){
                case "1":
                    initCore.ListarProductos(Productos);
                    initCore.Espera();
                    break;
                case "2":
                    initCore.ListarProductos(initCore.ListarAgotados(Productos));
                    initCore.Espera();
                    break;
                case "3":
                    initCore.ReabastecerProductos(Productos);
                    initCore.Espera();
                    break;
                case "4":
                    initCore.ImprimirFacturaEnero(Facturas);
                    initCore.Espera();
                    break;
                case "5":
                    initCore.ProductosFactura(Facturas, DetalleFacturas);
                    initCore.Espera();
                    break;
                case "6":
                    initCore.TotalInventario(Productos);
                    initCore.Espera();
                    break;
                default:
                    Console.Write("Ingreso un valor no valido...Enter para continuar");
                    Console.ReadLine();
                    break;
                }
            }
        }
}