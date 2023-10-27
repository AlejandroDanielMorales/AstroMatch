﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateOfComment { get; set; }
        public User Autor { get; set; }
        public Publication PublicationOrigin { get; set; }
    }

}
