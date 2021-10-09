using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Laboratorio8.Models;
using System.Data;
using System.Data.SqlClient;

namespace Laboratorio8.Handlers
{
    public class ProductsHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;

        public ProductsHandler()
        {
            rutaConexion = ConfigurationManager.ConnectionStrings["PlanetasConnection"].ToString();
            conexion = new SqlConnection(rutaConexion);
        }

        private DataTable crearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }
        public IEnumerable<ProductsModel> GetAll()
        {
            List<ProductsModel> products = new List<ProductsModel>();
           // 

            string consulta = "SELECT * FROM Products ";
            DataTable tablaResultado = crearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                products.Add(
                new ProductsModel
                {
                    nombre = Convert.ToString(columna["name"]),
                    cantidad = Convert.ToInt32(columna["quantity"]),
                    id = Convert.ToInt32(columna["id"]),
                    precio = Convert.ToInt32(columna["price"])
                });
            }
            IEnumerable<ProductsModel> productsList = products as IEnumerable<ProductsModel>;

            return productsList;
        }
    }
}