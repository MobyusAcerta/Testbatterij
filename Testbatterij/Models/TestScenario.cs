using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Testbatterij.Models
{
    public class TestScenario
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "xml")]
        [AllowHtml]
        public string Request { get; set; }

        [Required]
        public string SendQueue { get; set; }

        [Required]
        public string ReceiveQueue { get; set; }

        public virtual ICollection<TestSetTestScenarios> TestSetTestScenarios { get; set; }
    }
}