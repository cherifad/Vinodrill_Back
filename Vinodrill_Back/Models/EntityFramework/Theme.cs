﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_theme_thm")]
    public partial class Theme
    {
        [Key]
        [Column("thm_id")]
        public int IdTheme { get; set; }

        [Column("thm_libelle")]
        [StringLength(255, ErrorMessage = "the length of the libelle must be 255 maximum")]
        [Required]
        public string LibelleTheme { get; set; }

        [Column("thm_imgthemepage")]
        [StringLength(255, ErrorMessage = "the length of the imgthemepage must be 255 maximum")]
        [Required]
        public string ImgThemePage { get; set; }

        [Column("thm_contenuthemepage")]
        [Required]
        public string ContenuThemePage { get; set; }
    }
}