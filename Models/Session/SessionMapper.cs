using System.Collections.Generic;
using System.Data;

public class SessionMapper
{
    /// <summary>
    /// Convert DataRow to Agent object
    /// </summary>
    /// <param name="row" > Data Row </param>
    /// <returns></returns>
    public static Session ToObject(DataRow row)
    {
        int id = (int)row["id"];
        DateTime dateTimeLogin = (DateTime)row["dateTimeLogin"];
        DateTime dateTimeLogout = row["dateTimeLogout"] != DBNull.Value ? (DateTime)row["dateTimeLogout"] : DateTime.MinValue;
        int idAgent = (int)row["idAgent"];
        int idStation = (int)row["idStation"];
        int idCurrentCall = row["idCurrentCall"] != DBNull.Value ? (int)row["idCurrentCall"] : 0;
        bool active = (bool)row["active"];
        // return session
        return new Session(id, dateTimeLogin, dateTimeLogout, idAgent, idStation, idCurrentCall, active);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Table"></param>
    /// <returns></returns>
    public static List<Session> ToList(DataTable table)
    {

        List<Session> list = new List<Session>();
        foreach (DataRow row in table.Rows)
        {
            //add to list
            list.Add(SessionMapper.ToObject(row));
        }
        return list;
    }
}