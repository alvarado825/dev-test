using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Client.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommandRequest, Guid>
    {
        private readonly IClientControlContext _context;

        public CreateClientCommandHandler(IClientControlContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateClientCommandRequest request, CancellationToken cancellationToken)
        {
            if (!CpfValidator.IsACpfValid(request.DocumentNumber))
                throw new BadRequestException($"The number of the identificator {request.DocumentNumber} is invalid");

            DateTime convertedBirthDate = Parsers.StringToDateTime(request.BirthDate);

            if (convertedBirthDate == DateTime.MinValue)
                throw new BadRequestException("BirthDate in an invalid format");

            var client = new Domain.Client(
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.Email,
                CpfValidator.FormatCpf(request.DocumentNumber),
                Parsers.StringToDateTime(request.BirthDate),
                new Domain.Address(
                    request.Address.PostalCode,
                    request.Address.AddressLine,
                    request.Address.Number,
                    request.Address.Complement,
                    request.Address.Neighborhood,
                    request.Address.City,
                    request.Address.State));

            if (await _context.Clients.AnyAsync(x => x.DocumentNumber == client.DocumentNumber))
                throw new BadRequestException("Document already exists");

            await _context.Clients.AddAsync(client, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
