using System;
using static System.Math;

namespace C72
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello new in c# 7.2");

            Asteroid A = new Asteroid(523232, "Alfa", new Point(4, 5, 0));
            Asteroid B = new Asteroid(523232, "Beta", new Point(x: 3, y: 3, z: 0));

            //var distanse = Distase(A, B);
            var distanse = A.Distase(in B);

            Console.ReadLine();
        }
        public static ref readonly Asteroid Nearest(in Point p, in Asteroid a1, in Asteroid a2)
        //public static ref Asteroid Nearest(ref Point p, ref Asteroid a1, ref Asteroid a2)
        {
            if(p.Distase(a1.Position) < p.Distase(a2.Position))
            {
                return ref a1;
            }
            else
            {
                return ref a2;
            }
        }
    }
    public static class ExtensionsForStruct
    {
        // 7.2 using extensions on struct
        // 7.2 in parameters
        public static double Distase(in this Point p1, in Point p2)
        {
            return Sqrt(
                Sq(p1.X - p2.X) +
                Sq(p1.Y - p2.Y) +
                Sq(p1.Z - p2.Z));
            double Sq(double d) => d * d;
        }
        public static double Distase(in this Asteroid a1, in Asteroid a2)
        {
            //return Distase(a1.Position, a2.Position);
            return a1.Position.Distase(in a2.Position);
        }
    }
    public struct Asteroid
    {
        public readonly int Number;
        public readonly string Name;
        public Point Position;

        public Asteroid(int number, string name, Point position)
        {
            Number = number;
            Name = name;
            Position = position;
        }
        //...

    }

    public struct Point
    {
        public Point(double x, double y, double z) //: this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get;  }
        public Double Y { get;  }
        public Double Z { get;  }
    }
}