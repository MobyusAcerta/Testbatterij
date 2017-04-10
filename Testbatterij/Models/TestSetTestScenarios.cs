using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testbatterij.Models
{
    public class TestSetTestScenarios
    {
        [Key, Column(Order = 0)]
        public int TestSetId { get; set; }
        [Key, Column(Order = 1)]
        public int TestScenarioId { get; set; }
        [Key, Column(Order = 2)]
        public int Order { get; set; }

        public virtual TestSet TestSet { get; set; }
        public virtual TestScenario TestScenario { get; set; }
    }
}