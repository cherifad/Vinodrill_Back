﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Auth
{
    public class User : IdentityUser
    {
        [ForeignKey("CbClientNavigation")]
        [Column("cb_idcb", Order = 1)]
        public int? IdCbClient { get; set; }

        [Column("clt_nom")]
        [StringLength(255, ErrorMessage = "the client name must be 255 maximum")]
        [Required]
        public string NomClient { get; set; }

        [Column("clt_prenom")]
        [StringLength(255, ErrorMessage = "the client first name must be 255 maximum")]
        [Required]
        public string PrenomClient { get; set; }

        [Column("clt_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissanceClient { get; set; }

        [Column("clt_sexe")]
        [RegularExpression(@"^[0-9]{1}$", ErrorMessage = "sexe length must be 1 maximum")]
        [Required]
        public string SexeClient { get; set; }

        [InverseProperty(nameof(Cb.ClientCbNavigation))]
        public virtual Cb CbClientNavigation { get; set; } = null;

        [InverseProperty(nameof(Adresse.ClientAdresseNavigation))]
        public virtual ICollection<Adresse> AdresseClientNavigation { get; set; } = new List<Adresse>();

        [InverseProperty(nameof(Paiement.ClientPaiementNavigation))]
        public virtual ICollection<Paiement> PaiementClientNavigation { get; set; } = new List<Paiement>();

        [InverseProperty(nameof(Commande.ClientCommandeNavigation))]
        public virtual ICollection<Commande> CommandeClientNavigation { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Avis.ClientAvisNavigation))]
        public virtual ICollection<Avis> AvisClientNavigation { get; set; } = new List<Avis>();

        [InverseProperty(nameof(AvisPartenaire.ClientAvisPartenaireNavigation))]
        public virtual ICollection<AvisPartenaire> AvisPartenaireClientNavigation { get; set; } = new List<AvisPartenaire>();
    }
}