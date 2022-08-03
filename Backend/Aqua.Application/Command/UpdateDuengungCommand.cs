using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record UpdateDuengungCommand : CreateDuengungCommand, IRequest<DuengungDto>
{
    protected UpdateDuengungCommand(CreateDuengungCommand original) : base(original)
    {
    }

    public Guid Id { get; init; }
}