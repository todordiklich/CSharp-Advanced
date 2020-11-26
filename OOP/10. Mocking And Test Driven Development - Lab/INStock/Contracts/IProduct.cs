﻿namespace INStock.Contracts
{
    public interface IProduct
    {
        public string Label { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
