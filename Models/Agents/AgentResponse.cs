public class AgentResponse : JsonResponse
{
    public Agent Agent { get; set; }

    public static AgentResponse GetResponse(Agent agent)
    {
        AgentResponse r = new AgentResponse();
        r.Status = 0;
        r.Agent = agent;
        return r;
    }
}