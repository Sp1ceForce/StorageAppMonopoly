using Newtonsoft.Json;
using System;

namespace StorageAppLogic.Models
{
    public abstract class BaseObject
    {
        public Guid Id { get; private set; }
        [JsonProperty]
        public DimensionalData DimensionalData { get; private set; }
        public abstract double Weight { get; }
        public abstract uint Volume { get;}
        public BaseObject(Guid id, DimensionalData dimensionalData)
        {  
            Id = id;
            DimensionalData = dimensionalData;
        }
        public BaseObject(DimensionalData dimensionalData)
        {

            Id = Guid.NewGuid();
            DimensionalData = dimensionalData;
        }
    }
}
