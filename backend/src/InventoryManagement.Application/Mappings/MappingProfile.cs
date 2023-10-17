using AutoMapper;
using InventoryManagement.Application.Dtos;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InventoryGroup, InventoryGroupDto>();
            CreateMap<Inventory, InventoryDto>();
            CreateMap<VehicleInventory, VehicleInventoryDto>();
            CreateMap<Communication, CommunicationDto>();
            CreateMap<Insurance, InsuranceDto>();
            CreateMap<VehicleInspection, VehicleInspectionDto>();
            CreateMap<Operator, OperatorDto>();
            CreateMap<Maintenance, MaintenanceDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Debit, DebitDto>();

        }
    }
}
