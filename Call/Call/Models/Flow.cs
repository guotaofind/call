using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Call.Models
{
    public class Flow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlowId { get; set; }
        public string Name { get; set; }
        public string FlowJs { get; set; }
        public string FlowBpmn { get; set; }
        public virtual List<WorkFlow> WorkFlows { get; set; }
    }
}