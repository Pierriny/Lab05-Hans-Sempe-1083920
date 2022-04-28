using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab05_Hans_Sempe_1083920.Models;

namespace Lab05_Hans_Sempe_1083920.Models.Comparadores
{
    public class CompareVehiculoPlaca: IComparer<Lab05_Hans_Sempe_1083920.Models.Vehículos>
    {
        public  int Compare(Vehículos x, Vehículos y)
        {
            return x.Placa.CompareTo(y.Placa);
        }
    }
}
