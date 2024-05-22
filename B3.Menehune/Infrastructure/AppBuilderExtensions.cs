namespace B3.Menehune.Infrastructure
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseMenehune(this IApplicationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            
            builder.UseMiddleware<MenehuneMiddleware>();
            return builder;
        }
    }
}
