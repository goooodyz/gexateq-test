using gexateq_test_BE.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace gexateq_test_BE.Data.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }
    }
}
