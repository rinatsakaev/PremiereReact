using System;

namespace CommonModels
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public Film Film { get; set; }
    }

}
