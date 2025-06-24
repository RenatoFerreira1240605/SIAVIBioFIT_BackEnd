using System.Net.Http.Json;

public class GestureService
{
    private readonly HttpClient _httpClient;
    private const string BASE_URL = "https://siavibiofit-backend.onrender.com/api/gesture/submit";

    public GestureService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<int> GetRepetitionsAsync(string exercise)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<RepetitionResponse>($"{BASE_URL}/get/{exercise}");
            return response.Reps;
        }
        catch
        {
            return -1;
        }
    }
}

public class RepetitionResponse
{
    public string Exercise { get; set; }
    public int Reps { get; set; }
}
