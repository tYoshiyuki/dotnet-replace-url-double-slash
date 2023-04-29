# dotnet-replace-url-double-slash
ASP.NET Core の WebAPI で URL にダブルスラッシュ (//) が含まれていてもルーティングするサンプル

## Feature
- .NET6
- ASP.NET Core

## Note
- ASP.NET Core の WebAPI で URL にダブルスラッシュ (//) が含まれていてもルーティングするサンプルです。
- ミドルウェアにて、URLパスのダブルスラッシュ (//) をスラッシュ (/) に置換するだけの簡易実装となっています。
    - 尚、ASP.NET Web API2 の場合、URLにダブルスラッシュが含まれていても、正しくルーティングされます。

```cs
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
```
