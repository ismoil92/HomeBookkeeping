using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Data.Model
{
    class BaseModel
    {
        #region CONSTRUCTORS

        public BaseModel() { }

        public BaseModel(int id) { ID = id; }
        #endregion

        #region PROPERTY
        public int ID { get; set; }
        #endregion
    }
}
