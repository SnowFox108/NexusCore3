using System.IO;

namespace NexusCore.Infrasructure.FileIO
{
    public interface IDiskAccessProvider
    {
        byte[] ReadFile(string fileName);

        StreamReader ReadFileStream(string fileName);

        void SaveFile(string fileName, byte[] fileContent);

        bool DirectoryExists(string directory);

        void CreateDirectory(string directory);

        bool FileExists(string fileName);

        bool DeleteFile(string filename);

    }
}
