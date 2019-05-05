using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

        public void AddAnimals(string name,decimal weight, decimal height)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Animals   (Height,Name,Weight) values (@Height,@Names,@Weigth)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter{Value = name,ParameterName = "@Names"});
            cmd.Parameters.Add(new SqlParameter { Value = weight, ParameterName = "@Weigth" });
            cmd.Parameters.Add(new SqlParameter { Value = height, ParameterName = "@Height" });
            cmd.ExecuteNonQuery();
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
