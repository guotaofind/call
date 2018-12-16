using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Call.Models
{
    public class Children
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string flow_bpmn { get; set; }
    }
}