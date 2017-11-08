using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ScrambledImages
{
    class Program
    {
        private static readonly Color Red = Color.FromArgb(255, 0, 0);
        static void Main(string[] args)
        {
            var baseMap = new Bitmap(args[0]);
            var resultMap = CreateNewMap(baseMap);
            using (var stream = File.Create(Path.Combine(Path.GetDirectoryName(args[0]), "Result.png")))
            {
                resultMap.Save(stream, ImageFormat.Bmp);
            }
        }

        private static Bitmap CreateNewMap(Bitmap baseMap)
        {
            var resultMap = new Bitmap(baseMap.Width, baseMap.Height);
            for (int x = 0; x < baseMap.Width; x++)
            {
                var rowList = new List<Color>();
                for (int y = 0; y < baseMap.Height; y++)
                {
                    var pixel = baseMap.GetPixel(y, x);
                    rowList.Add(pixel);
                }
                var colors = GenerateRow(rowList);
                for (int i = 0; i < colors.Count; i++)
                {
                    resultMap.SetPixel(i, x, colors[i]);
                }
            }
            return resultMap;
        }

        public static List<Color> GenerateRow(List<Color> input)
        {
            var count = input.Count(x => x == Red);
            var index = input.IndexOf(Red);
            var list = new List<Color>();
            var startRange = input.GetRange(index + count, (input.Count - index) - count);
            var endRange = input.GetRange(0, index + count);
            list.AddRange(startRange);
            list.AddRange(endRange);
            return list;
        }
    }
}