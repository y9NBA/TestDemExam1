﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ДЭ1
{
    internal class Singleton
    {
        public static Entities BD { get;  } = new Entities();
    }
}
