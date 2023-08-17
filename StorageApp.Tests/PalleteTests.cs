using StorageAppLogic.Models;
using StorageAppLogic.Models.Structs;
using System;
using Xunit;

namespace StorageApp.Tests
{
    public class PalleteTests
    {
        [Fact]
        public void Volume_3x3x3Box_ReturnsValidAnswer()
        {
            //Arrange
            DimensionalData PalleteDimensions= new DimensionalData(4,1,4);
            DimensionalData boxDimensions = new DimensionalData(3, 3, 3);
            Pallete pallete = new Pallete(PalleteDimensions);
            Box box = new Box("TestBox", boxDimensions, 1, DateTime.Now);
            
            //Act
            pallete.AddBox(box);
            var volume = pallete.Volume;
            var expectedVolume = 4 * 1 * 4 + 3 * 3 * 3;
            
            //Assert
            Assert.Equal(expectedVolume, volume);
        }
        [Fact]
        public void Weight_BoxWeight40And35_ReturnsValidAnswer()
        {
            //Arrange
            DimensionalData PalleteDimensions = new DimensionalData(4, 1, 4);
            DimensionalData boxDimensions = new DimensionalData(3, 3, 3);
            Pallete pallete = new Pallete(PalleteDimensions);
            double boxWeight1 = 40; 
            double boxWeight2 = 35;
            Box box1 = new Box("TestBox 1", boxDimensions, boxWeight1, DateTime.Now);
            Box box2 = new Box("TestBox 2", boxDimensions, boxWeight2, DateTime.Now);
            
            //Act
            pallete.AddBox(box1);
            pallete.AddBox(box2);
            var resultWeight = pallete.Weight;
            var expectedWeight = 40+35+Pallete.BaseWeight;
            
            //Assert
            Assert.Equal(expectedWeight, resultWeight);
        }
        [Fact]
        public void AddBox_BoxBiggerThanPallete_ReturnsFalse()
        {
            //Arrange
            DimensionalData PalleteDimensions = new DimensionalData(4, 1, 4);
            DimensionalData boxDimensions = new DimensionalData(6, 6, 6);
            Pallete pallete = new Pallete(PalleteDimensions);
            Box box = new Box("TestBox", boxDimensions, 1, DateTime.Now);
            
            //Act
            bool addResult = pallete.AddBox(box);
            
            //Assert
            Assert.False(addResult);
        }
        [Fact]
        public void AddBox_BoxSmallerThanPallete_ReturnsTrue()
        {
            //Arrange
            DimensionalData PalleteDimensions = new DimensionalData(4, 1, 4);
            DimensionalData boxDimensions = new DimensionalData(2, 2, 2);
            Pallete pallete = new Pallete(PalleteDimensions);
            Box box = new Box("TestBox", boxDimensions, 1, DateTime.Now);

            //Act
            bool addResult = pallete.AddBox(box);

            //Assert
            Assert.True(addResult);
        }
    }
}
