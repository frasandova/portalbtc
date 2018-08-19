namespace WebBiotec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Config_ConceptosRetail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string RUT { get; set; }

        [Required]
        [StringLength(100)]
        public string FICHA { get; set; }

        [Required]
        [StringLength(100)]
        public string COD_CONCEPTO { get; set; }

        [Required]
        [StringLength(100)]
        public string CONCEPTO { get; set; }

        [Required]
        [StringLength(100)]
        public string COD_CUENTA { get; set; }

        public double PORCENTAJE { get; set; }

        [Required]
        [StringLength(10)]
        public string TIPO_CALCULO { get; set; }
    }
}
