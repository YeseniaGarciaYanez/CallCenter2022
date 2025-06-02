using System.Data;
using Microsoft.Data.SqlClient;

public class SqlServerConnection
{

    #region connections

    private static string GetConnectionString()
    {
        return "Data Source=" + Config.Configuration.sqlServer.Server + ";" +
               "Initial Catalog=" + Config.Configuration.sqlServer.Database + ";" +
                "Integrated Security=" + Config.Configuration.sqlServer.TrustServer_Certificate + ";" +
                "TrustServerCertificate=" + Config.Configuration.sqlServer.Trusted_Connection + ";";
    }

    private static SqlConnection GetConnection()
    {
        var connection = new SqlConnection(GetConnectionString());
        connection.Open();
        return connection;
    }


    #endregion

    #region methods

    private static SqlConnection Open()
    {

        SqlConnection connection;
        connection = new SqlConnection(GetConnectionString());
        try { connection.Open(); }  
        catch (ArgumentException e) { } catch (SqlException e) { } catch (Exception e) { }

        return connection;
    }

    


    public static DataTable ExecuteQuery(SqlCommand command)
    {
        //Result
        DataTable table = new DataTable();
        //Get connection
        SqlConnection connection = GetConnection();
        //Connection is open
        if (connection.State == ConnectionState.Open)
        {
            try
            {
                //Assign connection
                command.Connection = connection;
                //Adapter
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                // execute querry

                adapter.Fill(table);

            }
            catch (SqlException e)
            {
            }
            catch (Exception e)
            {
            }
        }
        return table;
    }


    public static int ExecuteProcedure(SqlCommand command)
    {
        //result
        int result = 999;
        // conectivity
        SqlConnection connection = GetConnection();
        //Check if connection is open
        if (connection.State == ConnectionState.Open)
        {
            // Assign connection
            command.Connection = connection;
            // Declare Command as Store procedure
            command.CommandType = CommandType.StoredProcedure;
            // add return parameter
            SqlParameter returnParameter = new SqlParameter("@status", DbType.Int32);
            // parameter is output
            returnParameter.Direction = ParameterDirection.Output;
            // add parameter 
            command.Parameters.Add(returnParameter);
            // execute procedure
            command.ExecuteNonQuery();
            // read parameter result
            result = (Int32)command.Parameters["@status"].Value;
        }

        return result;
    }


    #endregion

}