using System.Collections.Generic;
using UplaceApi.Models;

namespace UplaceApi.Repository
{
    public class TesteRepository : ITesteRepository
    {
        public readonly string _connectionString;

        public TesteRepository(string connectionString)
        {
            this._connectionString = connectionString; 
        }

        public async Task<IEnumerable<Teste>> ObterTestes()
        {
            List<Teste> testes = [];
            
            // using(MySqlConnection connection = new MySqlConnection(_connectionString))
            // {
            //     connection.Open();

            //     MySqlCommand cmd = new MySqlCommand("select * from testes", connection);
            //     MySqlDataReader reader = await Task.Run(() =>cmd.ExecuteReader());

            //     while (reader.Read())
            //     {
            //         var teste = new Teste(Convert.ToInt32(reader["Id"]), reader["Descricao"].ToString());
            //         testes.Add(teste);
            //     }

            //     connection.Close();
            // }

            return testes;
        }
    }
}
