using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Contracts.Dtos
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public Guid ReferenceId { get; set; }
        public string Uri { get; set; }
    }
}
