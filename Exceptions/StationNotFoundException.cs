public class AgentNotFoundException : Exception
{
    private string _message;
    public override string Message => _message;

    public AgentNotFoundException(int id)
    {
        _message = "Could Not find Agent With id " + id.ToString();
    }
}