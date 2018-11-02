using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace BookCatalogue.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
    
    
public override string ToString()
        {
            string output = $"{this.AuthorName}";
            return output;
}
         
    }
}