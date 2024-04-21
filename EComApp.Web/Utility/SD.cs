namespace EComApp.Web.Utility
{
    public class SD
    {
        public static string CouponApi { get; set; }
        public static string AuthApi { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleEmployee = "Employee";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
