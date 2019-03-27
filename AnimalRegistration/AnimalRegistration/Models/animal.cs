using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AnimalRegistration.Models
{
    public class animal
    {
        private string AnimalName;
        private string AnimalType;
        private string AnimalDietry;
        private int Population;
        

        [DisplayName("Animal")]
        public string Aname { get => AnimalName; set => AnimalName = value; }
        public string AType { get => AnimalType; set => AnimalType = value; }
        public int Pop { get => Population; set => Population = value; }
        public string ADietry { get => AnimalDietry; set => AnimalDietry = value; }
    }
}