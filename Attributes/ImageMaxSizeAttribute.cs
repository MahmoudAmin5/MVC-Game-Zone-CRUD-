namespace MVC_CRUD.Attributes
{
    public class ImageMaxSizeAttribute: ValidationAttribute
    {
        private readonly int _maxsize;
        public ImageMaxSizeAttribute(int maxsize)
        {
            _maxsize = maxsize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var File = value as IFormFile;

            if (File is not null)
            {
                if(File.Length > _maxsize)
                {
                    return new ValidationResult($"Max Allowed size is {_maxsize} bytes ");
                }
            }
            return ValidationResult.Success;
        }
    }
}
