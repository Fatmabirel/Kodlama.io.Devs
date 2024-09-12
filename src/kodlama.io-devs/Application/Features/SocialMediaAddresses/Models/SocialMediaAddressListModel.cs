using Application.Features.SocialMediaAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Models
{
    public class SocialMediaAddressListModel : BasePageableModel
    {
        public IList<SocialMediaAddressListDto> Items { get; set; }
    }
}
