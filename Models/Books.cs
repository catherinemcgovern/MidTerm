using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace BookCatalogue.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }

        /*public int TeamId { get; set; }
public Team Team { get; set; } */
        public int AuthorId { get; set; }
        //public string AuthorName { get; set; }
        public Authors Authors { get; set; }

     public override string ToString()
        {
            string output = $"{this.Title} - {this.Publisher} - {this.PublishDate} - {this.Pages}";
            return output;
}
    }
}