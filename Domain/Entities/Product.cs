using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodErp { get; set; }
        public decimal Price { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "O id deve ser maior que zero.");
            Id = id;
            Validation(name, codErp, price);
        }

        public void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código ERP deve ser informado.");
            DomainValidationException.When(price < 0, "O preço deve ser maior que zero.");
            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
