public class SessionListResponse : JsonResponse
{
    public List<Session> Sessions { get; set; }

    public static SessionListResponse GetResponse(List<Session> session)
    {
        SessionListResponse r = new SessionListResponse();
        r.Status = 0;
        r.Sessions = session;
        return r;
    }
}
