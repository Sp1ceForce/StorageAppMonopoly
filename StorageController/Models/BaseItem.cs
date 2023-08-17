using Newtonsoft.Json;
using System;

namespace StorageAppLogic.Models
{
    public abstract class BaseItem
    {
        public Guid Id { get; private set; }
        [JsonProperty]
        public DimensionalData DimensionalData { get; private set; }
        public abstract double Weight { get; }
        public abstract double Volume { get;}
        public BaseItem(Guid id, DimensionalData dimensionalData)
        {  
            Id = id;
            DimensionalData = dimensionalData;
        }
        public BaseItem(DimensionalData dimensionalData)
        {
            Id = Guid.NewGuid();
            DimensionalData = dimensionalData;
        }
    }
}
