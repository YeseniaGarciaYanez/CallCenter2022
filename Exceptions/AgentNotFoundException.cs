public class StationNotFoundException : Exception
{
    private string _message;
    public override string Message => _message;

    public StationNotFoundException(int id)
    {
        _message = "Could Not find Agent With id " + id.ToString();
    }
}