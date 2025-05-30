namespace UpToDo.Contracts.Tasks.Responses;

public record GetTaskTagResponse(
    Guid TagId,
    string TagName
);