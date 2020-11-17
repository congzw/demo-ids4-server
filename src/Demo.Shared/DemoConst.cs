namespace Demo.Shared
{
    public class DemoConst
    {
        public static string DemoApi_Scope1 = "Scope1";
        public static string DemoApi_Scope1Title = "Scope1...";

        public static string DemoApi_Scope2 = "Scope2";
        public static string DemoApi_Scope2Title = "Scope2...";

        public static string DemoClient_Id = "Client1";
        public static string DemoClient_Secret = "1234";
        
        public static string IdentityServer_Uri = "https://localhost:44320";
        public static string DemoApi_Uri_GetUser = "https://localhost:44321/Api/Foo/GetUser";
        public static string DemoMvcClient_RedirectUri = "https://localhost:44322/signin-oidc";
        public static string DemoMvcClient_PostLogoutRedirectUri = "https://localhost:44322//signout-callback-oidc";

        public static string DemoMvcClient_Id = "Client2";
        public static string DemoMvcClient_Secret = "1234";
    }

}
