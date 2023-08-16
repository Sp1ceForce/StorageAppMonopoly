using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using StorageAppLogic.Interfaces;

namespace StorageAppLogic.Models
{
    public class Pallete : BaseObject, IExpirable
    {
        private const double BaseWeight = 30;
        [JsonIgnore]
        public ReadOnlyCollection<Box> BoxesList => boxesList.AsReadOnly();
      
        [JsonProperty]
        List<Box> boxesList;
      
        public override double Weight => BoxesList.Sum(b => b.Weight) + BaseWeight;
        
        public DateTime ExpirationDate => BoxesList.Min(b => b.ExpirationDate);
 
        public Pallete(DimensionalData dimensionalData) : base(dimensionalData)
        {
            boxesList = new List<Box>();
        }
        [JsonConstructor]
        public Pallete(Guid id, DimensionalData dimensionalData) : base(id, dimensionalData)
        {
            boxesList = new List<Box>();
        }
        [JsonIgnore]
        public override uint Volume
        {
            get
            {
                uint volume = 0;
                foreach (Box box in BoxesList)
                {
                    volume += box.Volume;
                }
                volume += DimensionalData.Width * DimensionalData.Height * DimensionalData.Depth;
                return volume;
            }
        }
        public bool AddBox(Box box)
        {
            if(box.DimensionalData.Width > DimensionalData.Width || box.DimensionalData.Depth > DimensionalData.Depth) return false;
            if(BoxesList.Contains(box)) return false;
            boxesList.Add(box);
            return true;
        }
    }
}
