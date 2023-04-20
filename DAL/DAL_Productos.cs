using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Productos
    {
        public static List<vProducto> vProductos(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = (from tblProducto in bd.Productos
                                join tblCategoria in bd.Categorias on tblProducto.IdCategoria equals tblCategoria.IdCategoria
                                where tblProducto.Activo == Activo && tblCategoria.Activo == Activo
                                select new vProducto
                                {
                                    IdProducto = tblProducto.IdProducto,
                                    CodigoBarra = tblProducto.CodigoBarra,
                                    Descripcion = tblProducto.Descripcion,
                                    Marca = tblProducto.Marca,
                                    IdCategoria = tblProducto.IdCategoria,
                                    Categoria = tblCategoria.Categoria,
                                    Stock = tblProducto.Stock,
                                    Precio = tblProducto.Precio,
                                }).ToList();
                return Consulta;
            }
        }
        public static vProducto vproducto(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = (from tblProducto in bd.Productos
                                join tblCategoria in bd.Categorias on tblProducto.IdCategoria equals tblCategoria.IdCategoria
                                where tblProducto.Activo == true && tblCategoria.Activo == true && tblProducto.IdProducto == IdRegistro
                                select new vProducto
                                {
                                    IdProducto = tblProducto.IdProducto,
                                    CodigoBarra = tblProducto.CodigoBarra,
                                    Descripcion = tblProducto.Descripcion,
                                    Marca = tblProducto.Marca,
                                    IdCategoria = tblProducto.IdCategoria,
                                    Categoria = tblCategoria.Categoria,
                                    Stock = tblProducto.Stock,
                                    Precio = tblProducto.Precio,
                                }).SingleOrDefault();
                return Consulta;
            }
        }
    }
}
