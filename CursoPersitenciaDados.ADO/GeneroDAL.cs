using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class GeneroDAL : BaseDAL
    {
        public GeneroDAL()
        {

        }

        public List<Genero> GetAll()
        {
            var generos = new List<Genero>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Id, NomeGenero FROM Genero");

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                Genero genero = new Genero();
                genero.Id = Convert.ToInt32(row["Id"]);
                genero.NomeGenero = row["NomeGenero"].ToString();

                generos.Add(genero);
            }

            return generos;
        }

        public Genero GetAll(int id)
        {
            Genero genero = new Genero();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT Id, NomeGenero FROM Genero WHERE Id={0}", id);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                genero.Id = Convert.ToInt32(row["Id"]);
                genero.NomeGenero = row["NomeGenero"].ToString();
            }

            return genero;
        }

        public int InserirGenero(Genero genero)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Genero (NomeGenero) VALUES('{0'})",genero.NomeGenero);

            return ExecuteScalar(sql);
        }

        public bool UpdateGenero(Genero genero)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Genero SET NomeGenero={0} WHERE Id={1}",
                            genero.NomeGenero,genero.Id);
            return ExecuteNonQuery(sql);
        }

    }
}
