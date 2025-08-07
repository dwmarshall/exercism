public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        try
        {
            database.BeginTransaction();
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
