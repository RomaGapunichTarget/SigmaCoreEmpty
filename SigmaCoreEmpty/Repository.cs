using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SigmaCoreEmpty.Models;

namespace SigmaCoreEmpty
{
    public class Repository
    {
        public SqlConnection conn;
        public Repository(SqlConnection sql)
        {
            conn = sql;

            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=adonet;Integrated Security=True";

        }

        public void Delete(int Id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Animals where Id=@Id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter{Value = Id,ParameterName = "@Id"});
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(string name, decimal weight, decimal height,int Id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Animals   set Height=@Height,Name=@Names,Weight=@Weigth where Id=@Id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter { Value = name, ParameterName = "@Names" });
            cmd.Parameters.Add(new SqlParameter { Value = weight, ParameterName = "@Weigth" });
            cmd.Parameters.Add(new SqlParameter { Value = height, ParameterName = "@Height" });
            cmd.Parameters.Add(new SqlParameter { Value = Id, ParameterName = "@Id" });
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddAnimals(string name, decimal weight, decimal height)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Animals   (Height,Name,Weight) values (@Height,@Names,@Weigth)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter { Value = name, ParameterName = "@Names" });
            cmd.Parameters.Add(new SqlParameter { Value = weight, ParameterName = "@Weigth" });
            cmd.Parameters.Add(new SqlParameter { Value = height, ParameterName = "@Height" });
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<GenarateAnimals> SelectAnimals()
        {
            List<GenarateAnimals> lstAnimals = new List<GenarateAnimals>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Animals", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            try
            {

                while (rdr.Read())
                {
                    var Name = Convert.ToString(rdr[1]);
                    var Weight = Convert.ToDecimal(rdr[2]);
                    var Height = Convert.ToDecimal(rdr[3]);
                    var Id = Convert.ToInt32(rdr[0]);
                    lstAnimals.Add(new GenarateAnimals {Height = Height, Weigth = Weight, Name = Name, Id = Id});
                }
            }
            catch(Exception e) { }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            // close the reader
            
            return lstAnimals;
        }

        public void Connect()
        {
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from Animals", conn);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            catch (Exception e)
            {
                SqlCommand cmd = new SqlCommand(@"CREATE TABLE [dbo].[Animals] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX)  NULL,
    [Weight] DECIMAL (18, 4) NULL,
    [Height] DECIMAL (18, 4) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);", conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
