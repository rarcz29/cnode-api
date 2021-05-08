using AutoMapper;
using CNode.Application.Common.Data.Database;
using CNode.Application.Technologies.Queries.GetTechnologies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Technologies.Handlers.QueryHandlers
{
    class GetTechnologiesQueryHandler : IRequestHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>>
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
