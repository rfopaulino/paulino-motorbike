using SkiaSharp;

namespace Paulino.Motorbike.Infra.CrossCutting.CustomValidations
{
    public static class ImageExtensionValidation
    {
        public static bool Validate(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return false;
            }

            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (SKCodec codec = SKCodec.Create(ms))
                    {
                        if (codec == null)
                        {
                            return false;
                        }

                        return codec.EncodedFormat == SKEncodedImageFormat.Png || codec.EncodedFormat == SKEncodedImageFormat.Bmp;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
