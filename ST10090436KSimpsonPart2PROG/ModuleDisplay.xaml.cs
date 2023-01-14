using System;
using System.Collections.Generic;
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
using System.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;

namespace ST10090436KSimpsonPart2PROG
{
    /// <summary>
    /// Interaction logic for ModuleDisplay.xaml
    /// </summary>
    public partial class ModuleDisplay : Page
    {
        //array list for storing temp data 
        ArrayList userData = new ArrayList();

        public SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

        private static string strUserDetails = "";

        //String modCode;
       // public modulesLibrary mObj = new modulesLibrary();
        public ModuleDisplay( String UserLogin)
        {
            
            strUserDetails = UserLogin;
            // error handling
            try
            {
                InitializeComponent();
                //
                //FillDataGrid();

                // connection
                SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                sqlCon.Open();

                // query
                String query = "SELECT ModuleCode, ModuleName, HoursPerWeek FROM [dbo].[tblModules] WHERE Username ='" + strUserDetails + "';";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();

                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("[dbo].[tblModules]");
                sqlAdp.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView;
                sqlAdp.Update(dt);

                //String query = "SELECT ModuleCode, ModuleName, HoursPerWeek FROM [dbo].[tblModules] WHERE Username ='" + strUserDetails + "';";
                //SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);

                //DataSet Output = new DataSet();
                //sqlAdp.Fill(Output, "[dbo].[tblModules]");
                //listDisplay.DataSource = Output.Tables["[dbo].[tblModules]"].DefaultView;
                //using (SqlCommand sqlCmd = new SqlCommand(query, sqlCon))
                //{
                //    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            //storing the users data temporarily until happy with the added data
                //            UserData temp = new UserData(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6));
                //            userData.Add(temp);
                //        }
                //        foreach(UserData userData in userData)
                //        {
                //            //UserData.Items.Add(userData.ModuleCode+ " " + userData.ModuleName + " " + userData.HoursPerWeek);
                //        }
                //    }
                //}
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlCon.Close();
            }

        }
        //public void FillDataGrid()
        //{
        //    SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //    string sqlConn = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;
        //    string sqlCmdd = string.Empty;
            
        //        sqlCmdd = "SELECT ModuleCode, ModuleName, HoursPerWeek FROM [dbo].[tblModules] WHERE Username ='" + strUserDetails + "';";
        //        SqlCommand sqlCmd = new SqlCommand(sqlCmdd, sqlCon);
        //        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        listDisplay.ItemsSource = dt.DefaultView;
            
        //}
        private void Next_Click(object sender, RoutedEventArgs e)
        {

            HoursSpent hs = new HoursSpent();
            this.NavigationService.Navigate(hs);
            // (Troelsen & Japikse, 2021)
       }
    }
}




            // use a select * where username = txtUsername.Text
            //            modCode = val;



//                //strUserDetails = UserLogin;

//                //using Linq
//                //var module = from m in Module1.ml.modList
//                //             select m;
//                //foreach (var mod in module)
//                //{
//                //    listDisplay.Items.Add("\n\rModule Info: " + mod.code);

//                //}

//                //var hour = from h in Module1.ml.hoursList
//                //           select h;
//                //foreach(var hou in hour)
//                //{
//                //    listDisplay.Items.Add("Self Study Hours - " + hou);
//                //}

//                var values = from value in ModulesPage.ml.modHours
//                             select value;

//                foreach (KeyValuePair<string, double> keyValue in values)
//                {
//                    listDisplay.Items.Add("\r Module Code: " + keyValue.Key + "\r Self Study Hours : " + keyValue.Value);
//                }

//            }

//            catch (Exception ex)
//            {
//                // displaying the error to the user
//                MessageBox.Show("The error identified was: " + ex.Message);
//            }


//        }

//        private void Next_Click(object sender, RoutedEventArgs e)
//        {

//            HoursSpent hs = new HoursSpent();
//            this.NavigationService.Navigate(hs);

//            // (Troelsen & Japikse, 2021)
//        }
//    }
//}
