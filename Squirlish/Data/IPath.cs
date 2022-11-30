namespace Squirlish.Data;

public interface IPath
{
    string GetDatabasePath(string filename = "Squirlish.db");

    void DeleteFile(string path);
}