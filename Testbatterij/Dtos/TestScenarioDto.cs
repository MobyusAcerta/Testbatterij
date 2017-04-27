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

        [Required]
        public string SendQueue { get; set; }

        [Required]
        public string ReceiveQueue { get; set; }
    }
}