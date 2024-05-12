using System.IO;
using Microsoft.Data.Sqlite;

namespace prod_keyValueHelper.data;

public class Database
{
    private string _combinedPath;
    private string _connectionString;
    private SqliteConnection _connection;

    public Database()
    {
        var fileUtils = new FileUtils();
        var _path = fileUtils.GetFileUtils();
        _combinedPath = Path.Combine(_path._projectPath, "data", "database.db");
        _connectionString = $"Data Source={_combinedPath}";
    }


    public async Task<SqliteConnection> OpenConnectionAsync()
    {
        _connection = new SqliteConnection(_connectionString);
        await _connection.OpenAsync();
        return _connection;
    }

    public void CloseConnection()
    {
        if (_connection?.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

    public SqliteCommand ExecuteQuery(string query)
    {
        SqliteCommand command = new SqliteCommand(query, _connection);
        return command;
    }

    public async void InitDatabase()
    {
        using (var conn = await OpenConnectionAsync())
        {
            var cmd = new SqliteCommand(
                "CREATE TABLE IF NOT EXISTS data (id INTEGER PRIMARY KEY AUTOINCREMENT, key TEXT, value TEXT);", conn);
            cmd.ExecuteNonQuery();
        }
    }

    public async Task<int> InsertData(string key, string value)
    {
        using (var conn = await OpenConnectionAsync())
        {
            var cmd = new SqliteCommand("INSERT INTO data (key, value) VALUES (@key, @value);", conn);
            cmd.Parameters.AddWithValue("@key", key);
            cmd.Parameters.AddWithValue("@value", value);
            return await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task<string> FindData(string key)
    {
        using (var conn = await OpenConnectionAsync())
        {
            var cmd = new SqliteCommand("SELECT value FROM data WHERE key = @key;", conn);
            cmd.Parameters.AddWithValue("@key", key);
            var reader = await cmd.ExecuteScalarAsync();
            if (reader == null) return null;
            return reader.ToString();
        }
    }
}