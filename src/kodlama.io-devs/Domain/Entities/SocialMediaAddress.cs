using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMediaAddress : Entity
    {
        public int UserId { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? MediumUrl { get; set; }
        public string? PersonalWebSiteUrl { get; set; }
        public virtual User User { get; set; } // her sosyal medya hesabı bir kullanıcıya ait olmalı

        public SocialMediaAddress()
        {
            
        }
        public SocialMediaAddress(int id, int userId, string? githubUrl, string? linkedinUrl, string? ınstagramUrl, string? twitterUrl, string? mediumUrl, string? personalWebSiteUrl, User user)
        {
            Id = id;
            UserId = userId;
            GithubUrl = githubUrl;
            LinkedinUrl = linkedinUrl;
            InstagramUrl = ınstagramUrl;
            TwitterUrl = twitterUrl;
            MediumUrl = mediumUrl;
            PersonalWebSiteUrl = personalWebSiteUrl;
            User = user;
        }
    }
}
