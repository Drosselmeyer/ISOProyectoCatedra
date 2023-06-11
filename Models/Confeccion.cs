using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("Confeccion")]
    public partial class Confeccion
    {
        public Confeccion()
        {
            ConfeccionTelas = new HashSet<ConfeccionTela>();
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column("codConfeccion")]
        public int CodConfeccion { get; set; }
        [Column("codEstilo")]
        public int? CodEstilo { get; set; }
        [Column("medidas")]
        [StringLength(100)]
        public string Medidas { get; set; }

        [ForeignKey(nameof(CodEstilo))]
        [InverseProperty(nameof(Estilo.Confeccions))]
        public virtual Estilo CodEstiloNavigation { get; set; }
        [InverseProperty(nameof(ConfeccionTela.CodConfeccionNavigation))]
        public virtual ICollection<ConfeccionTela> ConfeccionTelas { get; set; }
        [InverseProperty(nameof(Pedido.CodConfeccionNavigation))]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
