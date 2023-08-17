using System;
using Newtonsoft.Json;
using StorageAppLogic.Interfaces;
using StorageAppLogic.Models.Structs;

namespace StorageAppLogic.Models
{
    /// <summary>
    /// Класс для коробки
    /// </summary>
    public class Box : BaseItem, IExpirable, IProduced
    {
        private const double DefaultExpirationDateDaysOffset = 100;
        public string ContentsName { get; private set; }

        public override double Weight => _weight;
        private double _weight;
        public override double Volume
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

        void SetValuesWithBothDates(string contentsName, double weight, DateTime productionDate, DateTime expirationDate)
        {
            _productionDate = productionDate;
            _expirationDate = expirationDate;
            ContentsName = contentsName;
            _weight = weight;
        }
        void SetValuesWithOneDate(string contentsName, double weight, DateTime productionDate)
        {
            _productionDate = productionDate;
            _expirationDate = productionDate.AddDays(DefaultExpirationDateDaysOffset);
            ContentsName = contentsName;
            _weight = weight;
        }
        //Честно говоря, не знаю - нормально ли иметь 4 перегрузки метода, но это позволяет иметь разные варианты для создания коробок что по идее хорошо
        [JsonConstructor]
        public Box(Guid id, string contentsName, DimensionalData dimensionalData, double weight, DateTime productionDate, DateTime expirationDate) 
            : base(id, dimensionalData)
        {
            SetValuesWithBothDates(contentsName, weight,productionDate,expirationDate);
        }

        public Box(string contentsName, DimensionalData dimensionalData, double weight, DateTime productionDate, DateTime expirationDate) 
            : base(dimensionalData)
        {
            SetValuesWithBothDates(contentsName, weight,productionDate,expirationDate);
        }
        public Box(Guid id, string contentsName, DimensionalData dimensionalData, double weight, DateTime productionDate) 
            : base(id, dimensionalData)
        {
            SetValuesWithOneDate(contentsName, weight, productionDate);
        }

        public Box(string contentsName, DimensionalData dimensionalData, double weight, DateTime productionDate) 
            : base(dimensionalData)
        {
            SetValuesWithOneDate(contentsName, weight, productionDate);
        }
    }
}
