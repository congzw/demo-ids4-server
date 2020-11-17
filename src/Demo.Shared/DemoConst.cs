namespace Demo.Shared
{
    public class DemoConst
    {
        //scopes
        public static string ApiScope1 = "ApiScope1";
        public static string ApiScope2 = "ApiScope2";

        //client ids
        public static string DemoClient = "DemoClient";
        public static string DemoApi = "DemoApi";
        public static string DemoMvc = "DemoMvc";

        //client secret
        public static string Secret = "secret";

        //client uris
        public static string IdentityServerUri = "https://localhost:44320";

        public static string DemoApiUri_GetUser = "https://localhost:44321/Api/Foo/GetUser";
        public static string DemoApiUri_LoginRedirect = "https://localhost:44321/signin-oidc";
        public static string DemoApiUri_LogoutRedirect = "https://localhost:44321/signout-callback-oidc";
        
        public static string DemoMvcUri_LoginRedirect = "https://localhost:44322/signin-oidc";
        public static string DemoMvcUri_LogoutRedirect = "https://localhost:44322/signout-callback-oidc";
    }
}
