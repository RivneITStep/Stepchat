using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using DAL;


namespace Service
{


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static DALClass dal = new DALClass();
        private static IMapper mapper;
        private User ActiveUser = null;

        static Service()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, DTO.User>().PreserveReferences();
                cfg.CreateMap<Chat, DTO.Chat>().PreserveReferences();
                
            });
            mapper = config.CreateMapper();
        }

        public Service()
        {
            Logger.Debug("Init new user");
        }

        public Result<DTO.User> Login(string login, string password)
        {
            if (!dal.CheckUserExist(login))
                return Result<DTO.User>.WithError(ResultError.UserNotExist, $"User login {login} not exist");
            if (!dal.CheckUserPassword(password, login))
                return Result<DTO.User>.WithError(ResultError.PasswordIsIncorrect, "Password is incorrect");


            ActiveUser = dal.GetUserByLogin(login);

            return Result<DTO.User>.OK(mapper.Map<DTO.User>(ActiveUser));
        }

        public Result<DTO.User> Register(DTO.User user)
        {
            if (!dal.CheckUserExist(user.Login))
                return Result<DTO.User>.WithError(ResultError.LoginIsUsed, $"User login {user.Login} is already used");

            
            dal.Register(mapper.Map<User>(user));
            return Result<DTO.User>.OK(user);
        }

        public IEnumerable<DTO.User> GetContacts()
        {
            return mapper.Map<IEnumerable<DTO.User>>(dal.GetUserContacts(ActiveUser.Id));
        }
        public Result AddContact(int userId)
        {
            dal.AddContact(ActiveUser.Id, userId);

            return Result.OK;
        }


        public Result<DTO.Chat> CreatePrivateChat(int userId)
        {
            if (dal.GetUserById(userId) == null)
                return Result<DTO.Chat>.WithError(ResultError.UserNotExist, $"User id {userId} not exist");

            Chat chat = new Chat { IsPersonal = true };
            dal.AddChat(chat);

            chat.ChatMembers.Add(new ChatMember { User = ActiveUser, ChatId=chat.Id });
            chat.ChatMembers.Add(new ChatMember { UserId = userId, ChatId=chat.Id });

            // save changes
            
            return Result<DTO.Chat>.OK(null);
        }

        public Result SendMessage(int chatId, string message)
        {
            dal.AddMessage(new Message { ChatId = chatId, Text = message, Sender = ActiveUser });
            return Result.OK;
        }

        


       
    }
}
