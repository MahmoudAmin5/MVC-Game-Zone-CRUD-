namespace MVC_CRUD.Settings
{
    public static class FileSettings
    {
        public const string ImagePath= "/assets/Images/Games";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeMB = 1;
        public const int MaxFileSizeByte = MaxFileSizeMB * 1024 * 1024;

    }
}
