public class AgentListResponse : JsonResponse
{
    public List<Agent> Agents { get; set; }

    public static AgentListResponse GetResponse(List<Agent> agents)
    {
        AgentListResponse r = new AgentListResponse();
        r.Status = 0;
        r.Agents = agents;
        return r;
    }
}
