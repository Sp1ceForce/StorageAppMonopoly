using Newtonsoft.Json;
using StorageAppLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StorageAppLogic.DataManagers
{
    /// <summary>
    /// Статический класс ответственный за сохранение и загрузку данных из Json-файла
    /// </summary>
    public static class SaveLoadController
    {
        private const string SaveFilePath = "Palletes.json";


        /* До этого я собирался сделать этот класс не статическим и в нём подписаться на событие срабатывающее при обновлении паллет, 
         * потом подумал и понял что автоматическое сохранение это такое себе, пусть лучше пользователь сам сохраняет всё
         */
        public static List<Pallete> LoadPalletes()
        {
            using (FileStream fileStream = new FileStream(SaveFilePath, FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                string jsonString = Encoding.Default.GetString(buffer);
                List<Pallete> palletes = JsonConvert.DeserializeObject<List<Pallete>>(jsonString);
                if (palletes == null) palletes = new List<Pallete>();
                fileStream.Close();
                return palletes;
            }
        }
        public static bool SavePalletes(List<Pallete> palletes)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(palletes, Formatting.Indented);
                File.WriteAllText(SaveFilePath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при сохранении: {e.Message}");
                return false;
            }
            return true;
        }
    }
}
