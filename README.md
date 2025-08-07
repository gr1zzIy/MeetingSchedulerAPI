# MeetingSchedulerAPI
Simple backend service to schedule meetings for multiple users without conflicts.

## English

### Setup Instructions

1. Install [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
2. Clone the repository:
   
   git clone https://github.com/gr1zzIy/MeetingSchedulerAPI
   
   cd TestDotnet
4. dotnet restore
5. dotnet build
6. dotnet run --project TestDotnet
7. dotnet test

### API Endpoints

<img width="478" height="480" alt="image" src="https://github.com/user-attachments/assets/d3b3f10a-ce63-4f36-afa5-2ec7f89d16a6" />

### Edge Cases
1. In-memory storage only; data resets on app restart
2. UTC timezone only, no local timezone support
3. Fixed business hours 9:00–17:00, no per-user customization
4. No recurring meetings support
5. No authentication or authorization implemented
6. No concurrency control; simultaneous requests may cause scheduling conflicts

## Українською

### Інструкції зі встановлення

1. Встановіть [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
2. Клонуйте репозиторій:
   
   git clone https://github.com/gr1zzIy/MeetingSchedulerAPI
   
   cd TestDotnet
4. Відновіть залежності:
  dotnet restore
5. Збірка проєкту:
   dotnet build
6. Запуск API:
   dotnet run --project TestDotnet
7. dotnet test

### API Ендпоінти
<img width="478" height="480" alt="image" src="https://github.com/user-attachments/assets/a0bafb7a-9260-49cb-806b-84a1ece96911" />


### Обмеження та неохоплені кейси
1. Дані зберігаються в пам’яті, без бази даних, тому всі дані зникають після перезапуску
2. Підтримка тільки UTC, без локальних часових поясів
3. Фіксовані робочі години 9:00–17:00, без персоналізації
4. Не підтримуються повторювані зустрічі
5. Відсутня автентифікація та авторизація
6. Відсутнє блокування при одночасних запитах — можливі колізії при плануванні

