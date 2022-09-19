using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Upload(IFormFile file, string root) 
        {
            if (file != null && file.Length > 0) 
            {
                if (!Directory.Exists(root)) 
                {
                    Directory.CreateDirectory(root); 
                }
                string extension = Path.GetExtension(file.FileName); 
                string randomFileName = Guid.NewGuid().ToString(); 
                string filePath = randomFileName + extension; 
                using (FileStream fileStream = File.Create(root + filePath)) 
                {

                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
            }
            return Upload(file, root);
        }
    }
}
