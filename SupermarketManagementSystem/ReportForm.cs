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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aldo\source\repos\PointOfSale\SupermarketManagementSystem\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populateIncome()
        {
            Con.Open();
            string query = "select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populateOutcome()
        {
            Con.Open();
            string query = "select * from OutcomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OutcomeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void totalIncome()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("")) TotIncome.Text = "0";
            else TotIncome.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void totalOutcome()
        {
            Con.Open();
            string query = "select SUM(OutTotal) from OutcomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("")) TotOutcome.Text = "0";
            else TotOutcome.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }

        private void totalFinal()
        {
            int income = Convert.ToInt32(TotIncome.Text);
            int outcome = Convert.ToInt32(TotOutcome.Text);
            int total;
            if(income > outcome)
            {
                total = income - outcome;
                TotAmt.Text = total.ToString();
                TotDesc.Text = "Profit Rp";
            }
            else if(income < outcome)
            {
                total = outcome - income;
                TotAmt.Text = total.ToString();
                TotDesc.Text = "Loss Rp";
            }
            else
            {
                total = 0;
                TotAmt.Text = total.ToString();
                TotDesc.Text = "Profit/Loss Rp";
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            populateIncome();
            populateOutcome();
            totalIncome();
            totalOutcome();
            totalFinal();
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

        private void button9_Click(object sender, EventArgs e)
        {
            OutcomeForm outc = new OutcomeForm();
            outc.Show();
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
