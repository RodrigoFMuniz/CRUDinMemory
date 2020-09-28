using CrudComAdo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudComAdo.Repositories
{
    public class AutorRepository
    {
        private static string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADSL20N3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<AutorModel> Autores { get; } = new List<AutorModel>();
        public async Task<IEnumerable<AutorModel>> GetAllAsync()
        {
            const string commandText = "select Id, Nome, UltimoNome, Nascimento from Autor"; //Comando SQL
            await using var sqlConnection = new SqlConnection(_connectionString);//Instância da conector  
            await using var sqlCommand = new SqlCommand(commandText, sqlConnection)//Instância do comando
            {
                CommandType = CommandType.Text // Tipo do comando
            };              

            await sqlConnection.OpenAsync(); // Abertura da conexão

            var reader = await sqlCommand.ExecuteReaderAsync(); // Captura dos dados de apresentação (capturados via Select)

            var autores = new List<AutorModel>();//Lista para armazenamento das informações vindas do DB

            while (await reader.ReadAsync())
            {
                var id = await reader.GetFieldValueAsync<int>("Id");
                var nome = await reader.GetFieldValueAsync<string>("Nome");
                var ultimoNome = await reader.GetFieldValueAsync<string>("UltimoNome");
                var nascimento = await reader.GetFieldValueAsync<DateTime>("Nascimento");

                var autorModel = new AutorModel
                {
                    Id = id,
                    Nome = nome,
                    UltimoNome = ultimoNome,
                    Nascimento = nascimento
                };
                autores.Add(autorModel);
            }
            return autores;

        }
        public async Task<AutorModel> GetByIdAsync(int id)
        {
            const string commandText = "select Id, Nome, UltimoNome, Nascimento from Autor where Id = @id"; //Comando SQL
            await using var sqlConnection = new SqlConnection(_connectionString);//Instância da conector  
            await using var sqlCommand = new SqlCommand(commandText, sqlConnection);//Instância do comando

            sqlCommand.CommandType = CommandType.Text;

            sqlCommand.Parameters.Add("@id",SqlDbType.Int).Value=id;

            
            await sqlConnection.OpenAsync();

            var reader = await sqlCommand.ExecuteReaderAsync(); // Captura dos dados de apresentação (capturados via Select)

            var canRead = await reader.ReadAsync();
            if (!canRead)
            {
                return null;
            }

            var autor = new AutorModel
            {
                 Id = await reader.GetFieldValueAsync<int>(0),
                 Nome = await reader.GetFieldValueAsync<string>(1),
                 UltimoNome = await reader.GetFieldValueAsync<string>(2),
                 Nascimento = await reader.GetFieldValueAsync<DateTime>(3)
            };
                       
            return autor;
        }       
        public void Add(AutorModel autorModel)
        {
            Autores.Add(autorModel);
        }
        public async Task RemoveAsync(AutorModel autorModel)
        {
            var autorInMemory = await GetByIdAsync(autorModel.Id);
            Autores.Remove(autorInMemory);
        }
        public async Task Edit(AutorModel autorModel)
        {
            var autorInMemory = await GetByIdAsync(autorModel.Id);
            autorInMemory.Nome = autorModel.Nome;
            autorInMemory.UltimoNome = autorModel.UltimoNome;
            autorInMemory.Nascimento = autorModel.Nascimento;
        }
    }
}
