using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Models;

namespace WebBanHang.Service
{
    public class ProductService
    {
        private ProductConnector connector;
        public ProductService()
        {
            connector = new ProductConnector();
        }

        public List<Product> GetAll()
        {
            return connector.GetAll();
        }

        public Product GetById(int id)
        {
            return connector.GetById(id);
        }

        public bool Insert(Product product)
        {
            return connector.Insert(product);
        }

        public bool Update(Product product)
        {
            return connector.Update(product);
        }

        public bool Delete(int id)
        {
            return connector.Delete(id);
        }
    }
}
