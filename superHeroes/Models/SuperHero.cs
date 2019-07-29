using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace superHeroes.Models
{
    public class SuperHero
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string alterEgo { get; set; }
        public string primaryAbility { get; set; }
        public string secondaryAbility { get; set; }
        public string catchPhrase { get; set; }
        public string imgPath { get; set; }
        public int clicks { get; set; }
    }
}