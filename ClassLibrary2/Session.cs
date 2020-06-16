using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModels
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public Film Film { get; set; }
    }

}
