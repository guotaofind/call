using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Call.Models
{
    public class Definition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string flow_bpmn { get; set; }
    }
}