using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExam.Interfaces
{
    public interface IGame
    {
        IGame Start();
        IGame End();
    }
}
