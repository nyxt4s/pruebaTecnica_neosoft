using System.Data;
using MySqlConnector;

namespace MantenedorApi.Data;

public class DapperContext
{
    //realizamos injeccion de dependencias de IConfiguration para obtener la cadena de conexion
    // y asi poder crear una conexion a la base de datos pasandole como parametro el connetion string
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("mariaDbConnection")!;
    }

    public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
}