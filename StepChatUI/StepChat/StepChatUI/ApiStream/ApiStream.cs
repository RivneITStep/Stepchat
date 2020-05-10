using StepChat.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepChat.StepChatUI.ApiStream
{
    public static class ApiStream
    {
        private static ServiceStreamClient serviceStream = new ServiceStreamClient();




        public static int AttachFile(ServiceClient client, int messageId, string filepath)
        {
            int code = GetSecretCode(client);

            string filename = Path.GetFileNameWithoutExtension(filepath);
            string filetype = Path.GetExtension(filepath).Substring(1);




            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
            writer.Write((Int32)code);
            writer.Write((Int32)messageId);
            writer.Write(filename);

            byte[] fileBuffer = File.ReadAllBytes(filepath);

            if (fileBuffer.Length > int.MaxValue)
                throw new Exception($"Max file size is {int.MaxValue} file size: {fileBuffer.Length}");

            writer.Write((Int32)fileBuffer.Length);
            writer.Write(filetype);
            writer.Write(fileBuffer);

            stream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(stream.Length);
            var r = serviceStream.SendFile(stream);
            if (!r.IsSuccess)
                throw new Exception($"Error on service: {r.Error} {r.Message}");


            return r.Data;
        }

        public static void GetFile(ServiceClient client, int fileId, string saveToDirecory = "")
        {
            int code = GetSecretCode(client);

            Stream stream;
            stream = serviceStream.GetFile(code, fileId);
            try
            {
            }
            catch (Exception)
            {
                throw new Exception("Service error, received stream is over size or see service log");
            }

            BinaryReader reader = new BinaryReader(stream);
            string filename = reader.ReadString();
            int filesize = reader.ReadInt32();
            string filetype = reader.ReadString();
            string filepath = reader.ReadString();

            byte[] fileBuffer = reader.ReadBytes(filesize);


            File.WriteAllBytes(Path.Combine(saveToDirecory, filepath), fileBuffer);
        }

        private static int GetSecretCode(ServiceClient client)
        {
            ResultOfint r = client.CreateSecretCode();
            if (!r.IsSuccess) throw new Exception("No Authorized");
            return r.Data;
        }



    }
}
