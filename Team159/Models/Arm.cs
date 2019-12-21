using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team159.Models
{
    public class Arm
    {
        public int Id { get; set; }
        [Display(Name = "攻击")]
        public double Attach { get; set; }
        [Display(Name = "防御")]
        public double Defance { get; set; }
        [Display(Name = "生命")]
        public double Life { get; set; }
        [Display(Name = "伤害")]
        public double Damage { get; set; }
        [Display(Name = "兵种")]
        public ArmType ArmType { get; set; }
        [Required]
        [Display(Name = "玩家")]
        public string Player { get; set; }
        [Display(Name = "联盟")]
        public League League { get; set; }
        [Display(Name = "单人攻击")]
        public double? SingleAttach { get; set; }
        [Display(Name = "单人防御")]
        public double? SingleDefance { get; set; }
        [Display(Name = "单人生命")]
        public double? SingleLife { get; set; }
        [Display(Name = "组队攻击")]
        public double? TeamAttach { get; set; }
        [Display(Name = "组队防御")]
        public double? TeamDefance { get; set; }
        [Display(Name = "组队生命")]
        public double? TeamLife { get; set; }
        [Display(Name = "主将")]
        public Hero MainHero { get; set; }
        [Display(Name = "副将")]
        public Hero SideHero { get; set; }
    }

    public enum ArmType
    {
        枪,
        弓,
        盾,
        投石,
        骑射,
        攻城,
        近战
    }

    public enum League
    {
        战旗,
        一六八,
        繁星,
        辉煌
    }

    public enum Hero
    {
        项羽,
        关羽,
        白起,
        曹丕,
        曹仁,
        司马
    }
}
