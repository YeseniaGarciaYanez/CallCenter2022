public class SessionNotFoundException : Exception
{
    private string _message;
    public override string Message => _message;

    public SessionNotFoundException(int id)
    {
        _message = "Could Not find Session With id " + id.ToString();
    }
}