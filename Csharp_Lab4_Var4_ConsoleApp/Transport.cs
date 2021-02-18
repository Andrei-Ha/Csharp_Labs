using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    public abstract class Transport
    {
        private int _maxSpeed; // скорость
        private int _seatsForPassenger; //  количество пассажирских мест
        protected int MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
        public int Seats { get => _seatsForPassenger; set => _seatsForPassenger = value; }
        public Transport() {
            MaxSpeed = 0;
            Seats = 0;
        }
        public Transport(int maxspeed, int seats)
        {
            MaxSpeed = maxspeed;
            Seats = seats;
        }
        abstract public void Move(); // абстрактный метод

        public virtual string Info() // метод с реализацией который может быть перегружен в дочерних классах
        {
            return ($"максимальная скорость:{MaxSpeed}; кол-во сидений для пассажиров:{Seats}");
        }
        public void IncreaseMaxSpeed(int sp) 
        {
            MaxSpeed += sp;
        }
    }
}