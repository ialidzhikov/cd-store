namespace ECommerce.CdShop.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;

    /// <summary>
    /// Abstract database access object
    /// </summary>
    public abstract class AbstractDao<T>
    {
        protected abstract T FromDataRow(DataRow row);

        public List<T> GetAll()
        {
            String query = String.Format("SELECT * FROM {0};", GetTableName());
            return ExecuteSelectQuery(query);
        }

        protected List<T> ExecuteSelectQuery(String query)
        {
            using (DbConnection connection = CreateConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return (from DataRow row in table.Rows
                            select FromDataRow(row)).ToList();
                }
            }
        }

        public T Find(Object id)
        {
            using (DbConnection connection = CreateConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = String.Format("SELECT * FROM {0} WHERE Id = {1};", GetTableName(), id);
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    if (table.Rows.Count == 0)
                    {
                        return default(T);
                    }

                    return FromDataRow(table.Rows[0]);
                }
            }
        }

        protected string GetTableName()
        {
            return typeof(T).Name;
        }

        private DbConnection CreateConnection()
        {
            string dataProviderName = CdShopConfiguration.DbProviderName;
            string connectionString = CdShopConfiguration.DbConnectionString;
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}