using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiereServer.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }

}
