using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    public enum Destination
    {
        CSI,
        EUROPE,
        WORLD}

            public static class InsurancePlanExtensions
    {
        public static double GetTariff(this Destination destination)
        {
            switch (destination)
            {
                case Destination.CSI:
                    return 0.31;
                case Destination.EUROPE:
                    return 0.47;
                case Destination.WORLD:
                    return 0.99;
                default:
                    throw new ArgumentException("Invalid destination");
            }
        }

        public static int GetInsuranceSum (this Destination destination)
        {
            switch (destination)
            {
                case Destination.CSI:
                    return 10000;
                case Destination.EUROPE:
                    return 30000;
                case Destination.WORLD:
                    return 60000;
                default:
                    throw new ArgumentException("Invalid destination");
            }
        }
    }
}
