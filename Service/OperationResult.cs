using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [DataContract]
    public enum ResultError
    {
        [EnumMember]
        Null,
        [EnumMember]
        LoginIsUsed,
        [EnumMember]
        UserNotExist,
        [EnumMember]
        ChatNotExist,
        [EnumMember]
        PasswordIsIncorrect,
        [EnumMember]
        NotImplemented,
        [EnumMember]
        NoAuthorized,
        [EnumMember]
        NotExist
    };

    [DataContract]
    public class Result // Operation result
    {
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        [DataMember]
        public readonly bool IsSuccess;
        [DataMember]
        public readonly string Message;
        [DataMember]
        public ResultError Error = ResultError.Null;
        [DataMember]
        public static Result OK = new Result();

        public Result()
        {
            IsSuccess = true;
            Logger.Warn($"Result OK");

        }


        //public Result(string message)
        //{
        //    IsSuccess = false;
        //    Message = message;
        //}
        public Result(ResultError error, string message = null)
        {
            IsSuccess = false;
            Message = message;
            Error = error;
            Logger.Warn($"Result error type: {error} message: {message}");
        }

        public static Result WithError(ResultError error, string message = null)
        {
            return new Result(error, message);
        }
        public static Result WithError(Result result)
        {
            return new Result(result.Error, result.Message);
        }
    }

    [DataContract]
    public class Result<T> : Result
    {
        [DataMember]
        public readonly T Data;

        public Result(T data)
        {
            Logger.Warn($"Result ok with data {data}");

            Data = data;

        }

        public Result(ResultError error, string message) : base(error, message) {}

        public Result(ResultError error) : base(error) { }

        public new static Result<T> OK(T data)
        {
            return new Result<T>(data);
        }

        public new static Result<T> WithError(ResultError error)
        {
            return new Result<T>(error);
        }
        public static Result<T> WithError(ResultError error, string message)
        {
            return new Result<T>(error, message);
        }
    }
}
