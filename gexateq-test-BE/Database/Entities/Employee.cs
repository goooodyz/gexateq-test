using gexateq_test_BE.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace gexateq_test_BE.Database.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string FirstName {  get; set; }

        public required string LastName { get; set; }

        public required GenderEnum Gender { get; set; }

        public int? Age { get; set; }
    }
}
