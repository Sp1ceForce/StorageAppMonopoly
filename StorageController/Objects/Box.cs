using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageController.Objects
{
    public class Box : BaseObject
    {
        public string ContentsName { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public override uint Volume
        {
            get
            {
                return Width * Height * Depth;
            }
        }

        public Box(Guid id, uint width, uint height, uint depth, double weight) : base(id, width, height, depth, weight)
        {
        }
        public Box(uint width, uint height, uint depth, double weight) : base(width, height, depth, weight)
        {
        }
    }
}
