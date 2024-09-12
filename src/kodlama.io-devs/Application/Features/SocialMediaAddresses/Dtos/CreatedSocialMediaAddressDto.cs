using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Dtos
{
    public class CreatedSocialMediaAddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? MediumUrl { get; set; }
    }
}
