namespace chat.domain
{
    public record Message (int Id, int UserId, string Text, List<Like> Likes, bool NSFW);
}

