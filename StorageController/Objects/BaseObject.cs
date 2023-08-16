using System;

namespace StorageController.Objects
{
    public abstract class BaseObject
    {
        public Guid Id { get; private set; }
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint Depth { get; private set; }
        public double ObjectWeight { get; protected set; }
        public abstract uint Volume { get;}
        public BaseObject(Guid id, uint width, uint height, uint depth, double weight)
        {
            if (width == 0 || depth == 0 || weight == 0 || height == 0) throw new ArgumentOutOfRangeException("Can't create box with 0 in width, depth, height or weight");
            
            Id = id;
            SetBaseValues(width, height, depth, weight);
        }
        public BaseObject(uint width, uint height, uint depth, double weight)
        {
            if (width == 0 || depth == 0 || weight == 0 || height == 0) throw new ArgumentOutOfRangeException("Can't create box with 0 in width, depth, height or weight");

            Id = Guid.NewGuid();
            SetBaseValues(width, height, depth, weight);
        }
        private void SetBaseValues(uint width, uint height, uint depth, double weight)
        {
            Width = width;
            Height = height;
            Depth = depth;
            ObjectWeight = weight;
        }
    }
}
