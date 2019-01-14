using dependency01.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency01.Services
{
    public class ProductRepository: IEnumerable<Product>
    {
        private ISet<Product> producten = new HashSet<Product>();

        public Boolean Bevat(Product p)
        {
            return producten.Contains(p);
        }
        public void Add(Product p)
        {
            producten.Add(p);
        }
        public IEnumerator<Product> GetEnumerator()
        {
            return producten.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return producten.GetEnumerator();
        }
    }
}
