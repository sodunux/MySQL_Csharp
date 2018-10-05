using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQL_Csharp
{
    public partial class Form1 : Form
    {
        DataTable inv = new DataTable();
        MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;
        MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
        MySql.Data.MySqlClient.MySqlDataReader msqlReader = null;
        string server = "";
        string uid = "";
        string passwd = "";
        string database = "";
        string table = "";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = inv;
            
        }

        private void ShowMessage(string message)
        {
            richTextBox1.Text = message;
        }

        bool ConnectSql() 
        {
            //连接数据库
            try
            {
                server = textBox5.Text;
                uid = textBox4.Text;
                passwd = textBox3.Text;
                database = textBox2.Text;
                table = textBox1.Text;
                string tempstr = "server=" + server + ";user id=" + uid + ";Password=" + passwd + ";database=" + database + ";persist security info=False";
                msqlConnection = new MySql.Data.MySqlClient.MySqlConnection(tempstr);
                msqlCommand.Connection = msqlConnection;
                msqlConnection.Open();
                ShowMessage("连接数据库成功");
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return false;
            }
        }
        bool CloseSql()
        {
            //关闭数据库
            try
            {
                server = textBox5.Text;
                uid = textBox4.Text;
                passwd = textBox3.Text;
                database = textBox2.Text;
                table = textBox1.Text;
                string tempstr = "server=" + server + ";user id=" + uid + ";Password=" + passwd + ";database=" + database + ";persist security info=False";
                msqlConnection = new MySql.Data.MySqlClient.MySqlConnection(tempstr);
                msqlCommand.Connection = msqlConnection;
                msqlReader.Close();
                msqlConnection.Close();
                ShowMessage("关闭数据库成功");
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //连接数据库
            try 
            {
                server = textBox5.Text;
                uid = textBox4.Text;
                passwd = textBox3.Text;
                database = textBox2.Text;
                table = textBox1.Text;
                string tempstr = "server=" + server + ";user id=" + uid + ";Password=" + passwd + ";database=" + database + ";persist security info=False";
                msqlConnection = new MySql.Data.MySqlClient.MySqlConnection(tempstr);
                msqlCommand.Connection = msqlConnection;
                msqlConnection.Open();

                ShowMessage("连接数据库成功");
            }
            catch (Exception ex) 
            {
                ShowMessage(ex.Message);
            }
            

            ////define the connection reference and initialize it
            //MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;
            //msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=aliyun;user id=root;Password=justdoit@1;database=ultrax;persist security info=False");
            ////define the command reference
            //MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
            ////define the connection used by the command object
            //msqlCommand.Connection = msqlConnection;
            ////define the command text
            //msqlCommand.CommandText = "SELECT * FROM pre_common_admincp_group;";
            //try
            //{
            //    //open the connection
            //    msqlConnection.Open();
            //    //use a DataReader to process each record
            //    MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();
            //    inv.Load(msqlReader);
            //    msqlReader.Close();
            //    //string message = msqlReader.GetName(1)+"\r\n";
            //    //while (msqlReader.Read())
            //    //{
            //    //    message += msqlReader.GetString(1)+"\r\n";                    
            //    //    //do something with each record
            //    //}
            //    //ShowMessage(message);
            //}
            //catch (Exception er)
            //{
            //    //do something with the exception
            //}
            //finally
            //{
            //    //always close the connection
            //    msqlConnection.Close();
            //}


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (textBox3.Text == "密码")
                    textBox3.PasswordChar = ' ';
                else 
                    textBox3.PasswordChar = '*';
                
            }
            catch (Exception ex) { ShowMessage(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //读取表格
            try 
            {
                table=textBox1.Text;
                string tempstr = "SELECT * FROM " + table + ";";
                msqlCommand.CommandText = tempstr;
                msqlReader = msqlCommand.ExecuteReader();
                inv.Load(msqlReader);
            }
            catch (Exception ex) { ShowMessage(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                CloseSql();
            }
            catch (Exception ex) { ShowMessage(ex.Message); }
        }
    }
}
