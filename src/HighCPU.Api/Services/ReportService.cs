namespace HighCPU.Api.Services;

public class ReportService
{
    public Guid Generate()
    {
        var requestId = Guid.NewGuid();

        Task.Run(() =>
        {
            // Simulating high CPU usage with string manipulations
            string result = string.Empty;
            for (int i = 0; i < 5000; i++)
            {
                var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                result = result + $"This is a test: {dateTime}";
            }

            // Save the result to a file
            SaveResult(requestId, result);
        });

        return requestId;
    }

    public void SaveResult(Guid requestId, string result)
    {
        // Write result to a file
    }
}
