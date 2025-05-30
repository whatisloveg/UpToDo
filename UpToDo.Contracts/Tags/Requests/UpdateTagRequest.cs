namespace UpToDo.Contracts.Tags.Requests;

public record UpdateTagRequest(Guid TagId, string NewTagName);