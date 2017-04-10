using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testbatterij.Dtos
{
    public class TestSetDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<TestScenarioDto> TestScenarios { get; set; }
    }
}