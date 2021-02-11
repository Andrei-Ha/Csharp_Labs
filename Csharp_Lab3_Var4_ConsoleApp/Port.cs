using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab3_Var4_ConsoleApp
{
    class Port
    {
        private Tanker[] _terminals; // т.к. танкеры будем привязывать к терминалу, то _terminals - это массив танкеров, а порядковый номер в массиве - номер терминала. Если терминал не занят, соответствующий элемент в массиве = null
        public string Name { get; set; }
        //public string WaterArea { get; set; }
        public int TerminalCount { get; }
        public Tanker[] Terminals
        {
            get =>  _terminals;
        }
        public Port(string name, int terminalCount)
        {
            Name = name;
            TerminalCount = terminalCount;
            _terminals = new Tanker[TerminalCount];
        }
        public Port MoorToTerminal(Tanker tanker)
        {
            if (tanker != null)
            {
                // если танкер уже пришвартован 
                for (int i = 0; i < TerminalCount; i++)
                    if (_terminals[i] == tanker)
                        return this;
                // ищем свободный терминал
                Console.WriteLine($"! танкер \"{tanker.Name}\" запрашивает швартовку в порту \"{Name}\"");
                for (int i = 0; i < TerminalCount; i++)
                {
                    if (_terminals[i] == null)
                    {
                        _terminals[i] = tanker;
                        Console.WriteLine("! Разрешена швартовка к терминалу № " + (i + 1));
                        tanker.MoorRequest(this);
                        return this;
                    }
                }
                // все занято
                Console.WriteLine("! Отказ. Все терминалы заняты");
                return null;
            }
            return null;
        }
        public void ReleaseTerminal(Tanker tanker)
        {
            if (tanker != null)
            {
                for (int i = 0; i < TerminalCount; i++)
                    if (_terminals[i] == tanker)
                    {
                        _terminals[i] = null;
                        Console.WriteLine($"! танкер \"{tanker.Name}\" покинул терминал № {i + 1} порта \"{this.Name}\"");
                    }
                tanker.LeavePort(this);
            }
        }
        public override string ToString()
        {
            string str_terminals = string.Empty;
            int i = 1;
            foreach (Tanker tanker in _terminals) {
                str_terminals += $"терминал №{i} ";
                if (tanker == null)
                    str_terminals += "свободен \n";
                else
                    str_terminals += $"Занят танкером \"{tanker.Name}\" \n";
                i++;
                }
            return $"***\nназвание порта: \"{Name}\", количество терминалов - {TerminalCount} \n" + str_terminals + "***";
        }
        public void Info()
        {
            Console.WriteLine(this.ToString());
        }
    }
    
}
