using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Configuration;
using System.Text;
using AutoMapper;
using DAL;
using static System.Net.Mime.MediaTypeNames;

namespace Service
{


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IService, IServiceStream
    {
        private static Random rand = new Random(44);
        private static Dictionary<int, User> SecretCodes = new Dictionary<int, User>();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static DALClass dal = new DALClass();
        private static IMapper mapper;
        private User ActiveUser = null;

        private static string userPhotosDir = ConfigurationManager.AppSettings["UsersPhotosDirectory"];

        static Service()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DTO.User, User>().PreserveReferences();
                cfg.CreateMap<User, DTO.User>().PreserveReferences();

                cfg.CreateMap<DTO.Chat, Chat>().PreserveReferences();
                cfg.CreateMap<Chat, DTO.Chat>().PreserveReferences();

                cfg.CreateMap<DTO.Message, Message>().PreserveReferences();
                cfg.CreateMap<Message, DTO.Message>().PreserveReferences();
            });
            mapper = config.CreateMapper();


            if (!Directory.Exists(userPhotosDir))
            {
                Logger.Warn($"Create user photos directory '{userPhotosDir}'");
                Directory.CreateDirectory(userPhotosDir);
            }
            
        }

        public Service()
        {
            Logger.Debug("New client connected");
        }

        public Result<DTO.User> Login(string login, string password)
        {
            Logger.Debug($"Login new user login: {login} pass: {password}");
            if (!dal.CheckUserExist(login))
                return Result<DTO.User>.WithError(ResultError.UserNotExist, $"User login {login} not exist");
            if (!dal.CheckUserPassword(password, login))
                return Result<DTO.User>.WithError(ResultError.PasswordIsIncorrect, "Password is incorrect");


            ActiveUser = dal.GetUserByLogin(login);

            return Result<DTO.User>.OK(mapper.Map<DTO.User>(ActiveUser));
        }

        public Result<DTO.User> Register(DTO.User newUser)
        {
            if (dal.CheckUserExist(newUser.Login))
                return Result<DTO.User>.WithError(
                    ResultError.LoginIsUsed, $"User login {newUser.Login} is already used");

            Logger.Debug($"Register new user {newUser.Login}");
            User user = mapper.Map<User>(newUser);
            ActiveUser = user;
            dal.Register(user);
            return Result<DTO.User>.OK(mapper.Map<DTO.User>(user));
        }

        public Result<DTO.User> EditUserInfo(DTO.User newUser)
        {
            if (IsNotAuth()) return Result<DTO.User>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} edit profile");
            dal.EditUser(mapper.Map<User>(newUser));

            return Result<DTO.User>.OK(mapper.Map<DTO.User>(ActiveUser));
        }

        public Result ChangePassword(string newPassword)
        {
            if (IsNotAuth()) return Result.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} change password to {newPassword}. TODO: Use hash!!!");
            dal.ChangePassword(ActiveUser.Id, newPassword);

            return Result.WithError(ResultError.NotImplemented);
        }

        public Result<IEnumerable<DTO.User>> GetContacts()
        {
            if (IsNotAuth())
                return Result<IEnumerable<DTO.User>>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} get contacts");
            return Result<IEnumerable<DTO.User>>.OK(
                mapper.Map<IEnumerable<DTO.User>>(dal.GetUserContacts(ActiveUser.Id)));
        }

        public Result AddContact(int userId)
        {
            if (IsNotAuth()) return Result.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} add contect id {userId}");
            if (dal.GetUserById(userId) == null)
                return Result.WithError(ResultError.UserNotExist, $"User id {userId} not exist!");

            dal.AddContact(ActiveUser.Id, userId);
            return Result.OK;
        }


        public Result<DTO.Chat> CreatePrivateChat(int userId)
        {
            if (IsNotAuth()) return Result<DTO.Chat>.WithError(ResultError.NoAuthorized);
            
            Logger.Debug($"User {ActiveUser.Login} create private chat with user id: {userId}");
            if (dal.GetUserById(userId) == null)
                return Result<DTO.Chat>.WithError(ResultError.UserNotExist, $"User id {userId} not exist");

            Chat chat = new Chat { IsPersonal = true };

            chat.ChatMembers.Add(new ChatMember { User = ActiveUser, ChatId=chat.Id, MemberRoleId=1});
            chat.ChatMembers.Add(new ChatMember { UserId = userId, ChatId=chat.Id, MemberRoleId = 1 });

            dal.AddChat(chat);
            return Result<DTO.Chat>.OK(mapper.Map<DTO.Chat>(chat));
            
            
        }

        public Result<DTO.Chat> CreateChat(string name)
        {
            if (IsNotAuth()) return Result<DTO.Chat>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} create chat name: {name}");
            Chat chat = new Chat { IsPersonal = false, Name = name };
            chat.ChatMembers.Add(new ChatMember { User = ActiveUser, MemberRoleId = 1 });

            dal.AddChat(chat);

            return Result<DTO.Chat>.OK(mapper.Map<DTO.Chat>(chat));
        }

        public Result<DTO.Chat> JoinChat(int chatId)
        {
            if (IsNotAuth()) return Result<DTO.Chat>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} join to chat id {chatId}");
            Chat chat = dal.GetChatById(chatId);

            if (chat == null)
                return Result<DTO.Chat>.WithError(ResultError.ChatNotExist, $"Chat id {chatId} not exst");


            dal.AddChatMemberToChat(new ChatMember { Chat = chat, User = ActiveUser, MemberRoleId = 3}, chat.Id);



            return Result<DTO.Chat>.OK(mapper.Map<DTO.Chat>(chat));
        }

        public Result LeaveChat(int chatId)
        {
            if (IsNotAuth()) return Result.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} leave from chat id {chatId}");
            if (dal.CheckChatExist(chatId))
                return Result<IEnumerable<DTO.Message>>.WithError(
                    ResultError.ChatNotExist, $"Chat id {chatId} not exist");

            if (dal.CheckChatMember(chatId, ActiveUser.Id))
                return Result<DTO.Message>.WithError(ResultError.Null, "You aren't member this chat");


            dal.RemoveChatMember(chatId, ActiveUser.Id);


            return Result.WithError(ResultError.NotImplemented);
        }

        public Result<IEnumerable<DTO.Chat>> GetChats()
        {
            if (IsNotAuth()) return Result<IEnumerable<DTO.Chat>>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} get chats");
            List<DTO.Chat> chats = mapper.Map<List<DTO.Chat>>(dal.GetUserChats(ActiveUser.Id));

            return Result<IEnumerable<DTO.Chat>>.OK(chats);
        }

        public Result<DTO.Message> SendMessage(int chatId, string text)
        {
            if (IsNotAuth()) return Result<DTO.Message>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} send message '{text}' to chat id {chatId}");
            Chat chat = dal.GetChatById(chatId);


            if (chat == null)
                return Result<DTO.Message>.WithError(ResultError.ChatNotExist, $"Chat id {chatId} not exist");


            if (!dal.CheckChatMember(chatId, ActiveUser.Id))
                return Result<DTO.Message>.WithError(ResultError.Null, "You aren't member this chat");


            Message msg = new Message { Chat = chat, Text = text, Sender = ActiveUser, SendDate = DateTime.Now };

            dal.AddMessage(msg);

            return Result<DTO.Message>.OK(mapper.Map<DTO.Message>(msg));
        }

        public Result<DTO.Message> EditMessage(int messageId, string newText)
        {
            if (IsNotAuth()) return Result<DTO.Message>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} edit message id {messageId} new text '{newText}'");
            if (!dal.CheckMessageExist(messageId))
                return Result<DTO.Message>.WithError(ResultError.Null, $"Message id {messageId} not exist");

            Message msg = dal.EditMessage(messageId, new Message { Text = newText });



            return Result<DTO.Message>.OK(mapper.Map<DTO.Message>(msg));
        }

        public Result DeleteMessage(int messageId)
        {
            if (IsNotAuth()) return Result.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} delete message id {messageId}");
            if (!dal.CheckMessageExist(messageId))
                return Result<DTO.Message>.WithError(ResultError.Null, $"Message id {messageId} not exist");
            dal.RemoveMessages(messageId);
            return Result.OK;
        }

        public Result<IEnumerable<DTO.Message>> GetMessages(int chatId)
        {
            if (IsNotAuth())
                return Result<IEnumerable<DTO.Message>>.WithError(ResultError.NoAuthorized);
            Logger.Debug($"User {ActiveUser.Login} get message from chat {chatId}");
            if (!dal.CheckChatExist(chatId))
                return Result<IEnumerable<DTO.Message>>.WithError(
                    ResultError.ChatNotExist, $"Chat id {chatId} not exist");
            List<DTO.Message> msgs = mapper.Map<List<DTO.Message>>(dal.GetChatMessages(chatId));

            return Result<IEnumerable<DTO.Message>>.OK(msgs);
        }
       

        private bool IsNotAuth()
        {
            return ActiveUser == null;
        }

        public Result<List<DTO.User>> SearchUsers(string query)
        {
            if (IsNotAuth())
                return Result<List<DTO.User>>.WithError(ResultError.NoAuthorized);

            Logger.Debug($"User {ActiveUser.Login} search users with query: '{query}'");

            return Result<List<DTO.User>>.OK(mapper.Map<List<DTO.User>>(dal.SearchUsers(query)));
        }
        public Result DeleteAttachment(int id)
        {
            if (IsNotAuth())
                return Result<List<DTO.User>>.WithError(ResultError.NoAuthorized);

            Attachment atach = dal.GetAttachment(id);

            if (atach == null)
                return Result.WithError(ResultError.Null, $"Attachment id '{id}' not exist");

            dal.RemoveAttachment(atach.MessageId, atach);

            return Result.OK;
        }


        public Stream GetFile(int code, int fileId)
        {
            if (!SecretCodes.ContainsKey(code))
            {
                Logger.Warn($"GetFile Error: Secret code is incorrect");
                return null;
            }

            SecretCodes.Remove(code);

            Stream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);


            Attachment attachment = dal.GetAttachment(fileId);

            if(attachment == null)
            {
                Logger.Debug($"GetFile: Attachment id '{fileId}' not exists");
                return null;
            }
            string fullfilepath = Path.Combine(userPhotosDir, attachment.FilePath);

            if (!File.Exists(fullfilepath))
            {
                Logger.Debug($"GetFile: File '{attachment.FilePath}' not found!");
                return null;
            }

            byte[] fileBuffer = File.ReadAllBytes(fullfilepath);


            writer.Write(attachment.FileName);
            writer.Write(attachment.FileSize);
            writer.Write(attachment.FileType);
            writer.Write(attachment.FilePath);
            writer.Write(fileBuffer);

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }


        public Result<int> SendFile(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);

            int code = reader.ReadInt32();
            int messageId = reader.ReadInt32();
            string filename = reader.ReadString();
            int filesize = reader.ReadInt32();
            string filetype = reader.ReadString();

            Logger.Debug($"Send File Code: {code}, MessageId: {messageId} ");
            Logger.Debug($"Filename: {filename}, FileSize: {filesize}, Filetype: {filetype}");


            if (!SecretCodes.ContainsKey(code))
                return Result<int>.WithError(ResultError.NoAuthorized);
            SecretCodes.Remove(code);

            if (!dal.CheckMessageExist(messageId))
                return Result<int>.WithError(ResultError.NotExist, $"Message id {messageId} not exist");

            if (filesize < 1)
                return Result<int>.WithError(ResultError.Null, "File size must be >0");

            if (filesize > int.MaxValue)
                return Result<int>.WithError(ResultError.Null, $"Max file size is {int.MaxValue}");


            string filepath = System.Guid.NewGuid().ToString();


            Attachment attachment = new Attachment
            {
                MessageId = messageId,
                FilePath = $"{filepath}.{filetype}",
                FileName = filename,
                FileType = filetype,
                FileSize = filesize
            };

            File.WriteAllBytes(Path.Combine(userPhotosDir, attachment.FilePath), reader.ReadBytes(filesize));

            dal.AddAttachment(messageId, attachment);

            return Result<int>.OK(attachment.Id);
        }

        public Result<int> CreateSecretCode()
        {
            if (IsNotAuth())
                return Result<int>.WithError(ResultError.NoAuthorized);


            int code = rand.Next();

            SecretCodes.Add(code, ActiveUser);
            Logger.Debug($"Generate new secret code '{code}' for user {ActiveUser.Login}");
            return Result<int>.OK(code);
        }
    }
}
