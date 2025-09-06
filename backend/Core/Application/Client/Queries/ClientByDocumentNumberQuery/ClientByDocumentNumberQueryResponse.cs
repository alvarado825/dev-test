using System;
using Application.Client.Models;

namespace Application.Client.Queries.ClientByDocumentNumberQuery
{
    public class ClientByDocumentNumberQueryResponse : ClientModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}