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
    public class TeacherMang
    {

        public string AddTeacherDetails(Teacher objteacher)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString());
                SqlCommand com = new SqlCommand("Teacher", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Query", 1);
                com.Parameters.AddWithValue("@Name", objteacher.Name);
                com.Parameters.AddWithValue("@Address", objteacher.Address);
                com.Parameters.AddWithValue("@Contact", objteacher.Contact);
                com.Parameters.AddWithValue("@Class", objteacher.Class);
                com.Parameters.AddWithValue("@Division", objteacher.Division);
               
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

        public List<Teacher> GetTeacherDetails(string id)
        {
            List<Teacher> teacherlist = new List<Teacher>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ToString()))
            {
                try
                {
                    using (SqlCommand com = new SqlCommand("Teacher", con))
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
                                Teacher sobj = new Teacher
                                {
                                    id = Convert.ToInt32(row["id"]),
                                    Name = row["Name"].ToString(),
                                    Address = row["Address"].ToString(),
                                    Contact = row["Contact"].ToString(),
                                    Class = row["Class"].ToString(),
                                    Division = row["Division"].ToString()
                                    

                                };

                                teacherlist.Add(sobj);
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

            return teacherlist;
        }

    }
}