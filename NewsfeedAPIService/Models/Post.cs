﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedAPIService.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TimePosted { get; set; }
        public string Content { get; set; }
        [NotMapped]
        public Object[] Attachments { get; set; }

        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
