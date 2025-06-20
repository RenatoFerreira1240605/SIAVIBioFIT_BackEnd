using System.Diagnostics;
using System.Text.Json;

namespace SIAVIBioFITBackEnd.Utils
{
    public class FaceRecognitionResult
    {
        public bool match { get; set; }
        public string? email { get; set; }
    }

    public static class FaceRecognitionHelper
    {
        public static async Task<FaceRecognitionResult?> CallPythonApiAsync(byte[] referenceImage, string capturedPath)
        {
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();

            content.Add(new ByteArrayContent(referenceImage), "reference", "reference.jpg");
            content.Add(new StreamContent(File.OpenRead(capturedPath)), "image", "captured.jpg");

            var response = await client.PostAsync("https://siavibiofit-faceapi.onrender.com/recognize", content);
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<FaceRecognitionResult>(json);
        }

    }
}
