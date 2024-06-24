namespace DGII_Connect;
public static class FileReader
{
    public static string[] ReadJsonFile(string filePath)
    {
        try
        {
            return File.ReadAllLines(filePath);
        }
        catch (FileNotFoundException ex)
        {
            Logger.LogError($"File not found: {filePath}. Exception: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Logger.LogError($"Access denied to file: {filePath}. Exception: {ex.Message}");
        }
        catch (IOException ex)
        {
            Logger.LogError($"I/O error while reading file: {filePath}. Exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Unexpected error while reading file: {filePath}. Exception: {ex.Message}");
        }

        return [];
    }
}