using System;
using System.IO;
using System.Threading.Tasks;
using Camelotia.Services.Interfaces;

namespace Blank.Services
{
    public sealed class AppleFileManager : IFileManager
    {
        public Task<(string Name, Stream Stream)> OpenRead()
        {
            throw new NotImplementedException();
        }

        public Task<Stream> OpenWrite(string name)
        {
            throw new NotImplementedException();
        }
    }
}