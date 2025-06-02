
using Microsoft.Data.SqlClient;
using System.Data;

public class Session
{

    #region properties

    // id int, dateTimeLogin datetime, dateTimeLogout datetime , IdAgent int, IdStation int, IdCurrentCall int , active int
    private int  _id { get; set; }
    private DateTime _dateTimeLogin { get; set; }
    private DateTime _dateTimeLogout { get; set; }
    private int _idAgent { get; set; }
    private int _idStation { get; set; }
    private int _idCurrentCall { get; set; }
    private bool _active { get; set; }
    #endregion


    #region getterSetter

    public int id { get => _id; }
    public DateTime dateTimeLogin { get => _dateTimeLogin; set => _dateTimeLogin = value; }
    public DateTime dateTimeLogout { get => _dateTimeLogout; set => _dateTimeLogout = value; }
    public int idAgent { get => _idAgent; set => _idAgent = value; }
    public int idStation { get => _idStation; set => _idStation = value; }
    public int idCurrentCall { get => _idCurrentCall; set => _idCurrentCall = value; }
    public bool active { get => _active; set => _active = value; }


    #endregion


    #region statements
    
    private static string selectAll = @"select id, dateTimeLogin, dateTimeLogout, idAgent, idStation, idCurrentCall, active from sessions ";

    private static string selectOne = @"select id, dateTimeLogin, dateTimeLogout, idAgent, idStation, idCurrentCall, active from sessions where id = @ID";

    private static string selectSessionAgent = @"select id, dateTimeLogin, dateTimeLogout, idAgent, idStation, idCurrentCall, active from sessions where idAgent = @ID ";

    private static string selectSessionStation = @"select id, dateTimeLogin, dateTimeLogout, idAgent, idStation, idCurrentCall, active from sessions where idStation = @ID ";

    #endregion


    public Session(int id, DateTime dateTimeLogin, DateTime dateTimeLogout, int idAgent, int idStation, int idCurrentCall, bool active)
    {
        _id = id;
        _dateTimeLogin = dateTimeLogin;
        _dateTimeLogout = dateTimeLogout;
        _idAgent = idAgent;
        _idStation = idStation;
        _idCurrentCall = idCurrentCall;
        _active = active;
    }


    public static int Login(int agentId, int pin, int stationID ) {
        //command
        SqlCommand command = new SqlCommand("spLoginAgent");
        //parameter
        command.Parameters.AddWithValue("@agentId", agentId);
        command.Parameters.AddWithValue("@agentPin", pin);
        command.Parameters.AddWithValue("@stationId", stationID);
        //execute procedure
        return SqlServerConnection.ExecuteProcedure(command);
    }

    public static List<Session> Get()
    {
        //command
        SqlCommand command = new SqlCommand(selectAll);
        //Populate
        return SessionMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }


    public static Session Get(int id)
    {
        SqlCommand command = new SqlCommand(selectOne);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return SessionMapper.ToObject(table.Rows[0]);
        }
        else
        {
            throw new AgentNotFoundException(id);
        }
    }

    public static Session GetSessionAgent(int id)
    {
        SqlCommand command = new SqlCommand(selectSessionAgent);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return SessionMapper.ToObject(table.Rows[0]);
        }
        else
        {
            throw new SessionNotFoundException(id);
        }
    }

    public static Session GetSessionStation(int id)
    {
        SqlCommand command = new SqlCommand(selectSessionStation);
        command.Parameters.AddWithValue("@ID", id);
        //Populate
        DataTable table = SqlServerConnection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            return SessionMapper.ToObject(table.Rows[0]);
        }
        else
        {
            throw new SessionNotFoundException(id);
        }
    }


}
