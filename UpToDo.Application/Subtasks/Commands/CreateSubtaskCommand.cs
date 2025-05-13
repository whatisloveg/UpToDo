using MediatR;

namespace UpToDo.Application.Subtasks.Commands;

public class CreateSubtaskCommand: IRequest<Guid>
{
    public string? Name { get; set; }
    public decimal? EstimatedTime { get; set; }
    public Guid ToDoTaskId { get; set; }
}