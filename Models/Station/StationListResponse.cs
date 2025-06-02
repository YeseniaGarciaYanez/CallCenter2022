public class StationListResponse : JsonResponse
{
    public List<Station> stations { get; set; }

    public static StationListResponse GetResponse(List<Station> station)
    {
        StationListResponse r = new StationListResponse();
        r.Status = 0;
        r.stations = station;
        return r;
    }
}
