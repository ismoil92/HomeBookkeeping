using HomeBookkeeping.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Data.Model
{
    class IncomesOutcomesModel:BaseModel
    {
        #region CONSTRUCTOR
        public IncomesOutcomesModel() : base() { }
        #endregion

        #region PROPERTIES
        public string DateTime { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Comment { get; set; }
        #endregion

        #region METHODS
        public static List<IncomesOutcomesModel> SelectAll()
        {
            return DBManager.SelectAllIncomes();
        }

        public static int Insert(IncomesOutcomesModel incomes)
        {
            return DBManager.InsertIncomes(incomes);
        }

        public static bool Update(IncomesOutcomesModel incomes)
        {
            return DBManager.UpdateIncomes(incomes);
        }

        public static bool Delete(int id)
        {
           return DBManager.DeleteIncomesById(id);
        }
        #endregion
    }
}
