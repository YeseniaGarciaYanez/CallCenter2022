public class StationResponse : JsonResponse
{
    public Station Station { get; set; }

    public static StationResponse GetResponse(Station station)
    {
        StationResponse r = new StationResponse();
        r.Status = 0;
        r.Station = station;
        return r;
    }


}