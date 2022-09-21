using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class UpdateNotizCommandHandler : IRequestHandler<UpdateNotizCommand, NotizDto>
{
    private readonly INotizRepository _repository;

    public UpdateNotizCommandHandler(
        INotizRepository repository)
    {
        _repository = repository;
    }

    public async Task<NotizDto> Handle(
        UpdateNotizCommand request,
        CancellationToken cancellationToken)
    {
        var notiz = new Notiz
        {
            Id = request.Id,
            UserId = request.UserId ?? throw new NullReferenceException("Missing UserId"),
            Text = request.Text,
            AquariumId = request.AquariumId,
            Tag = request.Tag,
            Datum = request.Datum,
        };
        var result = await _repository.UpdateAsync(notiz, cancellationToken);
        return result.BuildDto();
    }
}