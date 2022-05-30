using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class EstadoDAL
    {
        public EstadoDAL()
        {

        }

        public List<Estado> GetEstado(int? estadoId = null)
        {
            List<Estado> estados = new List<Estado>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Id,
                                NomeEstado,
                                UF,
                                Pais
                        FROM Estado");

            if (estadoId != null)
                sql.AppendFormat(@"WHERE Id={0}", estadoId.Value);



            return estados;
        }

    }
}
