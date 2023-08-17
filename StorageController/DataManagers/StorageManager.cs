using StorageAppLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StorageAppLogic.DataManagers
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
        public void AddRandomPalletes(int count)
        {
            var generatedPalletes = PalleteGenerator.GeneratePalletes(count);
            StorageManager.Instance.AddPalletesFromList(generatedPalletes);
        }
        public void LoadData()
        {
            _palletes = SaveLoadController.LoadPalletes();
        }
        public void SaveData()
        {
            SaveLoadController.SavePalletes(_palletes);
        }
        public void AddPallete(Pallete pallete)
        {
            if(pallete != null)
            _palletes.Add(pallete);
        }
        public void AddPalletesFromList(List<Pallete> palletes)
        {
            if(palletes?.Count != 0)
            _palletes.AddRange(palletes);
        }
    }
}
