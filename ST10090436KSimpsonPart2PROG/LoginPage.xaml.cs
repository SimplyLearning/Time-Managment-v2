using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KS_Library;

namespace ST10090436KSimpsonPart2PROG
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

        public LoginPage()
        {
            InitializeComponent();
        }


        private void btnSumbit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //checking to see that the textboxs have been filled out
                if (txtUsername.Text.Equals(""))
                {
                    MessageBox.Show("Username is Empty!");
                }
                else if (txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("Password is Empty!");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Do you want continue?", "Question", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        //MainWindow Main = new MainWindow();
                        Main.NavigationService.Navigate(new ModulesPage(txtUsername.Text));

                    }
                    else
                    {
                        MainWindow mw = new MainWindow();
                    }
                }

                SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
                sqlCon.Open();

                // creating the query
                String query = "SELECT * FROM [dbo].[tblUser] WHERE Username ='" + txtUsername.Text + "' " + "AND Password = '" + txtPassword.Text + "';";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                 sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                 sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                //sqlCmd.ExecuteNonQuery();
                //sqlCon.Dispose();

                reader.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }


        //private void btnSumbit_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {

        //        {
        //            //checking to see that the textboxs have been filled out
        //            if (txtUsername.Text.Equals(""))
        //            {
        //                MessageBox.Show("Username is Empty!");
        //            }
        //            else if (txtPassword.Text.Equals(""))
        //            {
        //                MessageBox.Show("Password is Empty!");
        //            }
        //            else
        //            {
        //                MessageBoxResult result = MessageBox.Show("Do you want continue?", "Question", MessageBoxButton.YesNo);
        //                if (result == MessageBoxResult.Yes)
        //                {
        //                    Main.NavigationService.Navigate(new ModulesPage(txtUsername.Text));
        //                }
        //                else
        //                {
        //                    MainWindow Main = new MainWindow();
        //                }
        //            }
        //            SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //            // creating the query
        //            sqlCon.Open();
        //            String query = "SELECT * FROM [dbo].[tblUser] WHERE Username ='" + txtUsername.Text + "' " + "AND Password = '" + txtPassword.Text + "'";
        //            SqlCommand sqlCom = new SqlCommand(query, sqlCon);
        //            SqlDataReader reader = sqlCom.ExecuteReader();
        //            if (reader.HasRows)
        //            {
        //                MessageBox.Show("Success");
        //                //loging in and only showing the data of this user
                        
        //                txtUsername.Text = "";
        //                txtPassword.Text = "";
        //            }
        //            else
        //            {
        //                MessageBox.Show("Invalid Credentials");
        //            }
        //            reader.Close();
        //            sqlCom.Dispose();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}





        //    private void btnSubmit(object sender, RoutedEventArgs e)
        //    {
        //        MySqlConnection sqlCon = new MySqlConnection("Data Source=DESKTOP-4S3DIHK\\SQLEXPRESS;Initial Catalog=UserData;Integrated Security=True");
        //        try
        //        {
        //            if (sqlCon.State == System.Data.ConnectionState.Closed)
        //                sqlCon.Open();
        //            String query = "SELECT * FROM dbo.tblUser WHERE Username = @Username AND Password = @Password ";
        //            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
        //            sqlCmd.CommandType = System.Data.CommandType.Text;
        //            sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
        //            sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
        //            utils.hashPassword(txtPassword.Text);

        //            // checking to see that the textboxs have been filled out
        //            if (txtUsername.Text.Equals(""))
        //            {
        //                MessageBox.Show("Username is Empty!");
        //            }
        //            else if (txtPassword.Text.Equals(""))
        //            {
        //                MessageBox.Show("Password is Empty!");
        //            }

        //            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
        //            if (count == 1)
        //            {
        //                //Logged in with existing user
        //                ModulesPage Main = new ModulesPage();
        //                //the page it opens
        //                //Main.Show();
        //                //closes the login page
        //                //Main.Close();

        //            }
        //            else
        //            {
        //                //Wrong credintials!
        //                MessageBox.Show("Username or password is incorrect!");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            sqlCon.Close();
        //        }
        //    }
        //}


    }
}
