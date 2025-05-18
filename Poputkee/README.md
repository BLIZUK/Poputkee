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
