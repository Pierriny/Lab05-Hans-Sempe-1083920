using System;
//using CsvHelper.Configuration;
//using CsvHelper.Configuration.Attributes;

namespace Lab05_Hans_Sempe_1083920.Models
{
    public class Vehículos
    {

        public int Placa { get; set; }

        public String Color { get; set; }

        public String Dueño { get; set; }

        public int coordLatitud { get; set; }

        public int coordLongitud { get; set; }


        public Vehículos(int _placa, String _color, String _dueño, int _CoordLat, int _CoordLong)
        {
            this.Placa = _placa;

            this.Color = _color;

            this.Dueño = _dueño;

            this.coordLatitud = _CoordLat;

            this.coordLongitud = _CoordLong;

            
        }



    }
}
