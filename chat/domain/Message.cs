using System;

namespace chat.domain
{
    public record Message (double UserId, string Text, List<Like> Likes, bool NSFW);
}

