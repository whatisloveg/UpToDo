namespace UpToDo.Contracts.Tags.Requests;

public record CreateTagRequest(Guid UserId, string Name);