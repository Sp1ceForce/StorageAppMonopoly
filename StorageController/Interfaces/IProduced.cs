using System;

namespace StorageAppLogic.Interfaces
{
    ///<summary>
    ///Интерфейс для объектов с датой производства
    /// </summary>
    public interface IProduced
    {
        public DateTime ProductionDate { get; }
    }
}
