﻿using System;

namespace StorageAppLogic.Interfaces
{
    ///<summary>
    ///Интерфейс для объектов со сроком годности
    /// </summary>
    public interface IExpirable
    {
        //Тут стоило вообще использовать DateOnly, да вот только он появился только в следующей версии .Net'а
        public DateTime ExpirationDate { get; }
    }
}
