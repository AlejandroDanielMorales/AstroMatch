using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Publication
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPublication { get; set; }
        public User Autor { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
