using System;
namespace chat
{
    public record Message (string Author, string Text, List<Like> Likes);
}

