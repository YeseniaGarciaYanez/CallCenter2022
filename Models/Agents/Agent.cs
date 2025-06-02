using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;
using System.Data;

public class Agent
{

    #region statement

    private static string selectAll = @"
    select id, name, photo, pin
    from agents
    order by name
    ";

    private static string select = @"
    select id, name, photo, pin
    from agents
    where id = @ID
    ";

    private static string selectPin = @"
    select id, name, photo, pin
    from agents
    where pin = @ID
    ";

    #endregion

    #region attributes

    private int _id;
    private string _name;
    private int _pin;
    private string _photo;

    #endregion

    #region properties

    public int id { get => _id; }
    public string Name { get => _name; set => _name = value; }
    public int Pin{ get => _pin; set => _pin = value; }
    public string photo { get => Config.Configuration.Paths.Domain + Config.Configuration.Paths.Photos.Agents + _photo; set => _photo = value; }

    #endregion

    #region constructors
    /// <summary>
    /// Creates an empty object 
    /// </summary>
    public Agent()
    {
        _id = 0;
        _name = "";
        _pin = 0;
        _photo = "nophoto.png";
    }

    /// <summary>
    /// Creates an object with data from the arguments
    /// </summary>
    /// <param name="id">Agent_id</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="dateOfBirth">Date of birth</param>
    /// <param name="photo">Photo URL</param>
    public Agent(int id, string Name, int Pin, string photo)
    {
        _id = id;
        _name = Name;
        _pin= Pin;
        _photo = photo;
    }
    #endregion

    #region Class Methods


    public static List<Agent> Get()
    {
        //command
        SqlCommand command = new SqlCommand(selectAll);
        //Populate
        return AgentMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }


    public static Agent Get(int id) {
        SqlCommand command = new SqlCommand(select);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return AgentMapper.ToObject(table.Rows[0]);
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }

    public static Agent GetPin(int id)
    {
        SqlCommand command = new SqlCommand(selectPin);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return AgentMapper.ToObject(table.Rows[0]);
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }
    #endregion


}