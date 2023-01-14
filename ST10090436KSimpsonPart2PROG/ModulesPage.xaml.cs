using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
    /// Interaction logic for ModulesPage.xaml
    /// </summary>
    public partial class ModulesPage : Page
    {
        //array list for storing temp data 
        ArrayList userData = new ArrayList();
        // connection
        public SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

        private static string strUserDetails = "";
        public ModulesPage(String UserLogin)
        {
            InitializeComponent();
            strUserDetails = UserLogin;
        }
        public static string moduleVal;
        public static double ssHours;
        public static modulesLibrary ml = new modulesLibrary(); //a public object 

        // creating the button that holds all functions and stores data
        private void ClickP2(object sender, RoutedEventArgs e)
        {

            try // error handling all the results
            {
                //checking to see that the textboxs have been filled out
                if (txtModuleCode.Text.Equals(""))
                {
                    MessageBox.Show("Module Code is Empty!");
                }
                else if (txtModuleName.Text.Equals(""))
                {
                    MessageBox.Show("Module Name is Empty!");
                }
                else if (txtNumOfCredit.Text.Equals(""))
                {
                    MessageBox.Show("Number Of Credits is Empty!");
                }
                else if (txtHoursWeek.Text.Equals(""))
                {
                    MessageBox.Show("Hours Per Week is Empty!");
                }
                else if (txtStartDate.Text.Equals(""))
                {
                    MessageBox.Show("Start Date is Empty!");
                }
                else if (txtNumOfWeeks.Text.Equals(""))
                {
                    MessageBox.Show("Number of weeks is Empty!");
                }
                else
                {
                    //If statement
                    MessageBoxResult result = MessageBox.Show("Would you like to enter another Module? ", "CHOICE", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        //popup if they chose 'YES'
                        ModulesPage m1 = new ModulesPage(txtModuleCode.Text);
                        this.NavigationService.Navigate(m1);
                    }
                    else
                    {
                        // MessageBox.Show("This" + ssHours);
                        ModuleDisplay md = new ModuleDisplay(moduleVal);
                        this.NavigationService.Navigate(md);
                    }
                }
                // (Troelsen & Japikse, 2021)

                // creating the Query
                String query = "INSERT INTO [dbo].[tblModules](ModuleCode, ModuleName, NumOfCredits, HoursPerWeek, StartDate, NumOfweeks, Username) VALUES (@ModuleCode, @ModuleName, @NumOfCredits, @HoursPerWeek, @StartDate, @NumOfweeks, @Username);";
                   
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@ModuleCode", txtModuleCode.Text);
                    sqlCmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text);
                    sqlCmd.Parameters.AddWithValue("@NumOfCredits", txtNumOfCredit.Text);
                    sqlCmd.Parameters.AddWithValue("@HoursPerWeek", txtHoursWeek.Text);
                    sqlCmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
                    sqlCmd.Parameters.AddWithValue("@NumOfWeeks", txtNumOfWeeks.Text);
                    sqlCmd.Parameters.AddWithValue("@Username", strUserDetails);

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                    //SqlDataAdapter sqlAdp = new SqlDataAdapter();
                    //sqlAdp.InsertCommand = sqlCom;

                    // int id = Convert.ToInt32( sqlAdp.InsertCommand.ExecuteScalar());
                    // MessageBox.Show("Data has been added to the databse : " + id);
                    //sqlAdp.Dispose();
                    //storing the users data temporarily until happy with the added data
                    //UserData temp = new UserData(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6));
                    //userData.Add(temp);
                
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModuleDisplay ds = new ModuleDisplay(txtModuleCode.Text);
            this.NavigationService.Navigate(ds);
        }
    }
}




            // *****************      part one data storing method
//
//
//
//            moduleVal = Code.Text;
//                //Storing the values entered
//                //ml.modList.Add(new modulesLibrary()
//                //{

//                ml.code = Code.Text;
//                ml.modules = Name.Text;
//                ml.numCredit = int.Parse(numOfCredit.Text);
//                ml.hoursWeek = int.Parse(HoursWeek.Text);
//                ml.startDate = StartDate.SelectedDate.Value;
//                ml.numWeeks = int.Parse(numOfWeeks.Text);
//                //});

//                ssHours = ml.Calculation(int.Parse(numOfCredit.Text), int.Parse(HoursWeek.Text), int.Parse(numOfWeeks.Text));
//                // ml.hoursList.Add(ssHours);
//                ml.modHours.Add(ml.code, ml.ssHours);
//                // untill here 
//                //If statement
//                MessageBoxResult result = MessageBox.Show("Would you like to enter another Module? ", "CHOICE", MessageBoxButton.YesNo);
//                if (result == MessageBoxResult.Yes)
//                {
//                    //popup if they chose 'YES'
//                    // ModulesPage m1 = new ModulesPage();
//                    // this.NavigationService.Navigate(m1);

//                }
//                else
//                {
//                    // MessageBox.Show("This" + ssHours);
//                    ModuleDisplay md = new ModuleDisplay(moduleVal);
//                    this.NavigationService.Navigate(md);
//                }

//                // (Troelsen & Japikse, 2021)

//            }
//            catch (System.StackOverflowException ex)
//            {
//                //displaying the error if it occures
//                MessageBox.Show(ex.ToString());
//            }

//        }

//        private void View(object sender, RoutedEventArgs e)
//        {
//            ModuleDisplay md = new ModuleDisplay(moduleVal);
//            this.NavigationService.Navigate(md);
//        }
//    }
//}