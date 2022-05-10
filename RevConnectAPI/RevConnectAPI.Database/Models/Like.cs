﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database.Models
{
    public class Like
    {
        [Key]
        [MaxLength(256)]
        public int likeID { get; set; }
        [ForeignKey("User")]
        public int userID { get; set; }
        [ForeignKey("Post")]
        public int? postID { get; set; }
        [ForeignKey("Comment")]
        public int? commentID { get; set; }
    }
}
