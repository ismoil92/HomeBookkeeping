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
    public partial class IncomesOutcomesForm : Form
    {
        #region FIELDS
        internal IncomesOutcomesModel incomeOutcome;
        private static string Comment = "-----//----";
        private static string type = "";
        #endregion

        #region LISTS
        private List<IncomesCategoryModel> incomeCategories;
        private List<OutcomesCategoryModel> outcomeCategories;
        private List<IncomesOutcomesModel> incomesOutcomes;
        #endregion

        #region CONSTRUCTOR
        public IncomesOutcomesForm()
        {
            InitializeComponent();
            radioButtonIncomesCategory.Checked = true;
        }
        #endregion

        #region METHODS
        private void ComboBoxIncomeOutcomeCategory()
        {
            if(radioButtonIncomesCategory.Checked==true)
            {
                incomeCategories = IncomesCategoryModel.SelectAll();
                comboBoxIncomeOutcomeCateg.DisplayMember = "Category";
                comboBoxIncomeOutcomeCateg.ValueMember = "ID";
                comboBoxIncomeOutcomeCateg.DataSource = incomeCategories;
                comboBoxIncomeOutcomeCateg.SelectedValue = -1;
            }
            else
            {
                outcomeCategories = OutcomesCategoryModel.SelectAll();
                comboBoxIncomeOutcomeCateg.DisplayMember = "Category";
                comboBoxIncomeOutcomeCateg.ValueMember = "ID";
                comboBoxIncomeOutcomeCateg.DataSource = outcomeCategories;
                comboBoxIncomeOutcomeCateg.SelectedValue = -1;
            }
        }

        private void IncomesOutcomesForm_Load(object sender, EventArgs e)
        {
            if(incomeOutcome!=null)
            {
                textBoxIncomeOutcome.Text = incomeOutcome.Type;
                textBoxPrice.Text = (incomeOutcome.Price).ToString();
                if(incomeOutcome.Type=="Доход")
                {
                    radioButtonIncomesCategory.Checked = true;
                }
                else
                {
                    radioButtonOutcomesCategory.Checked = true;
                }
                ComboBoxIncomeOutcomeCategory();
                comboBoxIncomeOutcomeCateg.Text = incomeOutcome.Category;
            }
        }

        private void radioButtonIncomesCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIncomesCategory.Checked==true)
            {
                ComboBoxIncomeOutcomeCategory();
                comboBoxIncomeOutcomeCateg.SelectedValue = -1;
                type = "Доход";
                textBoxIncomeOutcome.Text = "Доход";
            }
        }

        private void radioButtonOutcomesCategory_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonOutcomesCategory.Checked==true)
            {
                ComboBoxIncomeOutcomeCategory();
                comboBoxIncomeOutcomeCateg.SelectedValue = -1;
                type = "Расход";
                textBoxIncomeOutcome.Text = "Расход";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(incomeOutcome==null)
            {
                if (labelCategory.Visible == true) labelCategory.Visible = false;
                if (labelPrice.Visible == true) labelPrice.Visible = false;
                incomeOutcome = new IncomesOutcomesModel();
                if(!string.IsNullOrEmpty(comboBoxIncomeOutcomeCateg.Text) && !string.IsNullOrWhiteSpace(comboBoxIncomeOutcomeCateg.Text))
                {
                    if(!string.IsNullOrEmpty(textBoxPrice.Text) && !string.IsNullOrWhiteSpace(textBoxPrice.Text))
                    {
                        int price = int.Parse(textBoxPrice.Text);
                        if(price>0)
                        {
                            incomeOutcome.DateTime = dtpDateAndTime.Value.ToString("dd-MM-yyyy HH:mm");
                            incomeOutcome.Type = textBoxIncomeOutcome.Text;
                            incomeOutcome.Category = comboBoxIncomeOutcomeCateg.Text;
                            incomeOutcome.Price = price;
                            if (!string.IsNullOrEmpty(textBoxComment.Text) && !string.IsNullOrWhiteSpace(textBoxComment.Text))
                            {
                                incomeOutcome.Comment = textBoxComment.Text;
                            }
                            else
                            {
                                incomeOutcome.Comment = Comment;
                            }
                            int insert = IncomesOutcomesModel.Insert(incomeOutcome);
                            if(insert>0)
                            {
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка");
                            }
                        }
                        else
                        {
                            labelPrice.Visible = true;
                            incomeOutcome = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поля Сумма пуста!");
                        incomeOutcome = null;
                    }
                }
                else
                {
                    labelCategory.Visible = true;
                    incomeOutcome = null;
                }
            }
            else
            {
                if (labelCategory.Visible == true) labelCategory.Visible = false;
                if (labelPrice.Visible == true) labelPrice.Visible = false;
                if (!string.IsNullOrEmpty(comboBoxIncomeOutcomeCateg.Text) && !string.IsNullOrWhiteSpace(comboBoxIncomeOutcomeCateg.Text))
                {
                    if(!string.IsNullOrEmpty(textBoxPrice.Text) && !string.IsNullOrWhiteSpace(textBoxPrice.Text))
                    {
                        int price = int.Parse(textBoxPrice.Text);
                        if(price>0)
                        {
                            incomeOutcome.DateTime = dtpDateAndTime.Value.ToString("dd-MM-yyyy HH:mm");
                            incomeOutcome.Type = textBoxIncomeOutcome.Text;
                            incomeOutcome.Category = comboBoxIncomeOutcomeCateg.Text;
                            incomeOutcome.Price = price;
                            if(!string.IsNullOrEmpty(textBoxComment.Text) && !string.IsNullOrWhiteSpace(textBoxComment.Text))
                            {
                                incomeOutcome.Comment = textBoxComment.Text;
                            }
                            else
                            {
                                incomeOutcome.Comment = Comment;
                            }
                            bool update = IncomesOutcomesModel.Update(incomeOutcome);
                            if(update)
                            {
                                Close();
                            }
                        }
                        else
                        {
                            labelPrice.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поля Сумма пуста!");
                    }
                }
                else
                {
                    labelCategory.Visible = true;
                }
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
