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
    public partial class OutcomeForm : Form
    {
        public OutcomeForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aldo\source\repos\PointOfSale\SupermarketManagementSystem\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from OutcomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OutcomeDGV.DataSource = ds.Tables[0];
            Con.Close();
            OutcomeId.Text = "";
            OutcomeDate.Text = "";
            OutcomeTotal.Text = "";
            OutcomeDesc.Text = "";
        }

        private void OutcomeForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void OutcomeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OutcomeId.Text = OutcomeDGV.SelectedRows[0].Cells[0].Value.ToString();
            OutcomeDate.Text = OutcomeDGV.SelectedRows[0].Cells[1].Value.ToString();
            OutcomeTotal.Text = OutcomeDGV.SelectedRows[0].Cells[2].Value.ToString();
            OutcomeDesc.Text = OutcomeDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into OutcomeTbl values (" + OutcomeId.Text + ", '" + OutcomeDate.Text + "', " + OutcomeTotal.Text + ", '" + OutcomeDesc.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Outcome Added Successfully");
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
                if (OutcomeId.Text == "")
                {
                    MessageBox.Show("Select The Outcome to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from OutcomeTbl where OutId=" + OutcomeId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Outcome Deleted Successfully");
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
                if (OutcomeId.Text == "" || OutcomeDate.Text == "" || OutcomeTotal.Text == "" || OutcomeDesc.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update OutcomeTbl set OutDate='" + OutcomeDate.Text + "', OutTotal=" + OutcomeTotal.Text + ", OutDesc='" + OutcomeDesc.Text + "' where OutId=" + OutcomeId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Outcome Successfully Updated");
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
            SellerForm cat = new SellerForm();
            cat.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IncomeForm inc = new IncomeForm();
            inc.Show();
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
