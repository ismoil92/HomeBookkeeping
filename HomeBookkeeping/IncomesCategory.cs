using HomeBookkeeping.Data.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HomeBookkeeping
{
    public partial class IncomesCategory : Form
    {
        #region FIELD
        internal IncomesCategoryModel incocateg;
        #endregion

        #region LIST
        List<IncomesCategoryModel> incomesCategory;
        #endregion

        #region CONSTRUCTOR
        public IncomesCategory()
        {
            InitializeComponent();
            buttonSave.Enabled = false;
        }
        #endregion

        #region METHODS

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(incocateg==null)
            {
                incomesCategory = IncomesCategoryModel.SelectAll();
                incocateg = new IncomesCategoryModel();
                if(!string.IsNullOrEmpty(textBoxName.Text) &&!string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    incocateg.Category = textBoxName.Text;
                    int insert = IncomesCategoryModel.Insert(incocateg);
                    if(insert>0)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    incocateg.Category = textBoxName.Text;
                    bool update = IncomesCategoryModel.Update(incocateg);
                    if(update)
                    {
                        Close();
                    }
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                buttonSave.Enabled = true;
            }
            else
            {
                buttonSave.Enabled = false;
            }
        }

        private void IncomesCategory_Load(object sender, EventArgs e)
        {
            if(incocateg!=null)
            {
                textBoxName.Text = incocateg.Category;
            }
        }

        #endregion
    }
}
