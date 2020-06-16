using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommonModels
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Session> Sessions { get; set; }
    }
}
