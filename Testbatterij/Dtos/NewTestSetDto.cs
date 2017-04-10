using System.Collections.Generic;

namespace Testbatterij.Dtos
{
    public class NewTestSetDto
    {
        public string Name { get; set; }
        public List<int> TestScenarioIds { get; set; }
    }
}