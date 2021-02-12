using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab3_Var4_ConsoleApp
{
    class Tanker
    {
        private string _name; // название танкера
        private Tank[] tanks; // массив танков
        private int _tanksCount; // количество танков
        private string _tankerType; 
        private Cargo _cargo;
        private Port _moorToPort;
        public string Name 
        {
            get => $"\"{_name}\"";
            set { _name = value; }
        }
        public int DeadWeight { get; } // дедвейт 
        public TypeCargo TypeOfCargo { get; }
        public Cargo Cargo { get => _cargo; }

        internal Tank Tank
        {
            get => default(Tank);
            set
            {
            }
        }

        internal Cargo Cargo1
        {
            get => default(Cargo);
            set
            {
            }
        }

        internal TypeCargo TypeCargo
        {
            get => default(TypeCargo);
            set
            {
            }
        }

        public Tanker() : this("NoName") { }
        public Tanker(string name) : this(name, 999) { }
        public Tanker(string name, int deadweight) : this(name, deadweight, TypeCargo.oil) { }
        public Tanker(string name, int deadweight, TypeCargo typeCargo)
        {
            _name = name;
            DeadWeight = deadweight;
            TypeOfCargo = typeCargo;
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
            string cargo = _cargo == null ? "пустой" : _cargo.Name;
            return $"-------\nтанкер-{_tankerType} {Name} количество танков:{_tanksCount} по {tanks[0].Volume}, дедвейт судна:{DeadWeight}\n" +
                $" Местонахождение: {location}; наличие груза: {cargo}\n-------"; 
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
        public void TakeCargo(Cargo cargo)
        {
            if (_moorToPort != null)
            {
                if (this._cargo != null)
                    Console.WriteLine($"! Танкер {this.Name} уже загружен!");
                else
                {
                    if (this.TypeOfCargo == cargo.Type)
                    {
                        this._cargo = cargo;
                        Console.WriteLine($"!Завершилась погрузка груза({cargo.Name}) на танкер {this.Name}");
                    }
                    else
                        Console.WriteLine($"! Танкер {this.Name} не может взять груз ({cargo.Name})!");
                }
            }else
                Console.WriteLine("! Погрузка может осуществляться только в порту!");
        }
        public void UnloadCargo()
        {
            if (_moorToPort != null)
            {
                if (this._cargo != null)
                {
                    Console.WriteLine($"!Завершилась разгрузка груза({this._cargo.Name}) с танкера {this.Name}");
                    this._cargo = null;
                }

                else
                    Console.WriteLine($"! Танкер {this.Name} пустой!");
            }
            else
                Console.WriteLine("! Разгрузка может осуществляться только в порту!");
        }
    }
}
