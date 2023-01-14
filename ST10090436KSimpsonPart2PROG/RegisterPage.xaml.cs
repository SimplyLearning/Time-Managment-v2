using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
using System.Data.SqlClient;
using System.Data;

namespace ST10090436KSimpsonPart2PROG
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public RegisterPage()
        {
            InitializeComponent();
        }
        
        public class utils // Hashing of the password
        {
            public static string hashPassword(string Password)
            {
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

                byte[] password_bytes = Encoding.ASCII.GetBytes(Password);
                byte[] encripted_bytes = sha1.ComputeHash(password_bytes);
                return Convert.ToBase64String(encripted_bytes);
            }

        }

        
        // Inserting Data into Sql 
        private void Insert(string Username, string Password)
        {
            // creating the query
            String query = "INSERT INTO [dbo].[tblUser](Username, Password) VALUES (@Username, @Password)";

            try
            {
                SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
               
                sqlCmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = txtUsername.Text;
                sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = txtPassword.Text;
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                // hash password
                utils.hashPassword(txtPassword.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count == 1)
                {
                    //information inserted
                    MainWindow Main = new MainWindow();
                    //the page it opens
                    Main.Show();

                }
                else
                {
                    //Wrong credintials!
                    MessageBox.Show("Infromation has a problem!");
                }
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
                        Main.NavigationService.Navigate(new LoginPage());
                        
                    }
                    else{
                        RegisterPage pg = new RegisterPage();
                    }
                    
                }

                SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
                // creating the query
                String query = "INSERT INTO [dbo].[tblUser](Username, Password) VALUES (@Username, @Password);";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();

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
        //Button Submit
        //    private void btnSubmit(object sender, RoutedEventArgs e)
        //    {
        //        try
        //        {
        //            using (SqlConnection SqlCon = new SqlConnection(Class.connString))
        //            {
        //                SqlCon.Open();
        //                String query = "INSERT INTO [UserData].[dbo].[tblUser] VALUES ('" + txtUsername.Text + "' " + txtPassword.Text + "' ;";
        //                SqlCommand sqlCom = new SqlCommand(query, SqlCon);
        //                SqlDataReader reader = sqlCom.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    MessageBox.Show("Success");
        //                    MainWindow Main = new MainWindow();
        //                    txtUsername.Text = "";
        //                    txtPassword.Text = "";
        //                    //this.Hide();
        //                    //lp.Main();
        //                   // this.Show();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Invalid Credentials");
        //                }
        //                reader.Close();
        //                sqlCom.Dispose();
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //    }
        //}



        // checking to see that the textboxs have been filled out
        //if (txtUsername.Text.Equals(""))
        // {
        //    MessageBox.Show("Username is Empty!");
        // }
        //else if (txtPassword.Text.Equals(""))
        // {
        //     MessageBox.Show("Password is Empty!");
        // }
        // if both textboxs have been filled and submitted the user shall go to the main window to login
        //if ((txtUsername = true) && Password = true)
        //{
        //    //information inserted
        //    MainWindow Main = new MainWindow();
        //    //the page it opens
        //    Main.Show();
        //    //closes the login page
        //    //LoginPage.Close();

        //}
        ///  else
        //  {
        //Wrong credintials!
        //     MessageBox.Show("Infromation has a problem!");
        //    }
        //   }
        // catch (Exception ex)
        //  {
        //   MessageBox.Show(ex.Message);
        //   }
        //   finally
        //  {
        //      sqlCon.Close();
        //  }
        //   }
        //    // Inserting Data into Sql 
        //    private void Insert(string Username, string Password)
        //    {
        //        //connection
        //        MySqlConnection sqlCon = new MySqlConnection("Data Source=DESKTOP-4S3DIHK\\SQLEXPRESS;Initial Catalog=UserData;Integrated Security=True");

        //        // creating the query
        //        String query = "INSERT INTO tblUser WHERE (Username, Password)" + "VALUES (@Username, @Password)";

        //        try
        //        {
        //            if (sqlCon.State == System.Data.ConnectionState.Closed)
        //                sqlCon.Open();
        //            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
        //            sqlCmd.ExecuteNonQuery();
        //            sqlCmd.Parameters.Add("@Username", MySqlDbType.VarChar, 60).Value = Username;
        //            sqlCmd.Parameters.Add("@Password", MySqlDbType.VarChar, 60).Value = Password;
        //            // hash password
        //            utils.hashPassword(txtPassword.Text);
        //            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
        //        }
        //        //    if (count == 1)
        //        //    {
        //        //        //information inserted
        //        //        MainWindow Main = new MainWindow();
        //        //        //the page it opens
        //        //        Main.Show();



        //        //    }
        //        //    else
        //        //    {
        //        //        //Wrong credintials!
        //        //        MessageBox.Show("Infromation has a problem!");
        //        //    }
        //        //}
        //        catch (Exception ex)
        //        {
        //           MessageBox.Show(ex.Message);
        //        }
        //        //finally
        //        //{
        //        //    sqlCon.Close();
        //        //}
        //    }


        //}
        //    }
        //}
    }
}
