using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using HomeBookkeeping.Data.Model;

namespace HomeBookkeeping.Classes
{
    class DBManager
    {
        #region FIELDS
        private static readonly string _connectionString = String.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory+"\\Data\\data.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);

        private static readonly string _tablenameCurrency = "Currency";
        private static readonly string _tablenameIncomesCategory = "IncomesCategory";
        private static readonly string _tablenameOutcomesCategory = "OutcomesCategory";
        private static readonly string _tablenameIncomesOutcomes = "IncomesOutcomes";
        private static readonly string _tablenameOutcomes = "Outcomes";

        #endregion

        #region METHODS
        public static bool DeleteById(string tablename, int id)
        {
            bool isDeleted = false;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"DELETE FROM [{tablename}] WHERE ID=@id";
                        command.Parameters.AddWithValue("id", id);

                        int rowInserted = command.ExecuteNonQuery();
                        if(rowInserted>0)
                        {
                            isDeleted = true;
                        }
                    }
                    transaction.Commit();
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return isDeleted;
        }


        #region INCOMES-CATEGORY
        public static List<IncomesCategoryModel> SelectAllIncomesCategory()
        {
            var items = new List<IncomesCategoryModel>();
            try
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}]",_tablenameIncomesCategory);
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var category = reader[1].ToString();
                        var item = new IncomesCategoryModel();
                        item.ID = id;
                        item.Category = category;
                        items.Add(item);
                    }
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return items;
        }

        public static int InsertIncomesCategory(IncomesCategoryModel incomes)
        {
            int lastId = -1;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tablenameIncomesCategory}] (Category) VALUES (@category)";
                        command.Parameters.AddWithValue("category", incomes.Category);

                        int rowsInserted = command.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return lastId;
        }

        public static bool UpdateIncomesCategory(IncomesCategoryModel incomes)
        {
            bool isUpdate = false;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tablenameIncomesCategory}] SET Category=@category WHERE ID=@id";
                        command.Parameters.AddWithValue("id", incomes.ID);
                        command.Parameters.AddWithValue("category", incomes.Category);

                        int rowsInserted = command.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            isUpdate = true;
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return isUpdate;
        }

        public static bool DeleteIncomesCategoryById(int id)
        {
            return DeleteById(_tablenameIncomesCategory, id);
        }

        #endregion

        #region OUTCOMES-CATEGORY

        public static List<OutcomesCategoryModel> SelectAllOutcomesCategory()
        {
            var items = new List<OutcomesCategoryModel>();

            try
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}]",_tablenameOutcomesCategory);
                    var reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var category = reader[1].ToString();

                        var item = new OutcomesCategoryModel();

                        item.ID = id;
                        item.Category = category;

                        items.Add(item);
                    }
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return items;
        }

        public static int InsertOutcomesCategory(OutcomesCategoryModel outcomes)
        {
            int lastId = -1;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tablenameOutcomesCategory}] (Category) VALUES (@category)";
                        command.Parameters.AddWithValue("category", outcomes.Category);

                        int rowsInserted = command.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return lastId;
        }

        public static bool UpdateOutcomesCategory(OutcomesCategoryModel outcomes)
        {
            bool isUpdate = false;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tablenameOutcomesCategory}] SET Category=@category WHERE ID=@id";
                        command.Parameters.AddWithValue("id", outcomes.ID);
                        command.Parameters.AddWithValue("category", outcomes.Category);

                        int rowsInserted = command.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            isUpdate = true;
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return isUpdate;
        }

        public static bool DeleteOutcomesCategoryById(int id)
        {
            return DeleteById(_tablenameOutcomesCategory, id);
        }

        #endregion

        #region INCOMESOUTCOMES
        public static List<IncomesOutcomesModel> SelectAllIncomes()
        {
            var items = new List<IncomesOutcomesModel>();

            try
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}]", _tablenameIncomesOutcomes);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var datetime = reader[1].ToString();
                        var type = reader[2].ToString();
                        var category = reader[3].ToString();
                        var price = int.Parse(reader[4].ToString());
                        var comment = reader[5].ToString();

                        var item = new IncomesOutcomesModel();
                        item.ID = id;
                        item.DateTime = datetime;
                        item.Type = type;
                        item.Category = category;
                        item.Price = price;
                        item.Comment = comment;

                        items.Add(item);
                    }
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return items;
        }

        public static int InsertIncomes(IncomesOutcomesModel incomes)
        {
            int lastId = -1;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tablenameIncomesOutcomes}] (DateTime, Type, Category, Price, Comment) VALUES (@datetime, @type, @category, @price, @comment)";
                        command.Parameters.AddWithValue("datetime",incomes.DateTime);
                        command.Parameters.AddWithValue("type",incomes.Type);
                        command.Parameters.AddWithValue("category", incomes.Category);
                        command.Parameters.AddWithValue("price",incomes.Price);
                        command.Parameters.AddWithValue("comment",incomes.Comment);

                        int rowsInserted = command.ExecuteNonQuery();
                        if(rowsInserted>0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    transaction.Commit();
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return lastId;
        }

        public static bool UpdateIncomes(IncomesOutcomesModel incomes)
        {
            bool isUpdate = false;
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tablenameIncomesOutcomes}] SET DateTime=@datetime, Type=@type, Category=@category, Price=@price, Comment=@comment WHERE ID=@id";
                        command.Parameters.AddWithValue("id", incomes.ID);
                        command.Parameters.AddWithValue("datetime", incomes.DateTime);
                        command.Parameters.AddWithValue("type",incomes.Type);
                        command.Parameters.AddWithValue("category", incomes.Category);
                        command.Parameters.AddWithValue("price", incomes.Price);
                        command.Parameters.AddWithValue("comment", incomes.Comment);

                        int rowsInserted = command.ExecuteNonQuery();
                        if(rowsInserted>0)
                        {
                            isUpdate = true;
                        }
                    }
                    transaction.Commit();
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
            return isUpdate;
        }

        public static bool DeleteIncomesById(int id)
        {
            return DeleteById(_tablenameIncomesOutcomes, id);
        }
        #endregion
        #endregion
    }
}
