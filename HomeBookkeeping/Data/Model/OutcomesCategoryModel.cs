using HomeBookkeeping.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Data.Model
{
    class OutcomesCategoryModel:BaseModel
    {
        #region CONSTRUCTOR

        public OutcomesCategoryModel() : base() { }
        #endregion

        #region PROPERTY
        public string Category { get; set; }
        #endregion

        #region METHODS
        public static List<OutcomesCategoryModel> SelectAll()
        {
            return DBManager.SelectAllOutcomesCategory();
        }

        public static int Insert(OutcomesCategoryModel outcome)
        {
            return DBManager.InsertOutcomesCategory(outcome);
        }

        public static bool Update(OutcomesCategoryModel outcome)
        {
            return DBManager.UpdateOutcomesCategory(outcome);
        }

        public static bool Delete(int id)
        {
            return DBManager.DeleteOutcomesCategoryById(id);
        }
        #endregion
    }
}
