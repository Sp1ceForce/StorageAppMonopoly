using StorageAppLogic.Models;
using StorageAppLogic.Models.Structs;
using System;
using System.Collections.Generic;

namespace StorageAppLogic.DataManagers
{
    public static class PalleteGenerator
    {
        const int DefaultMinBoxes = 2;
        const int DefaultMaxBoxes = 10;

        public static List<Pallete> GeneratePalletes(int totalPalletes)
        {
            Random random = new Random();
            List<Pallete> palletes = new List<Pallete>();
            for (int i = 0; i < totalPalletes; i++)
            {
                int palleteWidth = random.Next(100,600);
                int palleteHeight = random.Next(100,600);
                int palleteDepth = random.Next(100,600);
                DimensionalData dimensionalData = new DimensionalData(palleteWidth, palleteHeight,palleteDepth);
                var pallete = new Pallete(dimensionalData);
                int boxesToGenerate = random.Next(DefaultMinBoxes, DefaultMaxBoxes + 1);
                for (int k = 0; k < boxesToGenerate; k++)
                {
                    double boxWidth = random.Next(50, palleteWidth);
                    double boxHeight = random.Next(50, palleteHeight);
                    double boxDepth = random.Next(50, palleteDepth);
                    double boxWeight = random.Next(1, 1000);
                    DateTime randomDate = new DateTime(2020, 1, 1);
                    int range = (DateTime.Today - randomDate).Days;
                    DimensionalData boxDimensionalData = new DimensionalData(boxWidth, boxHeight, boxDepth);
                    var box = new Box($"{pallete.Id}-{k}", boxDimensionalData, boxWeight, randomDate.AddDays(random.Next(range)));
                    if (!pallete.AddBox(box)) k--;
                }
                palletes.Add(pallete);
            }
            return palletes;
        }
    }
}