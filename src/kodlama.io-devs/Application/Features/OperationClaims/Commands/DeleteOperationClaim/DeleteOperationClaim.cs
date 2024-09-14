using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }
        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _OperationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository OperationClaimRepository, IMapper mapper)
            {
                _OperationClaimRepository = OperationClaimRepository;
                _mapper = mapper;
            }
            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim OperationClaim = _mapper.Map<OperationClaim>(request); //map request
                OperationClaim deletedOperationClaim = await _OperationClaimRepository.DeleteAsync(OperationClaim); // delete MAPPED "OperationClaim"
                DeletedOperationClaimDto deletedOperationClaimDto = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
                return deletedOperationClaimDto;
            }
        }
    }

}
