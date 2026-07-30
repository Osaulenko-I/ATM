# ATM

Бэкенд ATM-системы на ASP.NET Core (.NET 9): работа с пользовательскими и админ-сессиями, счетами и транзакциями

## Стек

- .NET 9, ASP.NET Core Web API
- Swagger / Swashbuckle (OpenAPI)
- Слоистая архитектура

## Архитектура

Решение разбито на проекты по слоям:

- **Core** — доменные модели (`Account`, `BankTransaction`, value objects: `Amount`, `AccountID`, `TransactionId`)
- **Abstractions** — интерфейсы для доступа к данным (`IPersistenceContext`)
- **Contractions** — контракты сервисов (`IAdminSessionService`, `IUserSessionService`) и их DTO/операции
- **Applications** — реализация бизнес-логики (`AdminSessionService`, `UserSessionService`), мапперы
- **Repositories** — in-memory реализация репозиториев и `PersistenceContextInMemory`
- **Http** — REST-контроллеры (`AdminSessionController`, `UserSessionController`)
- **ATM** — точка входа (`Program.cs`), сборка DI-контейнера, запуск приложения

## Основные возможности

- Сессия администратора: создание счёта, вход по паролю (`/api/admin/session`)
- Сессия пользователя: вход по номеру счёта и PIN, снятие, пополнение, просмотр баланса и истории транзакций (`/api/user/session`)

## Запуск

```bash
cd ATM
dotnet run
```

Приложение поднимется на порту, указанном в `Properties/launchSettings.json`; Swagger UI доступен по адресу `/swagger`.

## Требования

- .NET 9 SDK
