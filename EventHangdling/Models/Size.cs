﻿namespace EventHangdling.Models
{
    public class Size
    {
        public Size (int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}