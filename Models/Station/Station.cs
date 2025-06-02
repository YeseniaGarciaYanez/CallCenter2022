
using Microsoft.Data.SqlClient;
using System.Data;
public class Station
    {


    #region statement

    private static string selectAll = @"select id, rowNumber, deskNumber, ipAddress, active from stations";

    private static string select = @"select id, rowNumber, deskNumber, ipAddress, active from stations where id = @ID";

    private static string selectRow = @"select id, rowNumber, deskNumber, ipAddress, active from stations where rowNumber = @ID";

    private static string selectDesk= @"select id, rowNumber, deskNumber, ipAddress, active from stations where deskNumber = @ID";

    private static string selectActive = @"select id, rowNumber, deskNumber, ipAddress, active from stations where active = @ID";

    #endregion


    #region attributes

    private int _id;
    private StationLocation _location;
    //private int _rowNumber;
    //private int _deskNumber;
    private string _ipAddress;
    private bool _active;


    public int id { get => _id; }
    public StationLocation location { get => _location; }
    // public int rowNumber { get => _rowNumber; }
    // public int deskNumber { get => _deskNumber; }
    public string ipAddress { get => _ipAddress; }
    public bool active { get => _active; }

    /// <summary>
    public Station(int id, StationLocation location /*int rowNumber, int deskNumber*/, string ipAddress, bool active)
    {
        _id = id;
        _location = location;
        // _rowNumber = rowNumber;
        // _deskNumber = deskNumber;
        _ipAddress = ipAddress;
        _active = active;
    }
    #endregion


    #region Commands

    public static List<Station> Get()
    {
        //command
        SqlCommand command = new SqlCommand(selectAll);
        //Populate
        return StationMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }


    public static Station Get(int id)
    {
        SqlCommand command = new SqlCommand(select);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return StationMapper.ToObject(table.Rows[0]);
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }

    public static List<Station> GetRow(int id)
    {
        SqlCommand command = new SqlCommand(selectRow);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return StationMapper.ToList(SqlServerConnection.ExecuteQuery(command));
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }

    public static List<Station> GetDesk(int id)
    {
        SqlCommand command = new SqlCommand(selectDesk);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return StationMapper.ToList(SqlServerConnection.ExecuteQuery(command));
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }

    public static List<Station> GetActive(int id)
    {
        SqlCommand command = new SqlCommand(selectActive);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return StationMapper.ToList(SqlServerConnection.ExecuteQuery(command));
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }



    #endregion


}

