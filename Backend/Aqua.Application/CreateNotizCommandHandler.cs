using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain.Sql;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreateNotizCommandHandler : IRequestHandler<CreateNotizCommand, NotizDto>
{
    private readonly INotizRepository _repository;

    public CreateNotizCommandHandler(
        INotizRepository repository)
    {
        _repository = repository;
    }

    public async Task<NotizDto> Handle(
        CreateNotizCommand request,
        CancellationToken cancellationToken)
    {
        var notiz = new Notiz
        {
            UserId = request.UserId ?? throw new ArgumentNullException("UserId darf nicht null sein"),
            Text = request.Text,
            AquariumId = request.AquariumId,
            Tag = request.Tag,
            Datum = request.Datum,
        };
        await _repository.CreateAsync(notiz, cancellationToken);
        return new NotizDto(notiz.Id, notiz.Text, notiz.Tag, new AquariumDto(notiz.Aquarium.Id, notiz.Aquarium.Name, notiz.Aquarium.Liter, notiz.Aquarium.Datum), notiz.Datum);
    }
}