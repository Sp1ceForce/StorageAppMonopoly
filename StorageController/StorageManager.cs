using StorageAppLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAppLogic
{
    /// <summary>
    /// Класс отвечающий за работу с данными в приложении (паллеты)
    /// </summary>
    public class StorageManager
    {
        //Синглтон это такое себе, по идее лучше бы подошёл Dependency Injection, но я решил не усложнять приложение ради пары классов
        public static StorageManager Instance { get; private set; }

        public ReadOnlyCollection<Pallete> Palletes => _palletes.AsReadOnly();
        List<Pallete> _palletes;
        
        public StorageManager()
        {
            InitializeSingleton();
        }
        private void InitializeSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else throw new Exception("There is more than one instance of Storage Manager");
        }
        public void LoadData()
        {
            _palletes = SaveLoadController.LoadPalletes();
        }
        public void SaveData()
        {
            SaveLoadController.SavePalletes(_palletes);
        }
    }
}
