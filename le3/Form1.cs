using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace le3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=10.10.1.24;Initial Catalog=re3;User ID=pro-41;Password=IsPro-41";
            string sql = "SELECT * FROM dbo.product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

                connection.Open();
                string sqlExpression = "SELECT COUNT (product_id) FROM dbo.product";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());
                Count.Text = count.ToString();
                connection.Close();
            }
        }
    }
}
