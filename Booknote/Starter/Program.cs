﻿using System.Collections.Generic;
using BooknoteLogic;

namespace Starter
{
    class Program
    {
        public static void Main()
        {
            var cont = new Container.Container(new List<string> {"BooknoteLogic"});
            var processor =  cont.Resolve<CommandProcessor>();
            processor.Process();
        }
    }
}