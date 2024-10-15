﻿using SkiaSharp;

namespace Paulino.Motorbike.Infra.CrossCutting.Image
{
    public static class ImageExtensionValidation
    {
        public static bool Validate(string base64)
        {
            var extension = ImageGetExtension.Get(base64);

            if (extension == null)
            {
                return false;
            }

            return extension == SKEncodedImageFormat.Png || extension == SKEncodedImageFormat.Bmp;
        }
    }
}
