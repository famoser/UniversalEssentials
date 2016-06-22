using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Services.Base;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.UniversalWindows.Platform
{
    public class StorageService : BaseService, IStorageService
    {
        public StorageService(bool catchExceptions = true, IExceptionLogger logger = null) : base(catchExceptions, logger) { }

        protected async Task<string> ReadAssetTextFileAsync(string path)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///" + path));
            if (file != null)
                return await FileIO.ReadTextAsync(file);
            return null;
        }

        protected async Task<string> ReadLocalTextFileAsync(string filename)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            if (localFile != null)
                return await FileIO.ReadTextAsync(localFile);
            return null;
        }

        protected async Task<string> ReadRoamingTextFileAsync(string filename)
        {
            StorageFile localFile = await ApplicationData.Current.RoamingFolder.GetFileAsync(filename);
            if (localFile != null)
                return await FileIO.ReadTextAsync(localFile);
            return null;
        }

        protected async Task<bool> SaveLocalTextFileAsync(string filename, string content)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            if (localFile != null)
            {
                await FileIO.WriteTextAsync(localFile, content);
                return true;
            }
            return false;
        }

        protected async Task<bool> SaveRoamingTextFileAsync(string filename, string content)
        {
            StorageFile localFile = await ApplicationData.Current.RoamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            if (localFile != null)
            {
                await FileIO.WriteTextAsync(localFile, content);
                return true;
            }
            return false;
        }

        protected async Task<byte[]> ReadAssetFileAsync(string path)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///" + path));
            if (file != null)
            {
                var str = await FileIO.ReadBufferAsync(file);
                return str.ToArray();
            }
            return null;
        }

        protected async Task<byte[]> ReadLocalFileAsync(string filename)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            if (localFile != null)
            {
                var str = await FileIO.ReadBufferAsync(localFile);
                return str.ToArray();
            }
            return null;
        }

        protected async Task<byte[]> ReadRoamingFileAsync(string filename)
        {
            StorageFile localFile = await ApplicationData.Current.RoamingFolder.GetFileAsync(filename);
            if (localFile != null)
            {
                var res = await FileIO.ReadBufferAsync(localFile);
                return res.ToArray();
            }
            return null;
        }

        protected async Task<bool> SaveLocalFileAsync(string filename, byte[] content)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            if (localFile != null)
            {
                await FileIO.WriteBytesAsync(localFile, content);
                return true;
            }
            return false;
        }

        protected async Task<bool> SaveRoamingFileAsync(string filename, byte[] content)
        {
            StorageFile localFile = await ApplicationData.Current.RoamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            if (localFile != null)
            {
                await FileIO.WriteBytesAsync(localFile, content);
                return true;
            }
            return false;
        }

        public Task<string> GetCachedTextFileAsync(string fileKey)
        {
            return Execute(() => ReadLocalTextFileAsync(fileKey));
        }

        public Task<bool> SetCachedTextFileAsync(string fileKey, string content)
        {
            return Execute(() => SaveLocalTextFileAsync(fileKey, content));
        }

        public Task<byte[]> GetCachedFileAsync(string fileKey)
        {
            return Execute(() => ReadLocalFileAsync(fileKey));
        }

        public Task<bool> SetCachedFileAsync(string fileKey, byte[] content)
        {
            return Execute(() => SaveLocalFileAsync(fileKey, content));
        }

        public Task<string> GetUserTextFileAsync(string fileKey)
        {
            return Execute(() => ReadRoamingTextFileAsync(fileKey));
        }

        public Task<bool> SetUserTextFileAsync(string fileKey, string content)
        {
            return Execute(() => SaveRoamingTextFileAsync(fileKey, content));
        }

        public Task<byte[]> GetUserFileAsync(string fileKey)
        {
            return Execute(() => ReadRoamingFileAsync(fileKey));
        }

        public Task<bool> SetUserFileAsync(string fileKey, byte[] content)
        {
            return Execute(() => SaveRoamingFileAsync(fileKey, content));
        }

        public Task<string> GetAssetTextFileAsync(string path)
        {
            return Execute(() => ReadAssetTextFileAsync(path));
        }

        public Task<byte[]> GetAssetFileAsync(string path)
        {
            return Execute(() => ReadAssetFileAsync(path));
        }
    }
}
