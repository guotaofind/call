using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Call.Models
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool line { get; set; }
        public string nodeId { get; set; }
        public string assignees { get; set; }
        public DateTime dateTime { get; set; }
        public DateTime endTime { get; set; }
        public bool act { get; set; }
    }
}