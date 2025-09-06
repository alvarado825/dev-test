using System;
using Application.Client.Models;
using MediatR;

namespace Application.Client.Commands.UpdateClient
{
    public class UpdateClientCommandRequest : IRequest<Guid>
    {
        public string? Identificator { get; set; }
        public string? DocumentNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthDate { get; set; }
        public UpdateAddressRequest? Address { get; set; }
    }

    public class UpdateAddressRequest
    {
        public string? PostalCode { get; set; }
        public string? AddressLine { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}