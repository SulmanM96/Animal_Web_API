namespace AnimalRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mammal
    {
        [Key]
        public int MammalsID { get; set; }

        public string MammalsName { get; set; }

        public int? animalSpecies_animalID { get; set; }

        public string MammalsType { get; set; }

        public string DietryType { get; set; }

        public string PopulationNumber { get; set; }

        public int? animal_animalID { get; set; }

        public virtual animal animal { get; set; }
    }
}
