﻿using NewsfeedAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedAPIService.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public DateTime TimePosted { get; set; }
        public SourceViewModel Source { get; set; }
        public string Content { get; set; }
        public Object[] Attachments { get; set; }

        public PostViewModel(Post post, Source source)
        {
            Id = post.Id;
            TimePosted = post.TimePosted;
            Source = new SourceViewModel(source);
            Content = post.Content;
            Attachments = post.Attachments;
        }
    }
}
