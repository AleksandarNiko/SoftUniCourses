﻿namespace CommandPattern.IO
{
    using System;
    using Contracts;
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
            => Console.Write(value.ToString());

        public void WriteLine(object value)
            => Console.WriteLine(value.ToString());
    }
}
