﻿using NewsfeedAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedAPIService.ViewModels
{
    public class SourceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Service { get; set; }

        public SourceViewModel(Source source)
        {
            Id = source.Id;
            Name = source.Name;
            Service = source.Service;
            switch (this.Service)
            {
                case "VK":
                    Url = "https://vk.com/" + source.Url;
                    break;
                case "Twitter":
                    Url = "https://twitter.com/" + source.Url;
                    break;
                default:
                    Url = source.Url;
                    break;
            }
        }
    }
}
