using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab3_Var4_ConsoleApp
{
    class Tank
    {
        public int InventoryNumber { get; }
        public int Volume{ get; }
        public Tank(TypeCargo forCargoTypes, int num)
        {
            InventoryNumber = num; 
            Volume = GetVolume(forCargoTypes);
        }
        // статический метод для определения объема танка в зависимости от предназначения (типа грузов)
        public static int GetVolume(TypeCargo typeT) 
        {
            switch (typeT)
            {
                case TypeCargo.oil:
                    return 100;
                case TypeCargo.gas:
                    return 40;
                case TypeCargo.chemical:
                    return 60;
                default: return -1;
            }
        }
    }
}
