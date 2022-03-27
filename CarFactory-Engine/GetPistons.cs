using CarFactory.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CarFactory_Engine
{
    public class GetPistons : IGetPistons
    {
        public int Get(int amount)
        {
            return amount;
        }
    }
}
