# Versta Delivery

Простое ASP.NET Core MVC приложение для приемки заказов на доставку.

## Стек

- ASP.NET Core 9 MVC
- Entity Framework Core
- PostgreSQL


## Запуск

1. Поднять PostgreSQL:

   ```bash
   docker compose up -d
   ```

2. Применить миграции:

   ```bash
   dotnet tool restore
   dotnet tool run dotnet-ef database update \
     --project Infrastructure \
     --startup-project Presentation
   ```

3. Запустить приложение:

   ```bash
   dotnet run Presentation/Presentation.csproj
   ```

Строка подключения по умолчанию находится в `Presentation/appsettings.json`.
