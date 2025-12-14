namespace OpdHospital.Models;

public class Files
{
    public long FileId { get; set; }
    public string OriginalFileName { get; set; }
    public string StoredFileName { get; set; }
    public string StorageProvider { get; set; }
    public string StoragePath { get; set; }
    public string ContentType { get; set; }
    public long FileSizeInBytes { get; set; }
    public DateTime CreatedOn { get; set; }
}
