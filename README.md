# OOP Labs

Навчальний репозиторій з лабораторними роботами з ООП.

## Структура
- `csharp/` — лабораторні на C#.
- `typescript/` — лабораторні на TypeScript.

## C# лабораторні
- `Lab01/Task` — базові класи та моделі.
- `Lab02/Task` — розвиток моделі + пояснення в `CodeExplanation.md`.
- `Lab03/Task` — часткові класи, вкладені типи, робота зі студентами/викладачами.
- `Lab04/Task` — ієрархія тварин, інтерфейси, абстрактні класи, колекції.
  - Документація: [`csharp/Lab04/README.md`](csharp/Lab04/README.md)
- `Lab05/Task` — розширення Lab04: клас `Parrot`, оператори, індексатор.
  - Документація: [`csharp/Lab05/README.md`](csharp/Lab05/README.md)

## Запуск C# лабораторних
Вимоги:
- .NET SDK (у проєкті використано `net10.0`).

Приклад запуску (Lab05):
```bash
cd csharp/Lab05/Task
dotnet run
```

Аналогічно для інших лабораторних:
```bash
cd csharp/Lab04/Task
dotnet run
```

## TypeScript частина
Базова структура:
- `typescript/package.json`
- `typescript/lab01/task/index.ts`

Запуск:
```bash
cd typescript
npm install
npm run <script>
```

## Примітки
- Рішення згруповані по лабораторних для зручної перевірки.
- У `csharp/OOP_Labs.slnx` зібрані C# проєкти в єдине solution.
