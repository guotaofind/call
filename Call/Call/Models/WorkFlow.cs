using System.ComponentModel.DataAnnotations.Schema;

namespace Call.Models
{
    public class WorkFlow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkFlowId { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string Definitions { get; set; }
        
        public string Lines { get; set; }

        public int FlowId { get; set; }

        public virtual Flow Flow { get; set; }

        [NotMapped]
        public string FlowBpmn { get; set; }

        [NotMapped]
        public bool Resume { get; set; }

        [NotMapped]
        public int Level { get; set; }

        [NotMapped]
        public decimal CashAmount { get; set; }
    }
}