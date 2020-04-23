using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Service.DTO;

using DAL;
using AutoMapper;

namespace Service
{
    public class Service : IService
    {
        private static DALClass dal = new DALClass();
        private static IMapper mapper;

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

        public Result Login(string login, string password)
        {
            dal.Login(login, password);

            return Result.OK;
        }
        public Result Register(DTO.User user)
        {
            dal.Register(mapper.Map<DAL.User>(user));
            return Result.OK;
            
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
