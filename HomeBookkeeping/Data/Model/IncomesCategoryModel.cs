using HomeBookkeeping.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Data.Model
{
    class IncomesCategoryModel:BaseModel
    {
        #region CONSTRUCTOR
        public IncomesCategoryModel() : base() { }
        #endregion

        #region PROPERTY
        public string Category { get; set; }
        #endregion

        #region METHODS
        public static List<IncomesCategoryModel> SelectAll()
        {
            return DBManager.SelectAllIncomesCategory();
        }

        public static int Insert(IncomesCategoryModel income)
        {
            return DBManager.InsertIncomesCategory(income);
        }

        public static bool Update(IncomesCategoryModel income)
        {
            return DBManager.UpdateIncomesCategory(income);
        }

        public static bool Delete (int id)
        {
            return DBManager.DeleteIncomesCategoryById(id);
        }
        #endregion
    }
}
