namespace MVC_CRUD.Attributes
{
    public class AllowedExtensionsAttribute:ValidationAttribute
    {
        private readonly string _allowedExtensions;
        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var File = value as IFormFile;

            if (File is not null) 
            {
                var Extinsion = Path.GetExtension(File.FileName);

                var IsAllowed=_allowedExtensions.Split(",").
                    Contains(Extinsion, StringComparer.OrdinalIgnoreCase);

                if (!IsAllowed)
                { 
                  return new ValidationResult($"Only {_allowedExtensions} are allowed");
                }
            }
            return ValidationResult.Success;
        }
    }
}
