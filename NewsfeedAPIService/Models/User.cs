﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedAPIService.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarFilename { get; set; }

        public List<Digest> Digests { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public List<Friendship> Friendships { get; set; }

        public User()
        {
            AvatarFilename = "avatarPlaceholder.png";
            Digests = new List<Digest>();
            Subscriptions = new List<Subscription>();
            Friendships = new List<Friendship>();
        }
    }
}
