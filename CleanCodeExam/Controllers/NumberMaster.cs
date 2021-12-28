using CleanCodeExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExam.Controllers
{
    public class NumberMaster : IGame
    {
        static NumberMaster SingletonInstance { get; set; } = null;
        public static NumberMaster Builder()
        {
            if (SingletonInstance == null)
                SingletonInstance = new NumberMaster();

            return SingletonInstance;
        }
        private NumberMaster()
        {

        }
        public IGame End()
        {
            SingletonInstance = null;
            return this;
        }

        public IGame Start()
        {
            Console.Clear();
            Console.WriteLine("Number Master game not implemented yet.");
            Console.ReadKey(true);
            return this;
        }
    }
}
