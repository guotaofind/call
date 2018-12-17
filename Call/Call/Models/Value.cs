﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Call.Models
{
    public class Value
    {
        public string flowId { get; set; }
        public string workflowId { get; set; }
        public string userName { get; set; }
        public int level { get; set; }
        public decimal cashAmount { get; set; }
    }
}