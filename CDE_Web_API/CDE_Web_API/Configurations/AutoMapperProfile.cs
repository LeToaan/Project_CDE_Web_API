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
        CreateMap<Category, CategoryDTO>();
        CreateMap<CMS, CMSDTO>();
        CreateMap<Distributor, DistributorDTO>();
        CreateMap<Media, MediaDTO>();
        CreateMap<PermissionModule, ModuleDTO>();
        CreateMap<NotifiUser, NotifiUserDTO>();
        CreateMap<Notification, NotificationDTO>();
        CreateMap<Permission, PermissionDTO>();
        CreateMap<PositionGroup, PositionGroupDTO>();
        CreateMap<PositionTitle, PositionTitleDTO>();
        CreateMap<Rate, RateDTO>();
        CreateMap<SurveyDetail, SurveyDetailDTO>();
        CreateMap<SurveyRequest, SurveyRequestDTO>();
        CreateMap<Task, TaskDTO>();
        CreateMap<Tokent, TokentDTO>();
        CreateMap<UserList, UserListDTO>();
        CreateMap<Visit, VisitDTO>();
    }
}
