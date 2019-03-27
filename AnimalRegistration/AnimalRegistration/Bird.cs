namespace AnimalRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bird
    {
        [Key]
        public int BirdsID { get; set; }

        public string BirdName { get; set; }

        public string BirdsType { get; set; }

        public int? animalSpecies_animalID { get; set; }

        public string DietryType { get; set; }

        public string PopulationNumber { get; set; }

        public int? animal_animalID { get; set; }

        public virtual animal animal { get; set; }
    }
}
