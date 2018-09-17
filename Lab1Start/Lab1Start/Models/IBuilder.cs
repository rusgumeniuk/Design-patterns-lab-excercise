using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Start.Models
{
    interface IBuilder
    {
        string StartWork();
        string FinishWork();

        void PutBricks(int countOfBricks);
        void DoTimeout(int secondsOfRest);

        string GetCurrentInfo();
    }
}
