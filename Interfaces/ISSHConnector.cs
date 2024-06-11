﻿using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces
{
    public interface ISSHConnector
    {
        public String GetCore(SSHConnection connection, string process);
        public Task UploadCore(SSHConnection connectiion, string wantedPID);
    }
}
