using System;
using Newtonsoft.Json;
using StorageAppLogic.Interfaces;

namespace StorageAppLogic.Models
{
    /// <summary>
    /// Класс для коробки
    /// </summary>
    public class Box : BaseObject, IExpirable, IProduced
    {
        public string ContentsName { get; private set; }

        public override double Weight => _weight;
        private double _weight;
        public override uint Volume
        {
            get
            {
                return DimensionalData.Width * DimensionalData.Height * DimensionalData.Depth;
            }
        }

        public DateTime ProductionDate => _productionDate;
        private DateTime _productionDate;

        public DateTime ExpirationDate => _expirationDate;
        private DateTime _expirationDate;

        [JsonConstructor]
        public Box(Guid id, string contentsName, DimensionalData dimensionalData, double weight) : base(id, dimensionalData)
        {
            ContentsName = contentsName;
            _weight = weight;
        }

        public Box(string contentsName, DimensionalData dimensionalData, double weight) : base(dimensionalData)
        {
            ContentsName = contentsName;
            _weight = weight;
        }
    }
}
