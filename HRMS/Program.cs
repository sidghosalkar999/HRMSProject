using System;
using System.Data;
using System.Data.SqlClient;

namespace HRMS
{
    public class Class1
    {
        static string constr = "data source=DESKTOP-V1RC23K\\SQLEXPRESS;initial catalog=master;integrated security=True;";
        public void DisplayHRMS()
        {
            DataTable DT = ExecuteData("select * from HRMS");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("=====================================================================");
                Console.WriteLine("DATABASE RECORDS");
                Console.WriteLine("=====================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["EMPID"].ToString() + " " + row["EMPPHONENO"].ToString() + " " + row["EMPNAME"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("No employee found in database table!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(String Query)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    sqlcon.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public void AddHRMS()
        {
            string EMPID = string.Empty;
            string EMPPHONENO = string.Empty;
            string EMPNAME = string.Empty;

            Console.WriteLine("Insert  employee: ");

            Console.Write("Enter EmpID: ");
            EMPID = Console.ReadLine();

            Console.Write("Enter EmpPHONENO: ");
            EMPPHONENO = Console.ReadLine();

            Console.Write("Enter EMPNAME: ");
            EMPNAME = Console.ReadLine();

            ExecuteCommand(String.Format("Insert into HRMS(EMPID,EMPPHONENO,EMPNAME) values ('{0}','{1}','{2}')", EMPID, EMPPHONENO, EMPNAME));
        }
        public bool ExecuteCommand(string queury)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(queury, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
            return true;
        }
        public void EditHRMS()
        {
            string EMPID = string.Empty;
            string EMPPHONENO = string.Empty;
            string EMPNAME = string.Empty;

            Console.WriteLine("Edit existing Employee:  ");
            Console.WriteLine("Insert employee: ");

            Console.Write("Enter EmpID: ");
            EMPID = Console.ReadLine();

            Console.Write("Enter EmpPHOENNO: ");
            EMPPHONENO = Console.ReadLine();

            Console.Write("Enter EMPNAME: ");
            EMPNAME = Console.ReadLine();

            ExecuteCommand(String.Format("Update HRMS set EMPID = '{0}', EMPPHONENO = '{1}', EMPNAME = '{2}' where EMPID = '{2}')", EMPID, EMPNAME, EMPPHONENO));
        }

        public void DeleteHRMS()
        {
            string EMPID = string.Empty;

            Console.WriteLine("Delet Existing EMPLOYEE: ");

            Console.Write("Enter EmpID ");
            EMPID = Console.ReadLine();

            ExecuteCommand(String.Format("Delete from HRMS where EMPID = '{0}')", EMPID));

            Console.WriteLine("Employee details deleted from the database!" + Environment.NewLine);
        }

    }


}
