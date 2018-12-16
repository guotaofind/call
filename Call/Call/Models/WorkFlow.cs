using System.ComponentModel.DataAnnotations.Schema;

namespace Call.Models
{
    public class WorkFlow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkFlowId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string flow_bpmn { get; set; }
        public int FlowId { get; set; }
        public virtual Flow Flow { get; set; }
    }
}