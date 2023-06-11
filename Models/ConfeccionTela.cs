using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("ConfeccionTela")]
    public partial class ConfeccionTela
    {
        [Key]
        [Column("codTela")]
        public int CodTela { get; set; }
        [Key]
        [Column("codConfeccion")]
        public int CodConfeccion { get; set; }

        [ForeignKey(nameof(CodConfeccion))]
        [InverseProperty(nameof(Confeccion.ConfeccionTelas))]
        public virtual Confeccion CodConfeccionNavigation { get; set; }
        [ForeignKey(nameof(CodTela))]
        [InverseProperty(nameof(Tela.ConfeccionTelas))]
        public virtual Tela CodTelaNavigation { get; set; }
    }
}
