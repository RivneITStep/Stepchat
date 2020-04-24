using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DAL;
using AutoMapper;
using Service.Managers;

namespace Service
{
    public class Service : IService
    {
        private static DALClass dal = new DALClass();
        private static IMapper mapper;

        private Models.User User;

        static Service() // Initialization
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.User, DTO.User>();
                cfg.CreateMap<DTO.User, DAL.User>();

                cfg.CreateMap<DAL.Chat, DTO.Chat>();
                cfg.CreateMap<DTO.Chat, DAL.Chat>();

                cfg.CreateMap<DAL.Message, DTO.Message>();
                cfg.CreateMap<DTO.Message, DAL.Message>();
            });
            mapper = config.CreateMapper();
        }

        public Result AddUserToChat(int userId, int chatId)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result ChangePassword(string newPassword)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result CreateChat(string name)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result CreatePrivateChat(int userId)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result EditName(string newFirstname, string newLastname, string newBio)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result<IEnumerable<DTO.Message>> GetChatHistory(int chatId)
        {
            return Result<IEnumerable<DTO.Message>>.WithError(ResultError.NotImplemented);
        }

        public Result<IEnumerable<DTO.Chat>> GetChats()
        {
            return Result<IEnumerable<DTO.Chat>>.WithError(ResultError.NotImplemented);
        }

        public Result JoinToChat(int chatId)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result LeaveFromChat(int chatId)
        {
            return Result.WithError(ResultError.NotImplemented);
        }

        public Result<DTO.User> Login(string login, string password)
        {
            Result<Models.User> r = UsersManager.LoginUser(login, password);
            DTO.User dtoUser = mapper.Map<DTO.User>(r.Data);

            if (!r.IsSuccess) return Result<DTO.User>.WithError(r.Error);

            User = r.Data;

            return Result<DTO.User>.OK(dtoUser);
        }

        public Result<DTO.User> Register(DTO.User user)
        {
            Result<Models.User> r = UsersManager.RegisterUser(user);
            DTO.User dtoUser = mapper.Map<DTO.User>(r.Data);

            if (!r.IsSuccess) return Result<DTO.User>.WithError(r.Error);

            User = r.Data;

            return Result<DTO.User>.OK(dtoUser);
        }

        public Result<IEnumerable<DTO.Chat>> SearchChats(string query)
        {
            return Result<IEnumerable<DTO.Chat>>.WithError(ResultError.NotImplemented);
        }

        public Result<IEnumerable<DTO.User>> SearchUsers(string query)
        {
            return Result<IEnumerable<DTO.User>>.WithError(ResultError.NotImplemented);
        }

        public Result SendMessage(int chatId, string message)
        {
            return Result.WithError(ResultError.NotImplemented);
        }
    }
}
