using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SupermarketManagementSystem
{
    public partial class IncomeForm : Form
    {
        public IncomeForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aldo\source\repos\PointOfSale\SupermarketManagementSystem\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();
            IncomeId.Text = "";
            IncomeSeller.Text = "";
            IncomeDate.Text = "";
            IncomeTotal.Text = "";
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void IncomeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IncomeId.Text = IncomeDGV.SelectedRows[0].Cells[0].Value.ToString();
            IncomeSeller.Text = IncomeDGV.SelectedRows[0].Cells[1].Value.ToString();
            IncomeDate.Text = IncomeDGV.SelectedRows[0].Cells[2].Value.ToString();
            IncomeTotal.Text = IncomeDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into BillTbl values (" + IncomeId.Text + ", '" + IncomeSeller.Text + "', '" + IncomeDate.Text + "', " + IncomeTotal.Text + ")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Income Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (IncomeId.Text == "")
                {
                    MessageBox.Show("Select The Income to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from BillTbl where BillId=" + IncomeId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (IncomeId.Text == "" || IncomeSeller.Text == "" || IncomeDate.Text == "" || IncomeTotal.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update BillTbl set SellerName='" + IncomeSeller.Text + "', BillDate='" + IncomeDate.Text + "', TotAmt=" + IncomeTotal.Text + " where BillId=" + IncomeId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm sell = new SellerForm();
            sell.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OutcomeForm outc = new OutcomeForm();
            outc.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ReportForm rep = new ReportForm();
            rep.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}
