using HomeBookkeeping.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBookkeeping
{
    public partial class OutcomesCategory : Form
    {
        #region FIELD
        internal OutcomesCategoryModel outcomeCategory;
        #endregion

        #region LISTS
        private List<OutcomesCategoryModel> outcomesCateg;
        #endregion

        #region CONSTRUCTOR
        public OutcomesCategory()
        {
            InitializeComponent();
            buttonSave.Enabled = false;
        }
        #endregion

        #region METHODS

        private void OutcomesCategory_Load(object sender, EventArgs e)
        {
            if(outcomeCategory!=null)
            {
                textBoxName.Text = outcomeCategory.Category;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(outcomeCategory==null)
            {
                outcomesCateg = OutcomesCategoryModel.SelectAll();
                outcomeCategory = new OutcomesCategoryModel();
                if(!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    outcomeCategory.Category = textBoxName.Text;
                    int insert = OutcomesCategoryModel.Insert(outcomeCategory);
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
                    outcomeCategory.Category = textBoxName.Text;
                    bool update = OutcomesCategoryModel.Update(outcomeCategory);
                    if(update)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
        }

        #endregion
    }
}
