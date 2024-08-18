using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Vuelos.DataBase
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("vuelos");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public async Task<List<T>> ExecuteStoredProcedureAsync<T>(string spName, Dictionary<string, object> parameters) where T : class, new()
        {
            // Crear la conexión
            using var connection = new SqlConnection(_configuration.GetConnectionString("vuelos"));
            await connection.OpenAsync();

            // Crear el comando
            using var command = new SqlCommand(spName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parámetros al comando
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            // Ejecutar el comando y leer los resultados
            using var reader = await command.ExecuteReaderAsync();
            var results = new List<T>();

            while (await reader.ReadAsync())
            {
                var item = new T();
                var properties = typeof(T).GetProperties();

                foreach (var property in properties)
                {
                    if (reader.HasRows && reader[property.Name] != DBNull.Value)
                    {
                        property.SetValue(item, reader[property.Name]);
                    }
                }

                results.Add(item);
            }

            return results;
        }
    }
}
