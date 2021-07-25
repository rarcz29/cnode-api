using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GitNode.Application.Common.Dtos;
using GitNode.Application.Common.Interfaces.Data.Database;
using MediatR;

namespace GitNode.Application.Technologies.Queries.GetTechnologies
{
    public class GetTechnologiesQuery : IRequest<IEnumerable<TechnologyDto>>
    {
        public string Pattern { get; set; }
    }
    
    public class GetTechnologiesQueryHandler : IRequestHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTechnologiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TechnologyDto>> Handle(GetTechnologiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Technologies.FindTechologiesAsync(request.Pattern);
            return _mapper.Map<IEnumerable<TechnologyDto>>(result);
        }
    }
}
