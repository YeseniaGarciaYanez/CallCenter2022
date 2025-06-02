public class SessionResponse : JsonResponse
{
    public Session session{ get; set; }

    public static SessionResponse GetResponse(Session sessions)
    {
        SessionResponse r = new SessionResponse();
        r.Status = 0;
        r.session = sessions;
        return r;
    }
}