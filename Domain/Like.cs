using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Like
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Publication Publication { get; set; }
    }
}
