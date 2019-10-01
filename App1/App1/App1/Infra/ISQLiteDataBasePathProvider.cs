namespace App1.Infra
{
    public interface ISQLiteDataBasePathProvider
    {
        string GetDataBasePath(string nomeBase);
    }
}
