namespace AnimalRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Arthropod
    {
        [Key]
        public int arthropodsID { get; set; }

        public string arthropodsName { get; set; }

        public string arthropodsType { get; set; }

        public int? animalSpecies_animalID { get; set; }

        public string DietryType { get; set; }

        public string PopulationNumber { get; set; }

        public int? animal_animalID { get; set; }

        public virtual animal animal { get; set; }
    }
}
