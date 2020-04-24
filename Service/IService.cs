using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Result<DTO.User> Login(string login, string password);

        [OperationContract]
        Result<DTO.User> Register(DTO.User user);

        [OperationContract]
        Result SendMessage(int chatId, string message);

        [OperationContract]
        Result CreateChat(string name);

        [OperationContract]
        Result CreatePrivateChat(int userId);

        [OperationContract]
        Result AddUserToChat(int userId, int chatId);

        [OperationContract]
        Result JoinToChat(int chatId);

        [OperationContract]
        Result LeaveFromChat(int chatId);

        [OperationContract]
        Result<IEnumerable<DTO.User>> SearchUsers(string query);

        [OperationContract]
        Result<IEnumerable<DTO.Chat>> SearchChats(string query);

        [OperationContract]
        Result<IEnumerable<DTO.Chat>> GetChats();

        [OperationContract]
        Result EditName(string newFirstname, string newLastname, string newBio);

        [OperationContract]
        Result ChangePassword(string newPassword);

        [OperationContract]
        Result<IEnumerable<DTO.Message>> GetChatHistory(int chatId);


    }

}
