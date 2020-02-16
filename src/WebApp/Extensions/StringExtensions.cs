namespace WebApp.Extensions {
    public static class StringExtensions {
        public static string UnDash (this string value) {
            return (value ?? string.Empty).Replace ("-", string.Empty);
        }

    }

}