using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Services.Base;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.UniversalWindows.Enums;

namespace Famoser.FrameworkEssentials.UniversalWindows.Platform
{
    public class StorageService : BaseService, IStorageService
    {
        public StorageService(bool catchExceptions = true, IExceptionLogger logger = null) : base(catchExceptions, logger) { }

        public Task<string> GetCachedTextFileAsync(string filePath)
        {
            return Execute(() => GetTextFileAsync(filePath, FolderType.CacheFolder));
        }

        public Task<bool> SetCachedTextFileAsync(string filePath, string content)
        {
            return Execute(() => SaveTextFileAsync(filePath, content, FolderType.CacheFolder));
        }

        public Task<byte[]> GetCachedFileAsync(string filePath)
        {
            return Execute(() => GetFileAsync(filePath, FolderType.CacheFolder));
        }

        public Task<bool> SetCachedFileAsync(string filePath, byte[] content)
        {
            return Execute(() => SaveFileAsync(filePath, content, FolderType.CacheFolder));
        }

        public Task<bool> DeleteCachedFileAsync(string filePath)
        {
            return Execute(() => DeleteFileAsync(filePath, FolderType.CacheFolder));
        }

        public Task<string> GetRoamingTextFileAsync(string filePath)
        {
            return Execute(() => GetTextFileAsync(filePath, FolderType.RoamingFolder));
        }

        public Task<bool> SetRoamingTextFileAsync(string filePath, string content)
        {
            return Execute(() => SaveTextFileAsync(filePath, content, FolderType.RoamingFolder));
        }

        public Task<byte[]> GetRoamingFileAsync(string filePath)
        {
            return Execute(() => GetFileAsync(filePath, FolderType.RoamingFolder));
        }

        public Task<bool> SetRoamingFileAsync(string filePath, byte[] content)
        {
            return Execute(() => SaveFileAsync(filePath, content, FolderType.RoamingFolder));
        }

        public Task<bool> DeleteRoamingFileAsync(string filePath)
        {
            return Execute(() => DeleteFileAsync(filePath, FolderType.RoamingFolder));
        }

        public Task<string> GetAssetTextFileAsync(string path)
        {
            return Execute(() => GetTextFileAsync(path, FolderType.AssetFolder));
        }

        public Task<byte[]> GetAssetFileAsync(string path)
        {
            return Execute(() => GetFileAsync(path, FolderType.AssetFolder));
        }

        protected StorageFolder GetFolder(FolderType folderType)
        {
            switch (folderType)
            {
                case FolderType.CacheFolder:
                    return ApplicationData.Current.LocalCacheFolder;
                case FolderType.RoamingFolder:
                    return ApplicationData.Current.RoamingFolder;
                default:
                    return null;
            }
        }

        private async Task<StorageFile> GetStorageFileAsync(string filePath, FolderType folderType)
        {
            if (folderType == FolderType.AssetFolder)
                return await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///" + filePath));
            var file = await GetFolder(folderType).TryGetItemAsync(filePath);
            if (file != null)
                return await GetFolder(folderType).GetFileAsync(filePath);
            return await GetFolder(folderType).CreateFileAsync(filePath);
        }

        protected async Task<bool> DeleteFileAsync(string filePath, FolderType folderType)
        {
            var storageFile = await GetStorageFileAsync(filePath, folderType);
            await storageFile.DeleteAsync(StorageDeleteOption.Default);
            return true;
        }

        protected async Task<byte[]> GetFileAsync(string filePath, FolderType folderType)
        {
            var storageFile = await GetStorageFileAsync(filePath, folderType);
            var str = await FileIO.ReadBufferAsync(storageFile);
            if (str.Length > 0)
                return str.ToArray();
            return new byte[0];
        }

        protected async Task<string> GetTextFileAsync(string filePath, FolderType folderType)
        {
            var storageFile = await GetStorageFileAsync(filePath, folderType);
            return await FileIO.ReadTextAsync(storageFile);
        }

        protected async Task<bool> SaveFileAsync(string filePath, byte[] content, FolderType folderType)
        {
            var storageFile = await GetStorageFileAsync(filePath, folderType);
            await FileIO.WriteBytesAsync(storageFile, content);
            return true;
        }

        protected async Task<bool> SaveTextFileAsync(string filename, string content, FolderType folderType)
        {
            var storageFile = await GetStorageFileAsync(filename, folderType);
            await FileIO.WriteTextAsync(storageFile, content);
            return true;
        }
    }
}
