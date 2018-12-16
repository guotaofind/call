using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Call.Models
{
    public class Flow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string flow_js { get; set; }
        [Required]
        public string flow_bpmn { get; set; }
    }
}