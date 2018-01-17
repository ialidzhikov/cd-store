namespace ECommerce.CdShop.Dao
{
    using ECommerce.CdShop.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Database access object for Song
    /// </summary>
    public class SongDao : AbstractDao<Song>
    {
        public List<Song> GetAllByProductId(int productId)
        {
            string query = String.Format("SELECT * FROM {0} WHERE ProductId = {1};", 
                                         GetTableName(), productId);
            return ExecuteSelectQuery(query);
        }

        protected override Song FromDataRow(DataRow row)
        {
            return new Song
            {
                Id = int.Parse(row["Id"].ToString()),
                ProductId = int.Parse(row["ProductId"].ToString()),
                Name = row["Name"].ToString(),
                Position = int.Parse(row["Position"].ToString()),
                Duration = row["Duration"].ToString(),
            };
        }
    }
}