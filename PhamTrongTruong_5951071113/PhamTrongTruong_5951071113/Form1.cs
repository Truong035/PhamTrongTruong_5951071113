using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamTrongTruong_5951071113
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            GetStudentRecord();
            
        }
        public void GetStudentRecord()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");
            SqlDataAdapter command = new SqlDataAdapter("Select * from StudentTB", connection);
            DataTable dataTable = new DataTable();
            command.Fill(dataTable);
            connection.Close();
            dataGridView1.DataSource = dataTable;
            STudentId = 0;              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ISValidData() == true)
            {
                AddStudent();
            }
        }

        private bool ISValidData()
        {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Vui Lòng Họ");
                }
                else if (textBox4.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Vui Lòng Nhập Tên");
                }
                else if (textBox2.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Vui Lòng Nhập Số Báo Danh");
                }
                else if (textBox3.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Vui Lòng Nhập Đỉa Chỉ");
                }

                else if (textBox5.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Vui Lòng Nhập Số Điện Thoại");
                }
                else
                {
                return true;
                }
            return false;

            }
        

        private void AddStudent()
        {
            try
            {
                 connection.Open();                
                string sql = string.Format(" insert into StudentTB (Name,FartherName,RollNumber,Address,Mobile) values('{0}','{1}','{2}','{3}','{4}')",textBox4.Text
               , textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text);
                SqlCommand sqlCommand = new SqlCommand(sql,connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                GetStudentRecord();
            }
            catch (Exception e){
                connection = new SqlConnection(@"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");
                MessageBox.Show(e.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetStudentRecord();
        }
        public int STudentId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
               STudentId= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (STudentId > 0)
            {
                try
                {
                    connection.Open();
                    string sql = string.Format(" Delete From  StudentTB Where StudentID='{0}'", STudentId);
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Xóa Thành Công");
                    GetStudentRecord();
                }
                catch (Exception ex)
                {
                    connection = new SqlConnection(@"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");
              
                    MessageBox.Show("Cập Nhật Bi Lỗi !!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (STudentId > 0)
            {
                if (ISValidData() == true)
                {
                    try
                    {
                        connection.Open();
                        string sql = string.Format(" update  StudentTB Set Name = '{0}' , FartherName = '{1}',RollNumber = '{2}' ,Address = '{3}',Mobile = '{4}' Where StudentID='{5}'", textBox4.Text
                       , textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, STudentId);
                        SqlCommand sqlCommand = new SqlCommand(sql, connection);
                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Cập Nhật Thành Công");
                        GetStudentRecord();
                    }
                    catch (Exception ex)
                    {
                        connection = new SqlConnection(@"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");
                        MessageBox.Show("Cập Nhật Bi Lỗi !!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
    }
}
