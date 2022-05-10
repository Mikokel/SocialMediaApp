﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database.Models
{
    public class Comment
    {
        [Key]
        [MaxLength(256)]
        public int commentID { get; set; }
        public string body { get; set; }
        public string date { get; set; }
        public List<Like>? commentLikes { get; set; }
        [ForeignKey("Post")]
        public int postID { get; set; }
        [ForeignKey("User")]
        public int userID { get; set; }



    }
}
