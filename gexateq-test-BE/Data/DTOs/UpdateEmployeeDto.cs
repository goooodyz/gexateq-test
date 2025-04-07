using gexateq_test_BE.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gexateq_test_BE.Data.DTOs
{
    public class UpdateEmployeeDto
    {
        public required Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required GenderEnum Gender { get; set; }

        public int? Age { get; set; }
    }
}
