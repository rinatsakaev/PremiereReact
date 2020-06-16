using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.ExpressionVisitors.MemberBindings;

namespace PremiereServer.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Session> Sessions { get; set; }
    }
}
