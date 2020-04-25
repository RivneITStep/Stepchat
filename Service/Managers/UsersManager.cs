using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Managers
{
    using AutoMapper;
    using Models;
    static class DALProxy
    {
        private static DAL.DALClass Instance;

        public static DAL.DALClass GetInstance()
        {
            if (Instance == null)
                Instance = new DAL.DALClass();

            return Instance;
        }
    }
    static class MapperProxy
    {
        private static IMapper mapper;

        static MapperProxy()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, DAL.User>().PreserveReferences();
                cfg.CreateMap<DAL.User, Models.User>().PreserveReferences();
                cfg.CreateMap<User, DTO.User>().PreserveReferences();
                cfg.CreateMap<DTO.User, DAL.User>().PreserveReferences();
            });
            mapper = config.CreateMapper();
        }

        public static IMapper GetMapper()
        {
            return mapper;
        }
    }



    static class UsersManager
    {
        private static Dictionary<int, User> Users = new Dictionary<int, User>();

        private static DAL.DALClass dal = DALProxy.GetInstance();
        private static IMapper mapper = MapperProxy.GetMapper();


        public static Result<User> RegisterUser(DTO.User newUser)
        {
            if (dal.CheckUserExist(newUser.Login)) return Result<User>.WithError(ResultError.LoginIsUsed);

            dal.Register(mapper.Map<DAL.User>(newUser));

            User user = mapper.Map<User>(dal.GetUserByLogin(newUser.Login));

            Users.Add(user.Id, user);

            return Result<User>.OK(user);
        }

        public static Result<User> LoginUser(string login, string password)
        {
            if (!dal.CheckUserExist(login)) return Result<User>.WithError(ResultError.UserNotExist);
            if (!dal.CheckUserPassword(password, login)) return Result<User>.WithError(ResultError.UserNotExist);


            User user =  mapper.Map<User>(dal.GetUserByLogin(login));

            Users.Add(user.Id, user);

            return Result<User>.OK(user);
        }


        public static User GetUser(int id)
        {
            if(Users.ContainsKey(id))
                return Users[id];

            User user = mapper.Map<User>(dal.GetUserById(id));
            Users.Add(user.Id, user);

            return user;
        }
    }
}
