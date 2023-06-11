using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Confecciones.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column("codUsuario")]
        public int CodUsuario { get; set; }
        [Column("nombre")]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Column("apellido")]
        [StringLength(30)]
        public string Apellido { get; set; }
        [Column("usuario")]
        [StringLength(20)]
        public string Usuario1 { get; set; }
        [Column("password")]
        [StringLength(20)]
        public string Password { get; set; }

        [InverseProperty(nameof(Pedido.CodUsuarioNavigation))]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
