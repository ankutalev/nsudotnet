﻿using System.Collections.Generic;

namespace rabotyagiszavoda.Model
{
    public class Workers
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        
        public int? Age { get; set; }
        
        public int? IQ { get; set; }
        
        public ICollection<Projects> Projects { get; set; }
    }
}
