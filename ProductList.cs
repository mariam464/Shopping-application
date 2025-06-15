using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ProductList : IEnumerable
    {
        List<Product1> Products = new List<Product1>();
        public ProductList(List<Product1> products)
        {
            Products = products;
        }
         public ProductList()
        {
            
        }

        public List<Product1> GetProducts()
        {
            return Products;
        }
        public Product1 this[int index]
        {
            get { return Products[index]; }
            set { Products[index] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumator(Products);
        }
        public class MyEnumator : IEnumerator
        {
            private List<Product1> Products;
            public int position = -1;

            public MyEnumator(List<Product1> products)
        {
            Products = products;
        }
        public object Current
        {
            get { return Products[position]; }
        }


        public bool MoveNext()
        {
            position++;
            if (position < Products.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            position = -1;
        }

    }
}
        
}