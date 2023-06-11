using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("Estilo")]
    public partial class Estilo
    {
        public Estilo()
        {
            Confeccions = new HashSet<Confeccion>();
        }

        [Key]
        [Column("codEstilo")]
        public int CodEstilo { get; set; }
        [Column("detalleEstilo")]
        [StringLength(30)]
        public string DetalleEstilo { get; set; }

        [InverseProperty(nameof(Confeccion.CodEstiloNavigation))]
        public virtual ICollection<Confeccion> Confeccions { get; set; }
    }
}
