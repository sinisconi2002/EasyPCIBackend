using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using Microsoft.Extensions.Hosting;
using Renci.SshNet;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
                try
                {
                    client.Connect();

                    if (client.IsConnected)
                    {
                        Console.WriteLine("Connected successfully.");
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
                    }
                    else
                    {
                        Console.WriteLine("Could not connect to the server.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
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

                    var container = new BlobContainerClient(_configuration.GetValue<string>("ConnectionStrings:AzureStorage"), "coredumps");
                    var blob = container.GetBlobClient("core." + wantedPID);

                    memoryStream.Position = 0;
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    await blob.UploadAsync(memoryStream);
                    result_string = blob.Uri.ToString();
                }
            }
            return result_string;
        }
    }
}
