namespace Aldebaran.Chat.Models;

public sealed record Message(
    Guid UserId, 
    string Text, 
    DateTime SentAt);
