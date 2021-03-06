using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab2_Var4_ConsoleApp
{
    class Quadratic
    {
        // properties
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        //constructors
        public Quadratic(int a, int b, int c) 
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Quadratic(int a, int b):this(a, b, 1) { }
        public Quadratic(int a) : this(a, 1, 1) { }
        public Quadratic() : this(1, 1, 1) { }
        
        // methods
        public override string ToString()
        {
            string str_a, str_b, str_c;
            str_a = a == 0 ? "" : (Math.Abs(a) == 1 ?(a.ToString().Replace("1", "") + "x\u00B2" ):(a.ToString()) + "x\u00B2"); //если а=1 или -1, оставляем только знак перед х*х
            str_b = b == 0 ? "" : (Math.Abs(b) == 1 ? b.ToString().Replace("1", "") + "x" : b.ToString() + "x"); 
            str_c = c == 0 ? "" : (c > 0 ? ("+" + c.ToString()) : c.ToString());
            if (str_b.IndexOf('-') == -1 && a!=0 && b!=0)
                str_b = "+" + str_b;
            return $"{str_a}{str_b}{str_c}=0";
        }
        public string Solution()
        {
            if (a == 0) // bx + c = 0
                return "не является квадратным";
            else
            {
                // случаи неполного квадратного уравнения
                if (b == 0 && c == 0) // ax^2 = 0
                    return "имеет один корень x=0";
                else
                {
                    if (b == 0) // ax^2 + c = 0
                    {
                        double s = (-Convert.ToDouble(c) / Convert.ToDouble(a));
                        if (s < 0) return "корней не имеет"; else return $"имеет два корня: x1={Math.Sqrt(s)}, x2={-Math.Sqrt(s)}";
                    }
                    if (c == 0) // ax^2 + bx = 0 
                        return $"имеет два корня: x1=0, x2={-b / a}";
                }
                // полное квадратное уравнение ax^2 + bx + c = 0
                int d = b * b - 4 * a * c;
                if (d < 0)
                    return "корней не имеет";
                if (d == 0)
                    return $"имеет один корень x={-b / (2 * a)}";
                else
                    return $"имеет два корня: x1={(-b + Math.Sqrt(d)) / (2 * a)}, x2={(-b - Math.Sqrt(d)) / (2 * a)}";
            }
        }
        public string ViewAndSolution()
        {
            return $"уравнение {this.ToString()}\n{this.Solution()}\n-----------------------------------------";
        }

        // перегруженные операторы
        public static Quadratic operator + (Quadratic q1, Quadratic q2)
        {
            return new Quadratic(q1.a + q2.a, q1.b + q2.b, q1.c + q2.c );
        }
        public static Quadratic operator - (Quadratic q1, Quadratic q2)
        {
            return new Quadratic { a = q1.a - q2.a, b = q1.b - q2.b, c = q1.c - q2.c };
        }
        public static Quadratic operator ++ (Quadratic q)
        {
            return new Quadratic(q.a + 1, q.b + 1, q.c + 1);
        }
        public static Quadratic operator --(Quadratic q)
        {
            return new Quadratic(q.a - 1, q.b - 1, q.c - 1);
        }
        public static Quadratic operator *(Quadratic q, int u)
        {
            return new Quadratic(q.a * u, q.b * u, q.c * u);
        }
        public static Quadratic operator /(Quadratic q, int u)
        {
            return new Quadratic(q.a / u, q.b / u, q.c / u);
        }
        private int Discr() // вычисление дискриминанта
        {
            return b*b - 4 * a * c;
        }
        public static bool operator == (Quadratic q1, Quadratic q2) // вернет True если дискриминанты равны
        {
            return q1.Discr() == q2.Discr();
        }
        public static bool operator != (Quadratic q1, Quadratic q2) // вернет True если дискриминанты НЕ равны
        {
            return q1.Discr() != q2.Discr();
        }
        public static bool operator <(Quadratic q1, Quadratic q2)
        {
            return q1.Discr() < q2.Discr();
        }
        public static bool operator > (Quadratic q1, Quadratic q2)
        {
            return q1.Discr() > q2.Discr();
        }
        public static bool operator true (Quadratic q)
        {
            return q.Discr() >= 0;
        }
        public static bool operator false(Quadratic q)
        {
            return q.Discr() < 0;
        }
        // индексатор
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 3:
                        return c;
                    default:
                        throw new Exception("неверный индекс");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        a = value;
                        break;
                    case 1:
                        b = value;
                        break;
                    case 2:
                        c = value;
                        break;
                    default:
                        break;
                }
            }
        }
        // явное преобразование типов
        public static explicit operator int(Quadratic q)
        {
            return q.a;
        }
        public static explicit operator Quadratic(int t)
        {
            return new Quadratic(t, 0, 0);
        }
    }
}
