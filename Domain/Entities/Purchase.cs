using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "O id deve ser maior que zero.");
            Id = id;
            Validation(productId, personId);
        }

        public void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId < 0, "O id do produto de ser maior que zero");
            DomainValidationException.When(personId < 0, "O id da pessoa de ser maior que zero");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
