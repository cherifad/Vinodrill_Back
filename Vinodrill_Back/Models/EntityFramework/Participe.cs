﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_participe_ppt")]
    public partial class Participe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_ppt_cppt")]
        [Column("cppt_id")]
        public int IdCategorieParticipant { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_ppt_sjr")]
        [Column("sjr_id")]
        public int IdSejour { get; set; }
    }
}
