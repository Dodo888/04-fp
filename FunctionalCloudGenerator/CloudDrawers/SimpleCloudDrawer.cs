using System;
using System.Collections.Generic;
using System.Drawing;

namespace FunctionalCloudGenerator.CloudDrawers
{
    public static class SimpleCloudDrawer
    {
        public static Bitmap FormCloud(Configuration config, List<string> words)
        {
            var bitmap = new Bitmap(config.Width, config.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                PointF offset = new PointF(0, 0);
                float minOffsetForNextColumn = 0;
                graphics.Clear(ColorTranslator.FromHtml(config.BackgroundColor));
                for (var i = 0; i < words.Count; i++)
                {
                    var font = new Font(config.Font, GetFontSize(i, config));
                    SizeF textSize = graphics.MeasureString(words[i], font);
                    if (!HasEnoughSpaceInColumn(offset, textSize, bitmap.Height))
                    {
                        offset = new PointF(offset.X + minOffsetForNextColumn, 0);
                        minOffsetForNextColumn = 0;
                    }
                    if (!HasEnoughSpaceAtBitmap(offset, bitmap.Width))
                        break;
                    graphics.DrawString(words[i], font,
                        new SolidBrush(ColorTranslator.FromHtml(GetColor(i, config))),
                        offset);
                    offset.Y += textSize.Height;
                    minOffsetForNextColumn = Math.Max(minOffsetForNextColumn, textSize.Width);
                }
            }
            return bitmap;
        }

        private static int GetFontSize(int count, Configuration config)
        {
            return Math.Max(config.MaxFontSize - 2*count, config.MinFontSize);
        }

        private static string GetColor(int count, Configuration config)
        {
            return config.Colors[count%config.Colors.Count];
        }

        private static bool HasEnoughSpaceInColumn(PointF offset, SizeF textSize, int height)
        {
            return (offset.Y + textSize.Height <= height);
        }

        private static bool HasEnoughSpaceAtBitmap(PointF offset, int width)
        {
            return (offset.X < width);
        }
    }
}
