using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Utilities
{
    public static class FileUploader
    {
        public static async Task<long> UploadAsync(
            IFormFile file,
            IFileRepository fileRepository,
            string subFolder = "")
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");

            var storedFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string storagePath;

            if (AppSettings.FileStorageProvider == "S3")
            {
                storagePath = await UploadToS3Async(file, storedFileName, subFolder);
            }
            else
            {
                storagePath = await UploadToLocalAsync(file, storedFileName, subFolder);
            }

            var entity = new Files
            {
                OriginalFileName = file.FileName,
                StoredFileName = storedFileName,
                StorageProvider = AppSettings.FileStorageProvider.ToUpper(),
                StoragePath = storagePath,
                ContentType = file.ContentType,
                FileSizeInBytes = file.Length,
                CreatedOn = DateTime.UtcNow
            };

            // 🔑 Store in SQL and return FileId
            return await fileRepository.InsertAsync(entity);
        }

        // ---------- LOCAL ----------
        private static async Task<string> UploadToLocalAsync(
            IFormFile file,
            string storedFileName,
            string subFolder)
        {
            var folderPath = Path.Combine(AppSettings.LocalRootPath, subFolder);
            Directory.CreateDirectory(folderPath);

            var fullPath = Path.Combine(folderPath, storedFileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"{subFolder}/{storedFileName}".Replace("\\", "/");
        }

        // ---------- S3 ----------
        private static async Task<string> UploadToS3Async(
            IFormFile file,
            string storedFileName,
            string subFolder)
        {
            var fileKey = $"{subFolder}/{storedFileName}".TrimStart('/');

            var client = new AmazonS3Client(
                AppSettings.S3AccessKey,
                AppSettings.S3SecretKey,
                RegionEndpoint.GetBySystemName(AppSettings.S3Region));

            var transfer = new TransferUtility(client);

            await transfer.UploadAsync(file.OpenReadStream(), AppSettings.S3BucketName, fileKey);

            return fileKey; // store key only
        }
    }
}
