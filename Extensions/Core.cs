using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ferreteria.Models;

namespace ferreteria.Extensions
{
    public class Core
    {
        public void Menu(){
            Console.WriteLine("                 FERRETERIA\n");
            Console.WriteLine(" 1. LISTAR LOS PRODUCTOS DEL INVENTARIO");
            Console.WriteLine(" 2. LISTAR LOS PRODUCTOS QUE ESTAN A PUNTO DE AGOTARSE. CANTIDAD<STOCKMIN");
            Console.WriteLine(" 3. LISTAR LOS PRODUCTOS QUE SE DEBEN COMPRAR Y QUE CANTIDAD DE DEBE COMPRAR LA CANTIDAD A COMPRAR SE OBTIENE TENIENDO EN CUENTA LA DIFERENCIA ENTRE LA CANTIDAD Y EL STOCKMAX.");
            Console.WriteLine(" 4. LISTAR EL TOTAL DE FACTURAS DEL MES DE ENERO DEL 2023");
            Console.WriteLine(" 5. LISTAR LOS PRODUCTOS VENDIDOS EN UNA DETERMINADA FACTURA");
            Console.WriteLine(" 6. CALCULAR EL VALOR TOTAL DEL INVENTARIO");
        }
        public void ListarProductos(List<Producto> productos){
            Console.Clear();
            var lista = productos.OrderBy(x => x.Id).ToList();
            foreach (Producto p in lista){
                Console.WriteLine($"{p.Nombre}");
                Console.WriteLine($"    Id : {p.Id}");
                Console.WriteLine($"    PrecioUnit : {p.PrecioUnit}");
                Console.WriteLine($"    Cantidad : {p.Cantidad}");
                Console.WriteLine($"    StockMin : {p.StockMin}");
                Console.WriteLine($"    StockMax : {p.StockMax}");
            }
        }
        public List<Producto> ListarAgotados(List<Producto> productos){
            Console.Clear();
            var agotados = productos.Where(x => x.Cantidad < x.StockMin).ToList();                                                                                                           
            return agotados;
        }
        public void ReabastecerProductos(List<Producto> productos){
            Console.Clear();
            var agotados = ListarAgotados(productos);
            var reabastecer = new List<ProductoReabastecer>();
            foreach (Producto p in agotados){
                int cantidadReabastecer = p.StockMax - p.Cantidad;
                var productoReabastecer = new ProductoReabastecer(){
                    Id = p.Id,
                    PrecioUnit = p.PrecioUnit,
                    Cantidad = p.Cantidad,
                    StockMax = p.StockMax,
                    CantidadReabastecer = cantidadReabastecer
                };
                reabastecer.Add(productoReabastecer);
            }
            var lista = reabastecer.OrderBy(x => x.Id).ToList();
            foreach (ProductoReabastecer p in lista){
                Console.WriteLine($"{p.Nombre}");
                Console.WriteLine($"    Id : {p.Id}");
                Console.WriteLine($"    PrecioUnit : {p.PrecioUnit}");
                Console.WriteLine($"    Cantidad : {p.Cantidad}");
                Console.WriteLine($"    StockMax : {p.StockMax}");
                Console.WriteLine($"    CantidadReabastecer : {p.CantidadReabastecer}");
            }
        }
        public void ImprimirFacturaEnero(List<Factura> facturas){
            Console.Clear();
            var facturasenero = facturas.Where(x => x.Fecha.Month == 1);
            foreach (Factura f in facturasenero){
                Console.WriteLine($"    NFactura : {f.NFactura}");
                Console.WriteLine($"    Fecha : {f.Fecha}");
                Console.WriteLine($"    IdCliente : {f.IdCliente}");
                Console.WriteLine($"    TotalFactura : {f.TotalFactura}");
            }
        }
        public void ProductosFactura(List<Factura> facturas, List<DetalleFactura> detallefacturas){
            Console.Clear();
            foreach (Factura f in facturas){
                Console.WriteLine($"Factura {f.NFactura}");
            }
            Console.Write("Numero Factura: ");
            var nfactura = Console.ReadLine();
            Console.Clear();
            var whereFactura = facturas.Where(x => x.NFactura == int.Parse(nfactura));
            
            if (whereFactura.Count() > 0){
                foreach (Factura f in whereFactura){
                    Console.WriteLine($"    NFactura : {f.NFactura}");
                    Console.WriteLine($"    Fecha : {f.Fecha}");
                    Console.WriteLine($"    IdCliente : {f.IdCliente}");
                    Console.WriteLine($"    TotalFactura : {f.TotalFactura}");
                    Console.WriteLine("     Productos");
                    foreach(ProductoDetalle p in detallefacturas[int.Parse(nfactura)].ProductosDetalle){
                        Console.WriteLine($"        Cantidad : {p.Cantidad}");
                        Console.WriteLine($"        Fecha : {p.Valor}");
                    }
            }
            }
        }
        public void TotalInventario(List<Producto> productos)
        {
            Console.Clear();
            int total = 0;
            foreach(Producto p in productos){
                total += p.Cantidad * p.PrecioUnit;
            }
            Console.WriteLine($"Total Inventario: {total}");
        }
        public void Espera(){
            Console.Write("Enter para continuar");
            Console.ReadKey();
        }
    }
}