﻿using System;
using System.Linq;
using System.Collections.Generic;

using INStock.Contracts;
using System.Collections;

namespace INStock.Models
{
    public class ProductStock : IProductStock, IEnumerable<IProduct>
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }
        public int Count => this.products.Count;

        public IProduct this[int index]
        {
            get
            {
                if (index >= 0 && index < this.products.Count)
                {
                    return products[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.products.Count)
                {
                    if (value is IProduct)
                    {
                        products[index] = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Add(IProduct product)
        {
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return this.products[index];
            }
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Label == label);

            if (product == null)
            {
                throw new ArgumentException();
            }

            return product;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return this.products.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p.Price);
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products.Where(p => p.Price == price);
        }
        public IEnumerable<IProduct> FindMostExpensiveProducts()
        {
            IProduct mostExpensiveProduct = this.products.OrderByDescending(p => p.Price).ToList()[0];

            return this.products.Where(p => p.Price == mostExpensiveProduct.Price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantityNeeded)
        {
            return this.products.Where(p => p.Quantity == quantityNeeded);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
