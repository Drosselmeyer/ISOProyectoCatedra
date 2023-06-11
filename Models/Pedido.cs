using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("Pedido")]
    public partial class Pedido
    {
        [Key]
        [Column("codPedido")]
        public int CodPedido { get; set; }
        [Column("codUsuario")]
        public int? CodUsuario { get; set; }
        [Column("codConfeccion")]
        public int? CodConfeccion { get; set; }
        [Column("codMetodoPago")]
        public int? CodMetodoPago { get; set; }
        [Column("fechaPedido", TypeName = "date")]
        public DateTime? FechaPedido { get; set; }
        [Column("fechaEntrega", TypeName = "date")]
        public DateTime? FechaEntrega { get; set; }
        [Column("comentarios")]
        [StringLength(100)]
        public string Comentarios { get; set; }

        [ForeignKey(nameof(CodConfeccion))]
        [InverseProperty(nameof(Confeccion.Pedidos))]
        public virtual Confeccion CodConfeccionNavigation { get; set; }
        [ForeignKey(nameof(CodMetodoPago))]
        [InverseProperty(nameof(MetodoPago.Pedidos))]
        public virtual MetodoPago CodMetodoPagoNavigation { get; set; }
        [ForeignKey(nameof(CodUsuario))]
        [InverseProperty(nameof(Usuario.Pedidos))]
        public virtual Usuario CodUsuarioNavigation { get; set; }
    }
}
