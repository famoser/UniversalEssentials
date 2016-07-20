using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.UniversalWindows.Enums;

namespace Famoser.FrameworkEssentials.UniversalWindows.Platform
{
    public class FolderStorageService : StorageService, IFolderStorageService
    {
        protected async Task<List<string>> GetFiles(string subFolderPath, FolderType folderType)
        {
            var directory = GetFolder(folderType);
            if (!string.IsNullOrEmpty(subFolderPath) && subFolderPath != "/")
                directory = await directory.GetFolderAsync(subFolderPath);

            var files = await directory.GetFilesAsync();
            return files.Select(storageFile => storageFile.Name).ToList();
        }

        protected async Task<List<string>> GetDirectories(string subFolderPath, FolderType folderType)
        {
            var directory = GetFolder(folderType);
            if (!string.IsNullOrEmpty(subFolderPath) && subFolderPath != "/")
                directory = await directory.GetFolderAsync(subFolderPath);

            var folders = await directory.GetFoldersAsync();
            return folders.Select(storageFolder => storageFolder.Name).ToList();
        }

        protected async Task<bool> DeleteDirectory(string subFolderPath, FolderType folderType)
        {
            var directory = GetFolder(folderType);
            if (!string.IsNullOrEmpty(subFolderPath) && subFolderPath != "/")
                directory = await directory.GetFolderAsync(subFolderPath);

            await directory.DeleteAsync(StorageDeleteOption.Default);
            return true;
        }

        protected async Task<bool> Clear(FolderType folderType)
        {
            var directory = GetFolder(folderType);
            var files = await directory.GetFilesAsync();
            foreach (var storageFile in files)
                await storageFile.DeleteAsync();

            var folders = await directory.GetFoldersAsync();
            foreach (var storageFolder in folders)
                await storageFolder.DeleteAsync();
            return true;
        }

        public Task<List<string>> GetCachedFiles(string subFolderPath)
        {
            return Execute(() => GetFiles(subFolderPath, FolderType.CacheFolder));
        }

        public Task<List<string>> GetCachedDirectories(string subFolderPath)
        {
            return Execute(() => GetDirectories(subFolderPath, FolderType.CacheFolder));
        }

        public Task<bool> DeleteCachedDirectory(string subFolderPath)
        {
            return Execute(() => DeleteDirectory(subFolderPath, FolderType.CacheFolder));
        }

        public Task<bool> ClearCache()
        {
            return Execute(() => Clear(FolderType.CacheFolder));
        }

        public Task<List<string>> GetRoamingFiles(string subFolderPath)
        {
            return Execute(() => GetFiles(subFolderPath, FolderType.RoamingFolder));
        }

        public Task<List<string>> GetRoamingDirectories(string subFolderPath)
        {
            return Execute(() => GetDirectories(subFolderPath, FolderType.RoamingFolder));
        }

        public Task<bool> DeleteRoamingDirectory(string subFolderPath)
        {
            return Execute(() => DeleteDirectory(subFolderPath, FolderType.RoamingFolder));
        }

        public Task<bool> ClearRoaming()
        {
            return Execute(() => Clear(FolderType.RoamingFolder));
        }
    }
}
