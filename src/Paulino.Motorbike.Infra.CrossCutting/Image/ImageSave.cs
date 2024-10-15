namespace Paulino.Motorbike.Infra.CrossCutting.Image
{
    public static class ImageSave
    {
        public static void Save(string base64Image, string filePath)
        {
            try
            {
                if (base64Image.StartsWith("data:image/png;base64,"))
                {
                    base64Image = base64Image.Substring("data:image/png;base64,".Length);
                }

                byte[] imageBytes = Convert.FromBase64String(base64Image);

                File.WriteAllBytes(filePath, imageBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar a imagem: {ex.Message}");
            }
        }
    }
}
