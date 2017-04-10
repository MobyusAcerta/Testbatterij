using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testbatterij.Models
{
    public class TestSet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "TestScenario's")]
        public virtual ICollection<TestSetTestScenarios> TestSetTestScenarios { get; set; }
    }
}