using SkiaSharp;

namespace Paulino.Motorbike.Infra.CrossCutting.Image
{
    public static class ImageGetExtension
    {
        public static SKEncodedImageFormat? Get(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return null;
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
                            return null;
                        }

                        return codec.EncodedFormat;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
