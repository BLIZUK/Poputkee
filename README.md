# Poputkee
Приложение по поиску попутчиков и водителей в дорогу.

## 🔹Цель работы

 1. Создание продукта для курсовой работы 2 курса 2 семестра университета СФ МЭИ Кафедры ВТ. 
 2. Более глубокое знакомство с архитектурой MVVM, с базами данных, а именно - PostgreSQL, оттачивания навыков работы с языком программирования C#.
 3. Цель проектирования: 
    - "Разработка программы поиска попутчиков в дороге."
 4. Технические требования:
    - Создание возможности выбора типа поездки (за рулем или в качестве пассажира).
    - Добавить базу данных для пользователей.
    - Реализовать оценку пользователей.


## 🔹Стек технологий

1. Язык: C# (.NET 6/7/8).

2. База данных: PostgreSQL (востребованная, открытая, поддерживает сложные запросы).

3. ORM: Entity Framework Core (для работы с БД).

4. Архитектура:
    - MVVM (Model-View-ViewModel) + Dependency Injection.
    - Repository Pattern + Unit of Work.
    - MediatR (опционально, для CQRS).

5. Фреймворк для UI: WPF (с привязкой данных, стилями, ControlTemplate).

6. Дополнительно:
    - AutoMapper (для маппинга DTO).
    - FluentValidation (валидация данных).
    - Serilog (логгирование).

## 🔹Пример работы продукта


## 🔹Особенности установки и сборки

1. Установка Nuget-пакетов:
    - Install-Package Microsoft.EntityFrameworkCore
    - Install-Package Microsoft.EntityFrameworkCore.Design
    - Install-Package Microsoft.EntityFrameworkCore.Tools
    - Install-Package Npgsql.EntityFrameworkCore.PostgreSQL

### Структурное дерево проекта
```
Poputkee/  
├── Core/                      # Ядро приложения
│   ├── Models/                         # Сущности БД
│   │   ├── User.cs                     # Пользователь
│   │   ├── Trip.cs                     # Поездка
│   │   └── Booking.cs                  # Бронирование
│   │
│   ├── Interfaces/                     # Интерфейсы
│   │   ├── IRepository.cs              # Общий репозиторий
│   │   └── IUnitOfWork.cs              # Unit of Work
│   │
│   └── Services/                       # Бизнес-логика
│       └── TripService.cs              # Сервис для работы с поездками
│
├──Infrastructure/            # Работа с данными
│   ├── Data/
│   │   ├── AppDbContext.cs             # Контекст БД
│   │   └── DatabaseInitializer.cs      # Инициализатор БД (опционально)
│   │
│   └── Repositories/                   # Реализации репозиториев
│       ├── Repository.cs               # Базовый репозиторий
│       ├── TripRepository.cs           # Репозиторий поездок
│       └── UserRepository.cs           # Репозиторий пользователей
│
├──Desktop/                   # WPF-приложение
│   ├── Views/
│   │   ├── MainWindow.xaml             # Главное окно
│   │   ├── TripListView.xaml           # Список поездок (UserControl)
│   │   └── CreateTripView.xaml         # Форма создания поездки
│   │
│   ├── ViewModels/
│   │   ├── MainViewModel.cs            # VM для MainWindow
│   │   ├── TripListViewModel.cs        # VM для списка поездок
│   │   └── CreateTripViewModel.cs      # VM для формы создания
│   │
│   ├── Converters/                     # Конвертеры для привязок
│   │   └── DateTimeToStringConverter.cs
│   │
│   └── App.xaml                        # Точка входа + DI
│
├──Tests/                     # Тесты (опционально)
│   ├── UnitTests/
│   │   └── TripServiceTests.cs
│   └── IntegrationTests/
│       └── RepositoryTests.cs
│
└── Poputkee.sln                        # Файл решения Visual Studio
```

## 🔹Ход работы:
1. Начало разработки - 04.05.2025 .
