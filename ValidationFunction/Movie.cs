using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationFunction
{
    public class Movie
    {
        public string Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Title { get; set; }


        [Range(0, 999.99)]
        public decimal Price { get; set; }

    }
}
