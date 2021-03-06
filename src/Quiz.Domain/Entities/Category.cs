﻿using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
