using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class PedidoDAL : BaseDAL
    {
        public PedidoDAL()
        {

        }

        public List<Pedido> GetPedidoByClienteOrFuncionario(int? clienteId, int? funcionarioId)
        {
            if (funcionarioId is null || clienteId is null)
                return null;

            List<Pedido> pedidos = new List<Pedido>();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT Id,
                                    DtPedido,
                                    QtdFilme,
                                    ValorTotal,
                                    FuncionarioId,
                                    ClienteId
                                FROM Pedido 
                                WHERE ");

            if (funcionarioId != null && clienteId != null)
                sql.AppendFormat(@"FuncionarioId = {0} AND ClienteId = {1}", funcionarioId, clienteId);
            else if (clienteId != null)
                sql.AppendFormat("ClienteId = {0}", clienteId);
            else if (funcionarioId != null)
                sql.AppendFormat(@"FuncionarioId = {0}", funcionarioId);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var pedido = new Pedido();
                pedido.Id = Convert.ToInt32(row["Id"]);
                pedido.DtPedido = Convert.ToDateTime(row["DtPedido"]);
                pedido.QtdFilme = Convert.ToInt32(row["QtdFilme"]);
                pedido.ValorTotal = Convert.ToDouble(row["ValorTotal"]);
                pedido.FuncionarioId = Convert.ToInt32(row["FuncionarioId"]);
                pedido.ClienteId = Convert.ToInt32(row["ClienteId"]);

                pedidos.Add(pedido);
            }

            return pedidos;
        }

        public List<Pedido> GetAllPedido(DateTime? dtPedido)
        {
            List<Pedido> pedidos = new List<Pedido>();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT Id,
                                    DtPedido,
                                    QtdFilme,
                                    ValorTotal,
                                    FuncionarioId,
                                    ClienteId
                                FROM Pedido ");


            if (dtPedido != null)
                sql.AppendFormat(@"WHERE DtPedido = {0}", dtPedido);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var pedido = new Pedido();
                pedido.Id = Convert.ToInt32(row["Id"]);
                pedido.DtPedido = Convert.ToDateTime(row["DtPedido"]);
                pedido.QtdFilme = Convert.ToInt32(row["QtdFilme"]);
                pedido.ValorTotal = Convert.ToDouble(row["ValorTotal"]);
                pedido.FuncionarioId = Convert.ToInt32(row["FuncionarioId"]);
                pedido.ClienteId = Convert.ToInt32(row["ClienteId"]);

                pedidos.Add(pedido);
            }

            return pedidos;
        }

        public int InserirPedido(Pedido pedido)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Pedido 
                                (DtPedido, QtdFilme, ValorTotal, ClienteId, FuncionarioId)
                                VALUES ({0}, {1}, {2}, {3}, {4})", 
                               pedido.DtPedido,
                               pedido.QtdFilme,
                               pedido.ValorTotal,
                               pedido.ClienteId,
                               pedido.FuncionarioId);

            return ExecuteScalar(sql);
        }

        public bool UpdatePedido(Pedido pedido)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Pedido 
                                SET DtPedido={0}, 
                                    QtdFilme={1},
                                    ValorTotal={2},
                                    ClienteId={3},
                                    FuncionarioId={4}
                                WHERE Id={5}",
                                pedido.DtPedido,
                                pedido.QtdFilme,
                                pedido.ValorTotal,
                                pedido.ClienteId,
                                pedido.FuncionarioId,
                                pedido.Id);

            return ExecuteNonQuery(sql);
        }

    }
}
