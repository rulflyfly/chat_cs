using System;

namespace chat.domain
{
    public record Message (string Author, string Text, List<Like> Likes, bool NSFW);
}

