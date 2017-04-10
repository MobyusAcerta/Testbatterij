using System.ComponentModel.DataAnnotations;

namespace Testbatterij.Dtos
{
    public class TestScenarioDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Request { get; set; }
    }
}