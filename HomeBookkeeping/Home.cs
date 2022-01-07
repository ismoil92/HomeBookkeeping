using HomeBookkeeping.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBookkeeping
{
    public partial class Home : Form
    {
        #region FIELDS
        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\data.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);
        private static SQLiteCommand command;
        private static DataTable datatable;
        private static SQLiteDataAdapter dataadapter;
        private static string query = "";
        private static int Total = 0;
        private static int TotalIncomes = 0;
        private static int TotalOutcomes = 0;
        
        #endregion

        #region LISTS
        private List<IncomesOutcomesModel> income;
        private List<IncomesCategoryModel> incomeCateg;
        private List<OutcomesCategoryModel> outcomeCateg;
        #endregion

        #region CONSTRUCTOR
        public Home()
        {
            InitializeComponent();
            radioButtonAll.Checked=true;
            comboBoxCategory.Enabled = false;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
        }
        #endregion

        #region METHODS

        private void ShowIncomesOutcomes()
        {
            income = IncomesOutcomesModel.SelectAll();
            dataGridViewIncomeOutcome.DataSource = income;
        }

        private void ListboxIncomesCategory()
        {
            if (lbxIncomeCategory.Items.Count != 0) lbxIncomeCategory.Items.Clear();
            incomeCateg = IncomesCategoryModel.SelectAll();
            foreach(var income in incomeCateg)
            {
                lbxIncomeCategory.Items.Add(income.Category);
            }
        }

        private void ListboxOutcomesCategory()
        {
            if (lbxOutcomeCategory.Items.Count != 0) lbxOutcomeCategory.Items.Clear();
            {
                outcomeCateg = OutcomesCategoryModel.SelectAll();
                foreach(var outcome in outcomeCateg)
                {
                    lbxOutcomeCategory.Items.Add(outcome.Category);
                }
            }
        }

        private void ComboBoxCategory()
        {
            if (radioButtonIncome.Checked == true)
            {
                incomeCateg = IncomesCategoryModel.SelectAll();
                comboBoxCategory.DisplayMember = "Category";
                comboBoxCategory.ValueMember = "ID";
                comboBoxCategory.DataSource = incomeCateg;
                comboBoxCategory.SelectedValue = -1;
            }
            else if (radioButtonOutcome.Checked == true)
            {
                outcomeCateg = OutcomesCategoryModel.SelectAll();
                comboBoxCategory.DisplayMember = "Category";
                comboBoxCategory.ValueMember = "ID";
                comboBoxCategory.DataSource = outcomeCateg;
                comboBoxCategory.SelectedValue = -1;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ShowIncomesOutcomes();
            ComboBoxCategory();
            ListboxIncomesCategory();
            ListboxOutcomesCategory();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            IncomesOutcomesForm incomeOutcome = new IncomesOutcomesForm();
            incomeOutcome.StartPosition = FormStartPosition.CenterParent;
            incomeOutcome.ShowDialog();
            ShowIncomesOutcomes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            income = IncomesOutcomesModel.SelectAll();
            if(income.Count!=0)
            {
                var index = dataGridViewIncomeOutcome.CurrentRow.Index;
                IncomesOutcomesForm incomeOutcome = new IncomesOutcomesForm();
                incomeOutcome.StartPosition = FormStartPosition.CenterParent;
                incomeOutcome.incomeOutcome = income[index];
                incomeOutcome.ShowDialog();
                ShowIncomesOutcomes();
            }
            else
            {
                MessageBox.Show("Невозможно изменить!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            income = IncomesOutcomesModel.SelectAll();
            if(income.Count!=0)
            {
                var index = dataGridViewIncomeOutcome.CurrentRow.Index;
                int id = income[index].ID;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    bool delete = IncomesOutcomesModel.Delete(id);
                    if(delete)
                    {
                        ShowIncomesOutcomes();
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить!");
            }
        }

        private void DTMAfter_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            if(today<DTMAfter.Value && (today==DTMAfter.Value))
            {
                MessageBox.Show("Не разрешено выбирать завтрашный или будущий день");
                DTMAfter.Value = DateTime.Today.Date;
            }
        }

        private void DTPBefore_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            if(today<DTPBefore.Value && (today==DTPBefore.Value))
            {
                MessageBox.Show("Не разрешено выбирать завтрашный или будущий день");
                DTPBefore.Value = DateTime.Today.Date;
            }
        }

        private void radioButtonIncome_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonIncome.Checked==true)
            {
                ComboBoxCategory();
                comboBoxCategory.SelectedValue = -1;
                comboBoxCategory.Enabled = true;
                query = "SELECT * FROM IncomesOutcomes WHERE (DateTime BETWEEN @after AND @before) AND Type=@type";
                string income = "Доход";
                var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
                var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
                datatable = new DataTable();
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query,connection);
                    command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("type",income);
                    dataadapter = new SQLiteDataAdapter(command);
                    dataadapter.Fill(datatable);
                    dataGridViewStatistics.DataSource = datatable;
                }
                catch(Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void radioButtonOutcome_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonOutcome.Checked==true)
            {
                ComboBoxCategory();
                comboBoxCategory.SelectedValue = -1;
                comboBoxCategory.Enabled = true;
                query = "SELECT * FROM IncomesOutcomes WHERE (DateTime BETWEEN @after AND @before) AND Type=@type";
                string outcome = "Расход";
                var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
                var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
                datatable = new DataTable();
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("type", outcome);
                    dataadapter = new SQLiteDataAdapter(command);
                    dataadapter.Fill(datatable);
                    dataGridViewStatistics.DataSource = datatable;
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                comboBoxCategory.Enabled = false;
                query = "SELECT * FROM IncomesOutcomes WHERE DateTime BETWEEN @after AND @before";
                var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
                var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
                datatable = new DataTable();
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query,connection);
                    command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                    dataadapter = new SQLiteDataAdapter(command);
                    dataadapter.Fill(datatable);
                    dataGridViewStatistics.DataSource = datatable;
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void SelectByCategory()
        {
            query = "SELECT * FROM IncomesOutcomes WHERE (DateTime BETWEEN @after AND @before) AND Category=@category";
            var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
            var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
            datatable = new DataTable();
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("category",comboBoxCategory.Text);
                dataadapter = new SQLiteDataAdapter(command);
                dataadapter.Fill(datatable);
                dataGridViewStatistics.DataSource = datatable;
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void TotalSumByIncomes()
        {
            query = "SELECT SUM(Price)  FROM IncomesOutcomes WHERE(DateTime BETWEEN @after AND @before) AND Type=@type";
            var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
            var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
            string income = "Доход";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("type",income);
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if (!string.IsNullOrEmpty(value.ToString()) && !string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        TotalIncomes = int.Parse(value.ToString());
                        labelTotalSum.Text = "Общая сумма доходов:" + TotalIncomes.ToString();
                    }
                    else
                    {
                        labelTotalSum.Text = "Общая сумма доходов:" + TotalIncomes.ToString();
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
        }

        private void TotalSumByOutcomes()
        {
            query = "SELECT SUM(Price)  FROM IncomesOutcomes WHERE(DateTime BETWEEN @after AND @before) AND Type=@type";
            var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
            var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
            string outcome = "Расход";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("type", outcome);
                var value = command.ExecuteScalar();
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(value.ToString()) && !string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        TotalOutcomes = int.Parse(value.ToString());
                    }
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
        }

        private void btnInsertIncome_Click(object sender, EventArgs e)
        {
            IncomesCategory income = new IncomesCategory();
            income.StartPosition = FormStartPosition.CenterParent;
            income.ShowDialog();
            ListboxIncomesCategory();
        }

        private void btnUpdateIncome_Click(object sender, EventArgs e)
        {
            incomeCateg = IncomesCategoryModel.SelectAll();
            if (incomeCateg.Count != 0)
            {
                var index = lbxIncomeCategory.SelectedIndex;
                IncomesCategory income = new IncomesCategory();
                income.StartPosition = FormStartPosition.CenterParent;
                income.incocateg = incomeCateg[index];
                income.ShowDialog();
                ListboxIncomesCategory();
            }
            else
            {
                MessageBox.Show("Невозможно изменить!");
            }
        }

        private void btnDeleteIncome_Click(object sender, EventArgs e)
        {
            incomeCateg = IncomesCategoryModel.SelectAll();
            if (incomeCateg.Count != 0)
            {
                var index = lbxIncomeCategory.SelectedIndex;
                int id = incomeCateg[index].ID;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool delete = IncomesCategoryModel.Delete(id);
                    if (delete)
                    {
                        ListboxIncomesCategory();
                    }
                }
            }
            else
            {
                MessageBox.Show("невозможно удалить!");
            }
        }

        private void btnInsertOutcome_Click(object sender, EventArgs e)
        {
            OutcomesCategory outcome = new OutcomesCategory();
            outcome.StartPosition = FormStartPosition.CenterParent;
            outcome.ShowDialog();
            ListboxOutcomesCategory();
        }

        private void btnUpdateOutcome_Click(object sender, EventArgs e)
        {
            outcomeCateg = OutcomesCategoryModel.SelectAll();
            if (outcomeCateg.Count != 0)
            {
                var index = lbxOutcomeCategory.SelectedIndex;
                OutcomesCategory outcome = new OutcomesCategory();
                outcome.outcomeCategory = outcomeCateg[index];
                outcome.StartPosition = FormStartPosition.CenterParent;
                outcome.ShowDialog();
                ListboxOutcomesCategory();
            }
            else
            {
                MessageBox.Show("Невозможно удалить!");
            }
        }

        private void btnDeleteOutcome_Click(object sender, EventArgs e)
        {
            outcomeCateg = OutcomesCategoryModel.SelectAll();
            if(outcomeCateg.Count!=0)
            {
                var index = lbxOutcomeCategory.SelectedIndex;
                int id = outcomeCateg[index].ID;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool delete = OutcomesCategoryModel.Delete(id);
                    if (delete)
                    {
                        ListboxOutcomesCategory();
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить!");
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectByCategory();
        }

        private void buttonTotalSum_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0) listBox1.Items.Clear();
            TotalSumByOutcomes();
            TotalSumByIncomes();
            var after = new DateTime(DTMAfter.Value.Year, DTMAfter.Value.Month, DTMAfter.Value.Day, 0, 0, 0);
            var before = new DateTime(DTPBefore.Value.Year, DTPBefore.Value.Month, DTPBefore.Value.Day, 23, 59, 0);
            Total = TotalIncomes - TotalOutcomes;
            var text1 = "Общий учёт доходов и расходов. Общий учёт:"+Total;
            var text2 = "из них Доход:" + TotalIncomes + ", Расход:" + TotalOutcomes;
            var text3 = "в период: с "+ after.ToString("dd-MM-yyyy")+" по "+ before.ToString("dd-MM-yyyy");
            listBox1.Items.Add(text1);
            listBox1.Items.Add(text2);
            listBox1.Items.Add(text3);
        }
    }
}
#endregion
