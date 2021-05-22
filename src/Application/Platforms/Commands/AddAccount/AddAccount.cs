using CNode.Application.Common.Dtos;
using CNode.Application.Common.Interfaces;
using CNode.Application.Common.Mappings;
using MediatR;

namespace CNode.Application.Platforms.Commands.AddAccount
{
    public class AddAccount
    {
        public string Code { get; set; }
    }
}
