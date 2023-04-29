namespace DotNetReplaceUrlDoubleSlash.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // NOTE URLに重複スラッシュが存在する場合、単一スラッシュへ置換する
            app.Use((context, next) =>
            {
                if (context.Request.Path.Value != null)
                {
                    context.Request.Path = new PathString(context.Request.Path.Value.Replace("//", "/"));
                }
                return next(context);
            });

            // NOTE URLの置換えに対応したコントローラ選定が実施されるように、意図的に呼出し
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
