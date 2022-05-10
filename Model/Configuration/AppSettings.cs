namespace Supplier.API.Configuration
{
    public class AppSettings
    {
        public string JWTKey { get; set; } = null!;
        public int TokenExpires { get; set; }
    }

    public class UIAppSettings
    {
        public string APIURL { get; set; }
    }
}
