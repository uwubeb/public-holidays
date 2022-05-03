namespace public_holidays.Startup;

public static class AppConfiguration
{
    public static void ConfigureApp(this WebApplication app)
    {
       app.UseOpenApi();
       app.UseHttpsRedirection();
       app.UseAuthorization();
       app.MapControllers();
    }
}