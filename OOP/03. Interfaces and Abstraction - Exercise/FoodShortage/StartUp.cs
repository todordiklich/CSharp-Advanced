﻿using P06FoodShortage.Core;
using System;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
