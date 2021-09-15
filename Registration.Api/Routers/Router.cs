namespace Registration.Api.Routers
{
    public static class Router
    {
        private const string Base = "api/";
        private const string Version = "v1/";
        private const string Root = Base + Version;


        public static class Customer
        {
            private const string Prefix = Root + "customer/";
            public const string Create = Prefix + "create";
            public const string Delete = Prefix + "delete";
            public const string Update = Prefix + "update";
            public const string Upload = Prefix + "upload";
            public const string ChangeActivity = Prefix + "change-activity";
            public const string GetAll = Prefix + "get-all";
            public const string GetById = Prefix + "get-by-id";
            public const string GetAllActive = Prefix + "get-all-active";
            public const string Details = Prefix + "details";
        }

        public  static class Address
        {
            private const string Prefix = Root + "address/";
            public const string Create = Prefix + "create";
            public const string Delete = Prefix + "delete";
            public const string Update = Prefix + "update";
            public const string IsDefault = Prefix + "is-default";
            public const string GetAll = Prefix + "get-all";
            public const string GetById = Prefix + "get-by-id";
        }

    }
}
