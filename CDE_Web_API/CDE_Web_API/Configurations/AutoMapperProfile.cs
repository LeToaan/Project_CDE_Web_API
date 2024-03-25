using AutoMapper;
using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using Task = CDE_Web_API.Models.Task;

namespace CDE_Web_API.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Account, AccountDTO>();
        CreateMap<AccountDTO, Account>();

        CreateMap<Account, AccountSalesDTO>();
        CreateMap<AccountSalesDTO, Account>();

        CreateMap<Account, AccountSalesUpdateDTO>();
        CreateMap<AccountSalesUpdateDTO, Account>();

        CreateMap<Account, UserDTO>();
        CreateMap<UserDTO, Account>();

        CreateMap<Account, StaffDTO>();
        CreateMap<StaffDTO, Account>();

        CreateMap<Account, AccountLoginDTO>();
        CreateMap<AccountLoginDTO, Account>();

        CreateMap<Account, AccountTokentDTO>();
        CreateMap<AccountTokentDTO, Account>();

        CreateMap<Answer, AnswerDTO>();

        CreateMap<Area, AreaDTO>();
        CreateMap<AreaDTO, Area>();

        CreateMap<Category, CategoryDTO>();

        CreateMap<CMS, CMSDTO>();

        CreateMap<Distributor, DistributorDTO>();
        CreateMap<DistributorDTO, Distributor>();
        CreateMap<Distributor, DistributorUpdateDTO>();
        CreateMap<DistributorUpdateDTO, Distributor>();

        CreateMap<Media, MediaDTO>();

        CreateMap<PermissionModule, ModuleDTO>();

        CreateMap<NotifiUser, NotifiUserDTO>();

        CreateMap<Notification, NotificationDTO>();

        CreateMap<Permission, PermissionDTO>();

        CreateMap<PositionGroup, PositionGroupDTO>();

        CreateMap<PositionTitle, PositionTitleDTO>();
        CreateMap<PositionTitleDTO, PositionTitle>();

        CreateMap<Rate, RateDTO>();

        CreateMap<SurveyDetail, SurveyDetailDTO>();

        CreateMap<SurveyRequest, SurveyRequestDTO>();

        CreateMap<Task, TaskDTO>();
        CreateMap<TaskDTO, Task>();

        CreateMap<Tokent, TokentDTO>();

        CreateMap<UserList, UserListDTO>();

        CreateMap<Visit, VisitDTO>();
        CreateMap<VisitDTO, Visit>();

    }
}
