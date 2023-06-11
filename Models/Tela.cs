using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("Tela")]
    public partial class Tela
    {
        public Tela()
        {
            ConfeccionTelas = new HashSet<ConfeccionTela>();
        }

        [Key]
        [Column("codTela")]
        public int CodTela { get; set; }
        [Column("detalleTela")]
        [StringLength(30)]
        public string DetalleTela { get; set; }

        [InverseProperty(nameof(ConfeccionTela.CodTelaNavigation))]
        public virtual ICollection<ConfeccionTela> ConfeccionTelas { get; set; }
    }
}
