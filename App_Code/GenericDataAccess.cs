using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Class contains generic data access functionality to be accessed from
/// the business tier
/// </summary>
public static class GenericDataAccess
{
    public static DataTable ExecuteSelectCommand(DbCommand command)
    {
        DataTable table;
        try
        {
            command.Connection.Open();
            // Execute the command and save the results in a DataTable
            using (DbDataReader reader = command.ExecuteReader())
            {
                table = new DataTable();
                table.Load(reader);
            }
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
            throw;
        }
        finally
        {
            command.Connection.Close();
        }

        return table;
    }

    // creates and prepares a new DbCommand object on a new connection
    public static DbCommand CreateCommand()
    {
        string dataProviderName = CdShopConfiguration.DbProviderName;
        string connectionString = CdShopConfiguration.DbConnectionString;
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
        DbConnection conn = factory.CreateConnection();
        conn.ConnectionString = connectionString;
        DbCommand command = conn.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        return command;
    }

    // execute an update, delete, or insert command
    // and return the number of affected rows
    public static int ExecuteNonQuery(DbCommand command)
    {
        // The number of affected rows
        int affectedRows = -1;
        // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the connection of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            affectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Log eventual errors and rethrow them
            Utilities.LogError(ex);
            throw;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        // return the number of affected rows
        return affectedRows;
    }

    // execute a select command and return a single result as a string
    public static string ExecuteScalar(DbCommand command)
    {
        // The value to be returned
        string value = "";
     // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the connection of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            value = command.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            // Log eventual errors and rethrow them
            Utilities.LogError(ex);
            throw;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        // return the result
        return value;
    }
}