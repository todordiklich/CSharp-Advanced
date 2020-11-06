﻿namespace Cars.Contracts
{
    public interface ICar
    {
        public string Model { get; }
        public string Color { get; }

        public string Start();
        public string Stop();
    }
}
