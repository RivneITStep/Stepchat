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
        Result AddContact(int userId);
        [OperationContract]
        IEnumerable<DTO.User> GetContacts();


        [OperationContract]
        Result<DTO.Chat> CreatePrivateChat(int withUserId);

    }

}
