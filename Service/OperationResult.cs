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
        NotImplemented
    };

    [DataContract]
    public class Result // Operation result
    {
        [DataMember]
        public readonly bool IsSuccess;
        [DataMember]
        public ResultError Error = ResultError.Null;
        [DataMember]
        public static Result OK = new Result();

        public Result()
        {
            IsSuccess = true;
        }

        public static Result WithError(ResultError error)
        {
            return new Result(error);
        }

        public Result(ResultError error)
        {
            Error = error;
            IsSuccess = false;
        }
    }

    [DataContract]
    public class Result<T> : Result
    {
        [DataMember]
        public readonly T Data;

        public Result(T data)
        {
            Data = data;

        }
        public Result(ResultError error) : base(error) { }

        public new static Result<T> OK(T data)
        {
            return new Result<T>(data);
        }

        public new static Result<T> WithError(ResultError error)
        {
            return new Result<T>(error);
        }
    }
}
