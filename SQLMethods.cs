using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;

namespace SIClientImport
{
    class SQLMethods
    {
        public static string SetConnectionString()
        {
            string conn = "";
            switch (Properties.Settings.Default.TestOrProd)
            {
                case "Prod":
                    conn = Properties.Settings.Default.ProdConnectionString;
                    break;
                case "Test":
                    conn = Properties.Settings.Default.TestConnectionString;
                    break;
                case "Local":
                    conn = Properties.Settings.Default.LocalConnectionString;
                    break;
                default:
                    break;
            }

            return conn;
        }

        public static bool TestConnection()
        {
            bool result = false;
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT COUNT(*) FROM dbo.Claim WHERE ClaimId = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    int count = 0;
                    string param2 = "1";
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@value";
                    param.Value = param2;

                    _cmd.Parameters.Add(param);
                    
                    //_cmd.Parameters.AddWithValue("value", param);
                    //_cmd.Parameters["value"].Value = param;
                    _con.Open();
                    count = (int) _cmd.ExecuteScalar();
                    _con.Close();

                    if (count>0) { result = true; }

                }
            }
            return result;
        }

        public static string RetrieveValue (string whereValue)
        {
            string result = "";

            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT PolicyID FROM dbo.Claim WHERE ClaimID = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    SqlParameter value = new SqlParameter();
                    value.ParameterName = "@value";
                    value.Value = whereValue;
                    _cmd.Parameters.Add(value);


                    _con.Open();
                    try
                    {
                        result = _cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        result = "";
                    }
                    _con.Close();
                }
            }
            return result;
        }

        public static string RetrievePolicyID(string whereValue)
        {
            string result = "";

            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT PolicyID FROM dbo.Policy WHERE PolicyNumber = @value AND InsuranceLineID = '1'";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@value";
                    param.Value = whereValue;

                    _cmd.Parameters.Add(param);
                    _con.Open();
                    try
                    {
                        result = _cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        result = "";
                    }
                    _con.Close();
                }
            }
            return result;
        }
        public static string RetrievePolicyPeriodID(string whereValue)
        {
            string result = "";

            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT PolicyPeriodID FROM dbo.PolicyPeriod WHERE PolicyID = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@value";
                    param.Value = whereValue;

                    _cmd.Parameters.Add(param);
                    _con.Open();
                    try
                    {
                        result = _cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        result = "";
                    }
                    _con.Close();
                }
            }
            return result;
        }

        public static bool CheckForExistingClaimID(string value)
        {
            bool result = false;
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT COUNT(*) FROM dbo.Claim WHERE ClaimId = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    int count = 0;
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    try
                    {                                            
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@value";
                    param.Value = value;
                    _cmd.Parameters.Add(param);

                    _con.Open();
                    count = (int)_cmd.ExecuteScalar();
                    _con.Close();
                    }
                    catch
                    {
                        result = false;
                    }
                    if (count > 0) { result = true; }

                }
            }
            return result;
        }

        public static bool CheckForExistingAddressBookID(string value)
        {
            bool result = false;
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT COUNT(*) FROM dbo.AddressBook WHERE AddressBookId = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    int count = 0;
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    try
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@value";
                        param.Value = value;
                        _cmd.Parameters.Add(param);

                        _con.Open();
                        count = (int)_cmd.ExecuteScalar();
                        _con.Close();
                    }
                    catch
                    {
                        result = false;
                    }
                    if (count > 0) { result = true; }

                }
            }
            return result;
        }

        public static bool CheckForExistingClaimantID(string value)
        {
            bool result = false;
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT COUNT(*) FROM dbo.Claimant WHERE ClaimantId = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    int count = 0;
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    try
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@value";
                        param.Value = value;
                        _cmd.Parameters.Add(param);

                        _con.Open();
                        count = (int)_cmd.ExecuteScalar();
                        _con.Close();
                    }
                    catch
                    {
                        result = false;
                    }
                    if (count > 0) { result = true; }

                }
            }
            return result;
        }
        public static bool CheckForExistingClaimNumber(string value)
        {
            bool result = false;
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT COUNT(*) FROM dbo.Claim WHERE ClaimNumber = @value";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    int count = 0;
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    try
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@value";
                        param.Value = value;
                        _cmd.Parameters.Add(param);

                        _con.Open();
                        count = (int)_cmd.ExecuteScalar();
                        _con.Close();
                    }
                    catch
                    {
                        result = false;
                    }
                    if (count > 0) { result = true; }

                }
            }
            return result;
        }

        public static DataTable ClaimStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Claim";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }


        public static DataTable ClaimantStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Claimant";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        public static DataTable AddressBookStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_AddressBook";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        public static DataTable EmploymentStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Employment";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }

        public static DataTable AddressBookPaymentStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_AddressBook_Payment";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                {
                    result = null;
                }
                _con.Close();
                }
            }
            return result;

        }
        public static DataTable UICustomControlsStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_UICustomControl";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        
        public static DataTable NotepadStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Notepad";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        public static DataTable ReserveStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Reserve";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        public static DataTable PaymentStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Payment";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        
        public static DataTable PayeeStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Payee";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        
        public static DataTable AttachmentStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_Attachment";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        
        public static DataTable ClaimantICDStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_ClaimantICD";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        
        public static DataTable BillReviewHeaderStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_BillReviewHeader";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
        public static DataTable BillReviewDetailStage()
        {
            DataTable result = new DataTable();
            string connectionString = SetConnectionString();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * from SUI.stg_SI_BillReviewDetail";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    try
                    {
                        _dap.Fill(result);
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    _con.Close();
                }
            }
            return result;

        }
    }
}
