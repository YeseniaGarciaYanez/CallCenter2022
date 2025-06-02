using System.Collections.Generic;
using System.Data;

public class AgentMapper
{
    /// <summary>
    /// Convert DataRow to Agent object
    /// </summary>
    /// <param name="row" > Data Row </param>
    /// <returns></returns>
    public static Agent ToObject(DataRow row)
    {
        int id = (Int32)row["id"];
        string name = (String)row["name"];
        string photo = (String)row["photo"];
        int pin = (Int32)row["pin"];
        // return agent

        return new Agent(id, name, pin, photo);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Table"></param>
    /// <returns></returns>
    public static List<Agent> ToList(DataTable table)
    {

        List<Agent> list = new List<Agent>();
        foreach (DataRow row in table.Rows)
        {
            //add to list
            list.Add(AgentMapper.ToObject(row));
        }
        return list;
    }
}