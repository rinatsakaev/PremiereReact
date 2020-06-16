using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiereReact.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string PageSlug { get; set; }
        public DateTime DateTime { get; set; }
    }
}
