using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Client.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommandRequest, Guid>
    {
        private readonly IClientControlContext _context;

        public UpdateClientCommandHandler(IClientControlContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateClientCommandRequest request, CancellationToken cancellationToken)
        {
            if (!CpfValidator.IsACpfValid(request.Identificator))
                throw new BadRequestException($"The number of the identificator {request.Identificator} is invalid");
            
            var client = await _context.Clients
                        .Include(c => c.Address)
                        .SingleOrDefaultAsync(c => c.DocumentNumber == request.Identificator, cancellationToken);

            if (client == null)
                throw new BadRequestException($"No data found to update with this identifier number: {request.Identificator}");


            if (request.BirthDate != null)
            {
                DateTime convertedBirthDate = Parsers.StringToDateTime(request.BirthDate);

                if (convertedBirthDate == DateTime.MinValue)
                    throw new BadRequestException("BirthDate in an invalid format");
                client.UpdateBirthDate(convertedBirthDate);

            }    

            if (request.FirstName != null) client.UpdateFirstName(request.FirstName);
            if (request.LastName != null) client.UpdateLastName(request.LastName);
            if (request.PhoneNumber != null) client.UpdatePhoneNumber(request.PhoneNumber);
            if (request.Email != null) client.UpdateEmail(request.Email);


            if (request.Address != null)
            {
                if (request.Address.State != null) client.Address.UpdateState(request.Address.State);
                if (request.Address.PostalCode != null) client.Address.UpdatePostalCode(request.Address.PostalCode);
                if (request.Address.AddressLine != null) client.Address.UpdateAddressLine(request.Address.AddressLine);
                if (request.Address.Number != null) client.Address.UpdateNumber(request.Address.Number);
                if (request.Address.Neighborhood != default) client.Address.UpdateNeighborhood(request.Address.Neighborhood);
                if (request.Address.City != null) client.Address.UpdateCity(request.Address.City);
                if (request.Address.Complement != default) client.Address.UpdateComplement(request.Address.Complement);
            }
            
            await _context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}