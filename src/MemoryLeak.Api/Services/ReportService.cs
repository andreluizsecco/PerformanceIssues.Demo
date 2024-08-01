using System.Collections.Concurrent;
using System.Text;

namespace MemoryLeak.Api.Services;

public class ReportService
{
    private static Dictionary<Guid, string> _results = new Dictionary<Guid, string>();

    public Guid Generate()
    {
        var requestId = Guid.NewGuid();

        Task.Run(() =>
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 5000; i++)
            {
                var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                sb.Append($"This is a test: {dateTime}");
            }

            _results.Add(requestId, sb.ToString());
            SaveResult(requestId, sb.ToString());

        });

        return requestId;
    }

    public void SaveResult(Guid requestId, string result)
    {
        File.WriteAllText($"Reports\\{requestId}.txt", result);
    }
}
