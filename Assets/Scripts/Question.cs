﻿
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Answer> Answers { get; set; }
    }
}