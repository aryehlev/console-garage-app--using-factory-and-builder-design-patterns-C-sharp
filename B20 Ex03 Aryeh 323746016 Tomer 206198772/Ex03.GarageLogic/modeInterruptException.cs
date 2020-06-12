using System;

namespace Ex03.GarageLogic
{
    public class ModeInterruptException : Exception
    {
        public ModeInterruptException() : base("mode was interuppted by the user")
        {
        }
    }
}
