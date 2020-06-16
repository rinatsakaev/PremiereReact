using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.ExpressionVisitors.MemberBindings;

namespace PremiereServer.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
