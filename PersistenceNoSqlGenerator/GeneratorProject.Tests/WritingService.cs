using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.IO;

namespace GeneratorProject.Tests
{
    public class WritingService : IWriting
    {
        public bool WriteFile(string path, string content)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                File.WriteAllText(path, content);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    if (!Directory.Exists(Directory.GetParent(newPath).FullName))
                        Directory.CreateDirectory(Directory.GetParent(newPath).FullName);
                    File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
