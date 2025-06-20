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
        public static FaceRecognitionResult Run(byte[] referenceImageBytes, string capturedImagePath)
        {
            // 1. Guardar imagem da BD como reference.jpg (em disco temporário)
            var referencePath = Path.Combine(Path.GetTempPath(), "reference.jpg");
            File.WriteAllBytes(referencePath, referenceImageBytes);

            // 2. Chamar o script Python com os dois caminhos
            var processInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"face_recognition_api.py \"{referencePath}\" \"{capturedImagePath}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(processInfo);
            string output = process!.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // 3. Deserializar output JSON
            var result = JsonSerializer.Deserialize<FaceRecognitionResult>(output);
            return result ?? new FaceRecognitionResult { match = false, email = null };
        }
    }
}
