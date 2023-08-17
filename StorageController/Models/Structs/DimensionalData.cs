
using Newtonsoft.Json;

namespace StorageAppLogic.Models.Structs
{
    public struct DimensionalData
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Depth { get; private set; }
        [JsonConstructor]
        public DimensionalData(double width, double height, double depth)
        {
            if (width <= 0 || depth <= 0 || height <= 0) throw new System.ArgumentOutOfRangeException("Width, depth or height can't be equal or less than 0");

            Width = width;
            Height = height;
            Depth = depth;
        }
    }
}
