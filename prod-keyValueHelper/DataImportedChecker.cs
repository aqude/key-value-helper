using System.IO;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using prod_keyValueHelper.data;

namespace prod_keyValueHelper;

internal class DataImportedChecker
{
    internal async Task<bool> IsDatabaseIsInitialized()
    {
        var dataBase = new Database();
        using (var conn = await dataBase.OpenConnectionAsync())
        {
            try
            {
                var cmd = new SqliteCommand("SELECT count(*) FROM data;", conn);
                var result = await cmd.ExecuteScalarAsync();
                if (result != null && (int)(long)result > 0)
                {
                    dataBase.CloseConnection();
                    return true;
                }
                else
                {
                    dataBase.CloseConnection();
                    return false;
                }
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == SQLitePCL.raw.SQLITE_ERROR)
                {
                    dataBase.CloseConnection();
                    return false;
                }

                throw;
            }
            
        }
    }
}