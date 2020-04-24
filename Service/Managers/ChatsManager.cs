using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Managers
{
    using AutoMapper;
    using Models;
    static class ChatsManager
    {
        public static Dictionary<int, Chat> Chats = new Dictionary<int, Chat>();

        private static DAL.DALClass dal = DALProxy.GetInstance();
        private static IMapper mapper = MapperProxy.GetMapper();


        public static void CreateChat()
        {

        }

        public static List<Chat> GetUserChats(int userId)
        {
            return new List<Chat>();
        }

        public static Result<Chat> GetChat(int id)
        {
            if (Chats.ContainsKey(id))
                return Result<Chat>.OK(Chats[id]);

            DAL.Chat dalChat = dal.GetChatById(id);
            if (dalChat == null) return Result<Chat>.WithError(ResultError.ChatNotExist);

            Chat chat = mapper.Map<Chat>(dalChat);
            Chats.Add(chat.Id, chat);

            return Result<Chat>.OK(chat);
        }
    }
}
