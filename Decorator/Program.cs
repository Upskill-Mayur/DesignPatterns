using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop laptop = new HPLaptop();
            Console.WriteLine("Base mode price is {0}", laptop.GetPrice());

            laptop = new GraphicsDecorator(laptop);
            Console.WriteLine("After adding graphics decorator, price of laptop is {0}", laptop.GetPrice());

            laptop = new FullHDScreenDecorator(laptop);
            Console.WriteLine("After adding full hd screen decorator, price of laptop is {0}", laptop.GetPrice());
        }
    }


    public abstract class Laptop
    {
        public abstract int GetPrice();
    }

    public class HPLaptop : Laptop
    {
        public HPLaptop()
        {
            Console.WriteLine("This is base model of HP Laptop");
        }
        public override int GetPrice()
        {
            return 25000;
        }
    }

    public class LaptopDecorator : Laptop
    {
        protected Laptop _laptop;

        public LaptopDecorator(Laptop laptop) : base()
        {
            _laptop = laptop;                
        }

        public override int GetPrice()
        {
            return _laptop.GetPrice();
        }
    }
        
       
    public class GraphicsDecorator : LaptopDecorator
    {
        public GraphicsDecorator(Laptop laptop) : base(laptop)
        {
            Console.WriteLine("Added graphic decorator to laptop");
        }

        public override int GetPrice()
        {
            return 25000 + _laptop.GetPrice();
        }
    }

    public class FullHDScreenDecorator : LaptopDecorator
    {
        public FullHDScreenDecorator(Laptop laptop) : base(laptop)
        {
            Console.WriteLine("Added full HD screen decorator to laptop");
        }

        public override int GetPrice()
        {
            return 50000 + _laptop.GetPrice();
        }
    }
}
