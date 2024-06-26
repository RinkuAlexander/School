using School.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School.Repository
{
    public class StudentMang
    {
        public string AddStudentDetails(Student objstudent)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Student", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 1);
                com.Parameters.AddWithValue("@Name", objstudent.Name);
                com.Parameters.AddWithValue("@Address", objstudent.Address);
                com.Parameters.AddWithValue("@Class", objstudent.Class);
                com.Parameters.AddWithValue("@Division", objstudent.Division);
                com.Parameters.AddWithValue("@Status", objstudent.Status);
                con.Open();
                result = com.ExecuteNonQuery().ToString();
                //result = com.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }

        }

        public List<Student> GetStudentDetails(string id)
        {
            List<Student> studentlist = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString()))
            {
                try
                {
                    using (SqlCommand com = new SqlCommand("Student", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Query", 2);

                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(com))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                Student sobj = new Student
                                {
                                    id = Convert.ToInt32(row["id"]),
                                    Name = row["Name"].ToString(),
                                    Address = row["Address"].ToString(),
                                    Class = row["Class"].ToString(),
                                    Division = row["Division"].ToString(),
                                    Status = row["Status"].ToString(),
                                   
                                };

                                studentlist.Add(sobj);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Optionally log the error
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return studentlist;
        }
    }
}