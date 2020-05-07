using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    [ServiceContract]
    public interface IServiceStream
    {
        [OperationContract]
        Result<int> SendFile(Stream stream);

        [OperationContract]
        Stream GetFile(int code, int fileId);
    }

    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        Result<DTO.User> Login(string login, string password);
        [OperationContract]
        Result<DTO.User> Register(DTO.User user);
        [OperationContract]
        Result<DTO.User> EditUserInfo(DTO.User newUser);
        
        [OperationContract]
        Result ChangePassword(string newPassword);

        [OperationContract]
        Result AddContact(int userId);
        [OperationContract]
        Result<IEnumerable<DTO.User>> GetContacts();

        [OperationContract]
        Result<List<DTO.User>> SearchUsers(string query);


        [OperationContract]
        Result<DTO.Chat> CreatePrivateChat(int withUserId);
        [OperationContract]
        Result<DTO.Chat> CreateChat(string name);
        [OperationContract]
        Result<DTO.Chat> JoinChat(int chatId);
        [OperationContract]
        Result LeaveChat(int chatId);
        [OperationContract]
        Result<IEnumerable<DTO.Chat>> GetChats();



        [OperationContract]
        Result<DTO.Message> SendMessage(int chatId, string text);

        [OperationContract]
        Result<DTO.Chat> AddContactToChat(int contactId, int chatId);
 
     
        [OperationContract]
        Result<DTO.Message> EditMessage(int messageId, string newText);
        [OperationContract]
        Result DeleteMessage(int messageId);
        [OperationContract]
        Result<IEnumerable<DTO.Message>> GetMessages(int chatId);
        [OperationContract]
        Result DeleteAttachment(int id);

        [OperationContract]
        Result<int> CreateSecretCode();
    }

}
