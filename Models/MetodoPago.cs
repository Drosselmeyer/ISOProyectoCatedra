using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("MetodoPago")]
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column("codMetodoPago")]
        public int CodMetodoPago { get; set; }
        [Column("metodoPago")]
        [StringLength(30)]
        public string MetodoPago1 { get; set; }

        [InverseProperty(nameof(Pedido.CodMetodoPagoNavigation))]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
