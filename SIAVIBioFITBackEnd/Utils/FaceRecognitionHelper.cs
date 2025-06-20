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
        public static FaceRecognitionResult Run(string capturedImagePath)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"face_recognition_api.py \"{capturedImagePath}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(processInfo);
            string output = process!.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var result = JsonSerializer.Deserialize<FaceRecognitionResult>(output);
            return result ?? new FaceRecognitionResult { match = false, email = null };
        }
    }
}

