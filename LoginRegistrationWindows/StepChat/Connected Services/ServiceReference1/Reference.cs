﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StepChat.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        Service.Result<Service.DTO.User> Login([System.ServiceModel.MessageParameterAttribute(Name="login")] string login1, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        System.Threading.Tasks.Task<Service.Result<Service.DTO.User>> LoginAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        Service.Result<Service.DTO.User> Register(Service.DTO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        System.Threading.Tasks.Task<Service.Result<Service.DTO.User>> RegisterAsync(Service.DTO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendMessage", ReplyAction="http://tempuri.org/IService/SendMessageResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result SendMessage(int chatId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendMessage", ReplyAction="http://tempuri.org/IService/SendMessageResponse")]
        System.Threading.Tasks.Task<Service.Result> SendMessageAsync(int chatId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateChat", ReplyAction="http://tempuri.org/IService/CreateChatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result CreateChat(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateChat", ReplyAction="http://tempuri.org/IService/CreateChatResponse")]
        System.Threading.Tasks.Task<Service.Result> CreateChatAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddContact", ReplyAction="http://tempuri.org/IService/AddContactResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result AddContact(int contactId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddContact", ReplyAction="http://tempuri.org/IService/AddContactResponse")]
        System.Threading.Tasks.Task<Service.Result> AddContactAsync(int contactId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetContacts", ReplyAction="http://tempuri.org/IService/GetContactsResponse")]
        Service.Result<int[]> GetContacts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetContacts", ReplyAction="http://tempuri.org/IService/GetContactsResponse")]
        System.Threading.Tasks.Task<Service.Result<int[]>> GetContactsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreatePrivateChat", ReplyAction="http://tempuri.org/IService/CreatePrivateChatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result CreatePrivateChat(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreatePrivateChat", ReplyAction="http://tempuri.org/IService/CreatePrivateChatResponse")]
        System.Threading.Tasks.Task<Service.Result> CreatePrivateChatAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddUserToChat", ReplyAction="http://tempuri.org/IService/AddUserToChatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result AddUserToChat(int userId, int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddUserToChat", ReplyAction="http://tempuri.org/IService/AddUserToChatResponse")]
        System.Threading.Tasks.Task<Service.Result> AddUserToChatAsync(int userId, int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/JoinToChat", ReplyAction="http://tempuri.org/IService/JoinToChatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result JoinToChat(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/JoinToChat", ReplyAction="http://tempuri.org/IService/JoinToChatResponse")]
        System.Threading.Tasks.Task<Service.Result> JoinToChatAsync(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LeaveFromChat", ReplyAction="http://tempuri.org/IService/LeaveFromChatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result LeaveFromChat(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LeaveFromChat", ReplyAction="http://tempuri.org/IService/LeaveFromChatResponse")]
        System.Threading.Tasks.Task<Service.Result> LeaveFromChatAsync(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SearchUsers", ReplyAction="http://tempuri.org/IService/SearchUsersResponse")]
        Service.Result<Service.DTO.User[]> SearchUsers(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SearchUsers", ReplyAction="http://tempuri.org/IService/SearchUsersResponse")]
        System.Threading.Tasks.Task<Service.Result<Service.DTO.User[]>> SearchUsersAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SearchChats", ReplyAction="http://tempuri.org/IService/SearchChatsResponse")]
        Service.Result<Service.DTO.Chat[]> SearchChats(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SearchChats", ReplyAction="http://tempuri.org/IService/SearchChatsResponse")]
        System.Threading.Tasks.Task<Service.Result<Service.DTO.Chat[]>> SearchChatsAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetChats", ReplyAction="http://tempuri.org/IService/GetChatsResponse")]
        Service.Result<Service.DTO.Chat[]> GetChats();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetChats", ReplyAction="http://tempuri.org/IService/GetChatsResponse")]
        System.Threading.Tasks.Task<Service.Result<Service.DTO.Chat[]>> GetChatsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditName", ReplyAction="http://tempuri.org/IService/EditNameResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result EditName(string newFirstname, string newLastname, string newBio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditName", ReplyAction="http://tempuri.org/IService/EditNameResponse")]
        System.Threading.Tasks.Task<Service.Result> EditNameAsync(string newFirstname, string newLastname, string newBio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangePassword", ReplyAction="http://tempuri.org/IService/ChangePasswordResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<int[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Chat[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.Message[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Service.Result<Service.DTO.User>))]
        Service.Result ChangePassword(string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangePassword", ReplyAction="http://tempuri.org/IService/ChangePasswordResponse")]
        System.Threading.Tasks.Task<Service.Result> ChangePasswordAsync(string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetChatHistory", ReplyAction="http://tempuri.org/IService/GetChatHistoryResponse")]
        Service.Result<Service.DTO.Message[]> GetChatHistory(int chatId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetChatHistory", ReplyAction="http://tempuri.org/IService/GetChatHistoryResponse")]
        System.Threading.Tasks.Task<Service.Result<Service.DTO.Message[]>> GetChatHistoryAsync(int chatId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : StepChat.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<StepChat.ServiceReference1.IService>, StepChat.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Service.Result<Service.DTO.User> Login(string login1, string password) {
            return base.Channel.Login(login1, password);
        }
        
        public System.Threading.Tasks.Task<Service.Result<Service.DTO.User>> LoginAsync(string login, string password) {
            return base.Channel.LoginAsync(login, password);
        }
        
        public Service.Result<Service.DTO.User> Register(Service.DTO.User user) {
            return base.Channel.Register(user);
        }
        
        public System.Threading.Tasks.Task<Service.Result<Service.DTO.User>> RegisterAsync(Service.DTO.User user) {
            return base.Channel.RegisterAsync(user);
        }
        
        public Service.Result SendMessage(int chatId, string message) {
            return base.Channel.SendMessage(chatId, message);
        }
        
        public System.Threading.Tasks.Task<Service.Result> SendMessageAsync(int chatId, string message) {
            return base.Channel.SendMessageAsync(chatId, message);
        }
        
        public Service.Result CreateChat(string name) {
            return base.Channel.CreateChat(name);
        }
        
        public System.Threading.Tasks.Task<Service.Result> CreateChatAsync(string name) {
            return base.Channel.CreateChatAsync(name);
        }
        
        public Service.Result AddContact(int contactId) {
            return base.Channel.AddContact(contactId);
        }
        
        public System.Threading.Tasks.Task<Service.Result> AddContactAsync(int contactId) {
            return base.Channel.AddContactAsync(contactId);
        }
        
        public Service.Result<int[]> GetContacts() {
            return base.Channel.GetContacts();
        }
        
        public System.Threading.Tasks.Task<Service.Result<int[]>> GetContactsAsync() {
            return base.Channel.GetContactsAsync();
        }
        
        public Service.Result CreatePrivateChat(int userId) {
            return base.Channel.CreatePrivateChat(userId);
        }
        
        public System.Threading.Tasks.Task<Service.Result> CreatePrivateChatAsync(int userId) {
            return base.Channel.CreatePrivateChatAsync(userId);
        }
        
        public Service.Result AddUserToChat(int userId, int chatId) {
            return base.Channel.AddUserToChat(userId, chatId);
        }
        
        public System.Threading.Tasks.Task<Service.Result> AddUserToChatAsync(int userId, int chatId) {
            return base.Channel.AddUserToChatAsync(userId, chatId);
        }
        
        public Service.Result JoinToChat(int chatId) {
            return base.Channel.JoinToChat(chatId);
        }
        
        public System.Threading.Tasks.Task<Service.Result> JoinToChatAsync(int chatId) {
            return base.Channel.JoinToChatAsync(chatId);
        }
        
        public Service.Result LeaveFromChat(int chatId) {
            return base.Channel.LeaveFromChat(chatId);
        }
        
        public System.Threading.Tasks.Task<Service.Result> LeaveFromChatAsync(int chatId) {
            return base.Channel.LeaveFromChatAsync(chatId);
        }
        
        public Service.Result<Service.DTO.User[]> SearchUsers(string query) {
            return base.Channel.SearchUsers(query);
        }
        
        public System.Threading.Tasks.Task<Service.Result<Service.DTO.User[]>> SearchUsersAsync(string query) {
            return base.Channel.SearchUsersAsync(query);
        }
        
        public Service.Result<Service.DTO.Chat[]> SearchChats(string query) {
            return base.Channel.SearchChats(query);
        }
        
        public System.Threading.Tasks.Task<Service.Result<Service.DTO.Chat[]>> SearchChatsAsync(string query) {
            return base.Channel.SearchChatsAsync(query);
        }
        
        public Service.Result<Service.DTO.Chat[]> GetChats() {
            return base.Channel.GetChats();
        }
        
        public System.Threading.Tasks.Task<Service.Result<Service.DTO.Chat[]>> GetChatsAsync() {
            return base.Channel.GetChatsAsync();
        }
        
        public Service.Result EditName(string newFirstname, string newLastname, string newBio) {
            return base.Channel.EditName(newFirstname, newLastname, newBio);
        }
        
        public System.Threading.Tasks.Task<Service.Result> EditNameAsync(string newFirstname, string newLastname, string newBio) {
            return base.Channel.EditNameAsync(newFirstname, newLastname, newBio);
        }
        
        public Service.Result ChangePassword(string newPassword) {
            return base.Channel.ChangePassword(newPassword);
        }
        
        public System.Threading.Tasks.Task<Service.Result> ChangePasswordAsync(string newPassword) {
            return base.Channel.ChangePasswordAsync(newPassword);
        }
        
        public Service.Result<Service.DTO.Message[]> GetChatHistory(int chatId) {
            return base.Channel.GetChatHistory(chatId);
        }
        
        public System.Threading.Tasks.Task<Service.Result<Service.DTO.Message[]>> GetChatHistoryAsync(int chatId) {
            return base.Channel.GetChatHistoryAsync(chatId);
        }
    }
}
