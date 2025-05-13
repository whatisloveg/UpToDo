using MediatR;

namespace UpToDo.Application.Subtasks.Commands;

public class UpdateSubtaskCommand: IRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal? EstimatedTime { get; set; }
    public bool IsCompleted { get; set; }
}