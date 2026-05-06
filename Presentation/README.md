# Versta Delivery

Простое ASP.NET Core MVC приложение для приемки заказов на доставку.

## Стек

- ASP.NET Core 9 MVC
- Entity Framework Core
- PostgreSQL

## Архитектура

Проект разложен по слоям в стиле примера `lab-3`: в solution есть solution folders по слоям, внутри каждого слоя лежит одноименный проект.

- `Presentation/Presentation.csproj` - ASP.NET MVC frontend: контроллеры, Razor Views, ViewModels, статика.
- `Application/Application.csproj` - бизнес-сценарии, сервисы и application-абстракции.
- `Domain/Domain.csproj` - сущности предметной области.
- `Infrastructure/Infrastructure.csproj` - EF Core, PostgreSQL, миграции и реализации репозиториев.

Основной поток создания заказа:

```text
OrdersController -> IOrderService -> IOrderRepository -> AppDbContext -> PostgreSQL
```

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
