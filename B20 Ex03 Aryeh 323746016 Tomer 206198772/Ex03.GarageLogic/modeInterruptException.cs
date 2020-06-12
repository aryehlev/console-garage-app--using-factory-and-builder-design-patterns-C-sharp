using System;

namespace Ex03.GarageLogic
{
    public class ModeInterruptException : Exception
    {
        public ModeInterruptException() : base("mode was interrupted by the user")
        {
        }
    }
}
