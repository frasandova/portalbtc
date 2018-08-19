namespace WebBiotec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Config_PerfilRetail
    {
        [Key]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string codigoCanal { get; set; }

        [StringLength(100)]
        public string canal { get; set; }
    }
}
