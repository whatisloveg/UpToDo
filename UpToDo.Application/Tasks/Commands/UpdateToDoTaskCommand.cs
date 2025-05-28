using MediatR;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class UpdateToDoTaskCommand: IRequest<UpdateToDoTaskResponse>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? EstimatedTime { get; set; }
    public bool IsCompleted { get; set; }
}