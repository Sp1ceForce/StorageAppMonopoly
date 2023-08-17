using StorageAppLogic.Models;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace StorageAppInterface.UIHandlers
{
    public static class PalleteListPrinter
    {
        public static void DrawPalleteList(ReadOnlyCollection<Pallete> palletes)
        {
            StringBuilder sb = new StringBuilder("\n");
            for (int i = 0; i < palletes.Count; i++)
            {
                sb.Append($"{i+1}) Id:{palletes[i].Id} ExpirationDate:{palletes[i].ExpirationDate.ToShortDateString()} Weight:{palletes[i].Weight} Volume:{palletes[i].Volume} BoxesCount:{palletes[i].BoxesList.Count}\n");
            }
            Console.WriteLine(sb);
        }
    }
}
