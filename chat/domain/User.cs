﻿using System;
namespace chat.domain
{
    public record User
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    };
}

