using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetEmployeeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, EmployeeDto dto)
        {

            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<EmployeeDto>(employee);
        }

        public Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
