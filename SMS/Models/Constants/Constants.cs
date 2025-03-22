namespace SMS.Models.Constants
{
    public abstract class Constants
    {
        public abstract class FontFamily
        {
            public const string Satoshi = "Satoshi";
            public const string Poppins = "Poppins";
            public const string Roboto = "Roboto";
            public const string Lato = "Lato";
            public const string Inter = "Inter";
        }

        public abstract class LocalStorage
        {
            public const string Jwt = "jwt";
            public const string Token = "token";
            public const string Preference = "preference";
            public const string Navigation = "return-url";
        }

        private abstract class FolderPath
        {
            public const string Images = "images";
            public const string Resources = "resources";
        }

        public abstract class FilePath
        {
            public const string UsersImagesFilePath = $"{FolderPath.Images}/user-images";
            public const string ResourcesFilePath = $"{FolderPath.Resources}";
        }

        public abstract class Provider
        {
            public const string Wasm = "WASM";
        }

        public abstract class Encryption
        {
            public const string Key = "@mosh";
        }

        public abstract class Message
        {
            public const string ExceptionMessage = "An exception occured while handling your request, please try again.";
            public const string FileSizeUploadMessage = "Please upload a valid file of less than 5 MB.";
            public const string ImageUploadMessage = "Please upload a valid image file with the following extensions (.jpg, .jpeg, .png) only.";
            public const string ResourceUploadMessage = "Please upload a resource material file with the following extensions (.jpg, .jpeg, .png, .pdf) only.";
        }


    }
}
