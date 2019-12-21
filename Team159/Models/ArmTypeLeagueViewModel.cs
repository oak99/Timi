using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team159.Models
{
    public class ArmTypeLeagueViewModel
    {
        public List<Arm> Arms { get; set; }

        [Display(Name ="兵种")]
        public int? armType { get; set; }

        [Display(Name = "联盟")]
        public int? league { get; set; }
    }
}
