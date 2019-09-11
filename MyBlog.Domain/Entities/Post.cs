﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Domain.Entities
{
    public class Post : BaseEntity
    {
        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }


        public User Author { get; set; }

        public Category Category { get; set; }
    }
}
