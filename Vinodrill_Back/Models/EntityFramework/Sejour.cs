﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_sejour_sjr")]
    public partial class Sejour
    {

        [Key]
        [ForeignKey("fk_sjr_thm")]
        [Column("thm_id", Order = 0)]
        public int IdTheme { get; set; }

        [Key]
        [ForeignKey("fk_sjr_dst")]
        [Column("dst_id", Order = 1)]
        public int IdDestination { get; set; }

        [Key]
        [Column("sjr_id")]
        public int IdSejour { get; set; }

        [Column("sjr_titre")]
        [StringLength(255, ErrorMessage = " titre lenght must be 255 maximum")]
        [Required]
        public string TitreSejour { get; set; }

        [Column("sjr_photo")]
        [StringLength(255, ErrorMessage = " photo lenght must be 255 maximum")]
        [Required]
        public string PhotoSejour { get; set; }

        [Column("sjr_prix")]
        [Required]
        public Decimal PrixSejour { get; set; }

        [Column("sjr_description")]
        [Required]
        public string DescriptionSejour { get; set; }

        [Column("sjr_nbjour")]
        [Required]
        public int NbJour { get; set; }

        [Column("sjr_nbnuit")]
        [Required]
        public int NbNuit { get; set; }

        [Column("sjr_libelletemps")]
        [StringLength(255, ErrorMessage = " libelletemps lenght must be 255 maximum")]
        [Required]
        public string LibelleTemps { get; set; }

        [Column("sjr_notemoyenne")]
        [Required]
        public Decimal NoteMoyenne { get; set; }
    }
}