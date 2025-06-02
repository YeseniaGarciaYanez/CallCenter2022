using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;

public class StationMapper
{
    /// <summary>
    /// Convert DataRow to Agent object
    /// </summary>
    /// <param name="row" > Data Row </param>
    /// <returns></returns>
    public static Station ToObject(DataRow row)
    {
        int id = (Int32)row["id"];
        int rowNumber = (Int32)row["rowNumber"];
        int deskNumber = (Int32)row["deskNumber"];
        string ipAddress = (String)row["ipAddress"];
        bool active = (bool)row["active"];
        // return agent

        StationLocation location = new StationLocation(rowNumber, deskNumber);

        return new Station(id, location, ipAddress, active);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Table"></param>
    /// <returns></returns>
    public static List<Station> ToList(DataTable table)
    {

        List<Station> list = new List<Station>();
        foreach (DataRow row in table.Rows)
        {
            //add to list
            list.Add(StationMapper.ToObject(row));
        }
        return list;
    }
}