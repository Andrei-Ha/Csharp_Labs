using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab3_Var4_ConsoleApp
{
    class Tanker
    {
        public string Name { get; set; } // название танкера
        public int DeadWeight { get; } // дедвейт         
        private Tank[] tanks; // массив танков
        private int _tanksCount; // количество танков
        private string _tankerType;
        private Port _moorToPort;
        public Tanker(string name, int deadweight, TypeCargo typeCargo)
        {
            Name = name;
            DeadWeight = deadweight;
            _tanksCount = DeadWeight / Tank.GetVolume(typeCargo);// количество танков при заданом дедвейте для определенного типа грузов
            tanks = new Tank[_tanksCount];
            for (int i = 0; i < _tanksCount; i++)
                tanks[i] = new Tank(typeCargo,i+1);
            if (typeCargo == TypeCargo.oil)
                _tankerType = "нефтевоз";
            else if (typeCargo == TypeCargo.gas)
                _tankerType = "газовоз";
            else if (typeCargo == TypeCargo.chemical)
                _tankerType = "химовоз";
        }
        public override string ToString()
        {
            string location = _moorToPort == null ? "в море" : $" в порту \"{_moorToPort.Name}\"";
            return $"-------\nтанкер-{_tankerType} \"{Name}\" количество танков:{_tanksCount} по {tanks[0].Volume}, дедвейт судна:{DeadWeight}\n" +
                $" Местонахождение: {location}\n-------"; 
        }
        public void Info()
        {
            Console.WriteLine(this.ToString());
        }
        // запрос швартовки
        public void MoorRequest(Port port)
        {
                _moorToPort = port.MoorToTerminal(this);
        }
        // покинуть терминал
        public void LeavePort(Port port = null) // если в процедуру не передается объект порта, значит инициатор - танкер. Иначе инициатор Port.ReleaseTerminal
        {
            if (_moorToPort != null && port == null)
            {
                _moorToPort.ReleaseTerminal(this);
                _moorToPort = null;
            }
            else if (port == _moorToPort)
                _moorToPort = null;
        }
    }
}
