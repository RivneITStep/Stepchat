using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class Attachment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public string FileType { get; set; }
        [DataMember]
        public int FileSize { get; set; }
        [DataMember]
        public int MessageId { get; set; }
    }
}
