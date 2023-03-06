﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_paiement_pmt")]
    public partial class Paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pmt_idpmt")]
        [Required]
        public int IdPaiement { get; set; }

        [ForeignKey("fk_clt_pmt")]
        [Column("clt_idclient")]
        [Required]
        public int IdClientPaiement { get; set; }

        [Column("pmt_libelle")]
        [StringLength(255, ErrorMessage = "the paiement length must be 255 maximum")]
        [Required]
        public string LibellePaiement { get; set; }

        [Column("pmt_preference")]
        [Required]
        public bool PreferencePaiement { get; set; }

        [InverseProperty("ClientAdresse")]
        public virtual ICollection<Client>? ClientNavigation { get; set; } = null!;

    }
}