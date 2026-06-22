using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using Renci.SshNet;
using System.Text.RegularExpressions;
using Amazon.S3;
using Amazon.S3.Model;

namespace EasyPCIBackend.Services
{
    public class SSHConnector : ISSHConnector
    {
        private readonly IConfiguration _configuration;

        public SSHConnector(IConfiguration configuration)
        {
              _configuration = configuration;
        }
        public string GetCore(SSHConnection connection, string process)
        {
            string wantedPID = "";
            using (var client = new SshClient(connection.ServerAddress, connection.Username, connection.Password))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    var pidCommand = client.CreateCommand("ps aux | grep ./" + process);
                    var result = pidCommand.Execute();
                    string[] results = result.Split('\n');
                    foreach (var output in results)
                    {
                        Regex regex = new Regex(@"(\d+):\d\d \./([a-zA-Z0-9_-]+(?:\.exe)?)$");
                        Match match = regex.Match(output);

                        Regex whitespaces = new Regex(@"\s+");
                        var processedString = output;
                        processedString = whitespaces.Replace(output, " ");
                        if (match.Success && output.EndsWith(" ./" + process))
                        {
                            string[] words = processedString.Split(' ');
                            wantedPID = words[1];
                            break;
                        }
                    }
                    var cmd = client.CreateCommand("gcore " + wantedPID);
                    result = cmd.Execute();
                
                    client.Disconnect();
                }
            }
            return wantedPID;
        }

        public async Task<string> UploadCore(SSHConnection connection, string wantedPID)
        {
            string result_string = "";
            using (var client = new SftpClient(connection.ServerAddress, connection.Username, connection.Password))
            {
                client.Connect();

                using (var memoryStream = new MemoryStream())
                {
                    client.DownloadFile("/home/" + connection.Username + "/core." + wantedPID, memoryStream);

                    var s3Client = new AmazonS3Client(
                        _configuration.GetValue<string>("R2:AccessKey"),
                        _configuration.GetValue<string>("R2:SecretKey"),
                        new AmazonS3Config
                        {
                            ServiceURL = _configuration.GetValue<string>("R2:Endpoint"),
                            ForcePathStyle = true
                        });

                    string blobName = $"core.{wantedPID}-{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}";
                    memoryStream.Position = 0;

                    var putRequest = new PutObjectRequest
                    {
                        BucketName = "easypci-coredumps",
                        Key = blobName,
                        InputStream = memoryStream,
                        ContentType = "application/octet-stream"
                    };

                    await s3Client.PutObjectAsync(putRequest);

                    result_string = blobName;

                    client.DeleteFile("/home/" + connection.Username + "/core." + wantedPID);
                }

                client.Disconnect();
            }

            return result_string;
        }
    }
}
