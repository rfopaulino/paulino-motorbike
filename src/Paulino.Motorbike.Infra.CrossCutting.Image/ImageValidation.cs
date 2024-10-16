using SkiaSharp;

namespace Paulino.Motorbike.Infra.CrossCutting.Image
{
    public class ImageValidation
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
                        return codec != null && codec.Info != null;
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
