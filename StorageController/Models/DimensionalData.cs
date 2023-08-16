using System;

namespace StorageAppLogic.Models
{
    public struct DimensionalData
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint Depth { get; private set; }
        public DimensionalData(uint width, uint height, uint depth)
        {
            if (width == 0 || depth == 0 || height == 0) throw new ArgumentOutOfRangeException("Can't create an object with 0 in width, depth, height or weight");

            Width = width;
            Height = height;
            Depth = depth;
        }
    }
}
