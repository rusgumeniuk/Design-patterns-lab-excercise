using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab1Start.Exceptions;

namespace Lab1Start.Models
{
    class Builder : IBuilder
    {
        private const byte MAX_NUMBER_OF_BRICKS_BY_ONE_TIME = 20;

        #region Prop
        public string Name { get; private set; }

        public bool IsOnWork { get; set; } 
        public bool IsOnTimeout { get; set; } = false;        
        
        public int TotalNumberOfPuttedBricksBySession { get; set; } = 0;
        public int RestTime { get; set; } = 0;
        #endregion

        #region Constr
        public Builder(string name)
        {
            Name = name;                      
        }
        public Builder(string name, bool isOnWork) : this(name)
        {
            IsOnWork = isOnWork;
        }
        #endregion

        #region Methods
        public string StartWork()
        {
            if (IsOnWork)
                throw new BuilderAlreadyOnWorkException(Name + " already on work");
            IsOnWork = true;

            return Name + " starts work";
        }
        public string FinishWork()
        {
            if (!IsOnWork)
                throw new BuilderNotOnWorkException(Name + " not on work");

            IsOnWork = false;
            IsOnTimeout = false;            
            TotalNumberOfPuttedBricksBySession = 0;
            RestTime = 0;

            return !IsOnWork ? throw new BuilderNotOnWorkException(Name + " not on work") : Name + " finishing work";
        }

        public void PutBricks(int countOfBricks)
        {
            if (!IsOnWork)
                throw new BuilderNotOnWorkException(Name + " can't puts bricks");
            if(countOfBricks < 0)
                throw new ArgumentException("Count of bricks should be non-negative");

            for (int i = 0; i < countOfBricks; i += MAX_NUMBER_OF_BRICKS_BY_ONE_TIME) 
            {
                if (i % 100 == 0 && i != 0)
                {                    
                    DoTimeout(5);                 
                }
                ++TotalNumberOfPuttedBricksBySession;
            }            
        }

        public void DoTimeout(int secondsOfRest)
        {
            if(secondsOfRest < 0)
            {
                System.Windows.MessageBox.Show("Time of rest should be non-negative");
                return;
            }           

            System.Windows.MessageBox.Show(StartTimeout());
            System.Threading.Thread.Sleep(secondsOfRest * 1000);
            System.Windows.MessageBox.Show(EndTimeout());

            RestTime += secondsOfRest;            
        }
        private string StartTimeout()
        {
            if (!IsOnWork)
                throw new BuilderNotOnWorkException(Name + " can't do timeout because he not on work");
            IsOnTimeout = true;
            return Name + " on timeout";
        }
        private string EndTimeout()
        {
            IsOnTimeout = false;
            return "It seems that timeout of " + Name + " is " +  "ended";
        }

        public string GetCurrentInfo()
        {
            return 
                Name + " is" + (!IsOnWork ? " not on work" : " on work and " +
                (IsOnTimeout ? " has a timeout" : "working now.")) +
                "\nNumber of putted bricks at this session is " + TotalNumberOfPuttedBricksBySession +
                "\nTime of rest: " + RestTime
                ;
        }

        public override string ToString()
        {
            return "Builder " + Name;
        }
        #endregion
    }
}
