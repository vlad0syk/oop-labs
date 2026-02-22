# Пояснення коду (Лабораторна робота №2)

Нижче наведено детальний розбір кожної структури та рядка коду з файлу `Program.cs`.

## Основна структура та підключення просторів імен
```csharp
using System; // Підключає базовий простір імен для доступу до класів Console, Math, Array тощо
using System.Collections.Generic; // Підключає простір імен для використання узагальнених колекцій і інтерфейсу IComparer

namespace Task; // Оголошує простір імен `Task`, щоб логічно згрупувати код проєкту

public class Program // Оголошує публічний клас `Program`, який є точкою входу для консольного застосунку
{
    static int[] generatedArray; // Статичне поле класу для зберігання згенерованого одновимірного масиву (щоб він був доступний у різних методах завдань)
    static int[,] matrix; // Статичне поле для зберігання двовимірного масиву (матриці)
    static Random rand = new Random(); // Створює об'єкт класу Random для генерації випадкових чисел протягом роботи програми
```

## Метод Main (Точка входу) та Меню
```csharp
    static void Main(string[] args) // Головний метод, з якого починається виконання програми
    {
        while (true) // Безкінечний цикл для постійного відображення меню, поки користувач не вибере "0" для виходу
        {
            Console.Clear(); // Очищення екрану консолі перед виведенням нового меню
            Greeting(); // Виклик допоміжного методу для виведення інформації про автора
            Console.WriteLine("1. Array generation and Quick Sort (descending)"); // Виведення 1-го пункту меню на екран
            Console.WriteLine("2. Find primes in array (Sieve of Eratosthenes)"); // Виведення 2-го пункту
            Console.WriteLine("3. Count repetitions using linear search"); // Виведення 3-го пункту
            Console.WriteLine("4. Find min and max in array using linear search"); // Виведення 4-го пункту
            Console.WriteLine("5. Binary search in array"); // Виведення 5-го пункту
            Console.WriteLine("6. Matrix generation and sum of row/col"); // Виведення 6-го пункту
            Console.WriteLine("7. Find min and max in matrix using Math methods"); // Виведення 7-го пункту
            Console.WriteLine("8. Roots of nonlinear equation (Bisection method)"); // Виведення 8-го пункту
            Console.WriteLine("9. String operations (find, replace, insert, delete)"); // Виведення 9-го пункту
            Console.WriteLine("0. Exit"); // Виведення пункту для виходу
            Console.WriteLine(); // Порожній рядок для візуального розділення відступом
            Console.Write("Choose a task (0-9): "); // Запит користувачу обрати пункт меню (без переходу на новий рядок)

            string choice = Console.ReadLine(); // Читання вибору користувача з клавіатури, як текстового рядка

            switch (choice) // Оператор вибору (switch) для обробки введеного символу вибору
            {
                case "1": Task1(); break; // Якщо введено "1", викликається метод Task1. Команда break перериває switch
                case "2": Task2(); break; // Виклик 2-го завдання
                case "3": Task3(); break; // Виклик 3-го завдання
                case "4": Task4(); break; // Виклик 4-го завдання
                case "5": Task5(); break; // Виклик 5-го завдання
                case "6": Task6(); break; // Виклик 6-го завдання
                case "7": Task7(); break; // Виклик 7-го завдання
                case "8": Task8(); break; // Виклик 8-го завдання
                case "9": Task9(); break; // Виклик 9-го завдання
                case "0": Console.WriteLine("Goodbye!"); return; // Якщо "0" - виведення повідомлення прощання і завершення методу Main за допомогою return (вихід з програми)
                default: Console.WriteLine("Invalid choice!"); break; // Обробка некоректного вводу (якщо користувач ввів не 0-9)
            }

            Console.WriteLine("\nPress any key to continue..."); // Повідомлення про паузу перед поверненням в меню
            Console.ReadKey(); // Очікування натискання будь-якої клавіші користувачем для продовження
        }
    }
```

## Допоміжний метод Greeting
```csharp
    static void Greeting() // Метод для виведення інформації про лабораторну та студента
    {
        Console.WriteLine("==========================================="); // Виведення декоративної лінії з символів
        Console.WriteLine("     📘 Laboratory Work No. 2"); // Назва роботи
        Console.WriteLine("==========================================="); 
        Console.WriteLine("💻 Performed by: Vlad Sapozhnyk (8)"); // Інформація про виконавця
        Console.WriteLine("🎓 Taras Shevchenko National University of Kyiv"); // Назва Університету
        Console.WriteLine("🏫 Group: IPZ-13, Subgroup: 6"); // Номер групи
        Console.WriteLine("===========================================");
    }
```

## Завдання 1: Масиви та Швидке сортування
```csharp
    static void Task1() // Метод виконання першого завдання
    {
        Console.Clear(); // Очищення консолі
        Console.WriteLine("=== Task 1: Array Generation and Quick Sort (Descending) ===\n"); // Заголовок завдання
        int n = ReadInt("Enter number of elements (N): ", 1, 100000); // Безпечне зчитування розміру масиву з перевіркою (через власну функцію)
        generatedArray = new int[n]; // Ініціалізація глобального масиву на n елементів
        for (int i = 0; i < n; i++) // Цикл від 0 до n-1 для заповнення масиву
        {
            generatedArray[i] = rand.Next(-100, 101); // Присвоєння кожному елементу випадкового числа від -100 до 100 включно
        }
        Console.WriteLine("\nArray before sorting:"); // Виведення тексту
        PrintArray(generatedArray); // Виклик допоміжного методу для друку елементів масиву

        QuickSortDescending(generatedArray, 0, n - 1); // Виклик власної функції швидкого сортування (передаємо масив, початковий та кінцевий індекси)

        Console.WriteLine("\nArray after sorting (Descending):"); // Повідомлення після сортування
        PrintArray(generatedArray); // Виведення відсортованого масиву
    }
```

## Завдання 2: Прості числа (Решето Ератосфена)
```csharp
    static void Task2() // Метод другого завдання
    {
        Console.Clear(); // Очищаємо екран
        Console.WriteLine("=== Task 2: Find primes in array (Sieve of Eratosthenes) ===\n");
        if (generatedArray == null) { Console.WriteLine("Please generate array in Task 1 first."); return; } // Перевірка, чи згенерований масив у завданні 1. Якщо ні - виводимо повідомлення і виходимо

        int a = ReadInt("Enter range start (A): "); // Зчитування початку заданого діапазону
        int b = ReadInt("Enter range end (B): "); // Зчитування кінця заданого діапазону
        
        if (a > b) { int temp = a; a = b; b = temp; } // Якщо діапазон введено задом наперед (A > B), міняємо їх місцями (swapping)

        int maxVal = b; // Беремо верхню межу діапазону як можливий максимум для пошуку простих чисел
        foreach (int val in generatedArray) // Проходимося по масиву, щоб знайти найбільше число (щоб не виділяти пам'ять даремно)
        {
            if (val > maxVal) maxVal = val; // Якщо елемент більший за maxVal, оновлюємо maxVal
        }

        if (maxVal < 2) // Простих чисел менше 2 не буває (найменше - 2)
        {
             Console.WriteLine("No prime numbers possible in this range/array."); return; // Виводимо повідомлення і повертаємося
        }

        bool[] isPrime = new bool[maxVal + 1]; // Створення булевого масиву для алгоритму "Решето Ератосфена"
        for (int i = 2; i <= maxVal; i++) isPrime[i] = true; // Спочатку припускаємо, що всі числа (починаючи з 2) - прості

        for (int p = 2; p * p <= maxVal; p++) // Перевіряємо числа від 2 до квадратного кореня з maxVal
        {
            if (isPrime[p]) // Якщо поточне p - є простим в нашому масиві...
            {
                for (int i = p * p; i <= maxVal; i += p) // ...то викреслюємо всі числа, які кратні p, починаючи з p^2 (тобто p*p, p*p+p і тд)
                    isPrime[i] = false; // Позначаємо їх як складені числа (не прості)
            }
        }

        Console.WriteLine($"\nPrime numbers from the array that fall in the range [{a}, {b}]:");
        bool foundAny = false; // Прапорець для перевірки, чи знайшлось хоч одне просте число в нашому масиві
        foreach (int val in generatedArray) // Проходимося по збереженому масиву
        {
            if (val >= a && val <= b && val >= 2 && isPrime[val]) // Якщо число входить у діапазон [a; b] і є простим (значення true в isPrime)
            {
                Console.Write(val + " "); // Виводимо число через пробіл
                foundAny = true; // Змінюємо прапорець, бо хоч одне знайшли
            }
        }
        if (!foundAny) Console.WriteLine("None"); // Якщо нічого не знайшли, виводимо слово "None"
        else Console.WriteLine(); // Інакше просто переводимо на новий рядок
    }
```

## Завдання 3: Метод лінійного пошуку (Кількість повторень елементів)
```csharp
    static void Task3() 
    {
        Console.Clear(); // Очищуємо
        Console.WriteLine("=== Task 3: Count repetitions using linear search ===\n"); // Заголовок
        if (generatedArray == null) { Console.WriteLine("Please generate array in Task 1 first."); return; } // Вимога мати масив

        bool[] visited = new bool[generatedArray.Length]; // Масив для відстеження елементів, які ми вже підрахували (щоб не рахувати двічі)
        for (int i = 0; i < generatedArray.Length; i++) // Зовнішній цикл по кожному індексу (i)
        {
            if (visited[i]) continue; // Якщо число на індексі i вже перевірялось раніше, пропускаємо його і йдемо на наступну ітерацію циклу
            int count = 1; // Лічильник повторень, поточний елемент вже існує 1 раз, отже починаємо з 1
            for (int j = i + 1; j < generatedArray.Length; j++) // Внутрішній цикл для перевірки всіх елементів, що стоять ПІСЛЯ i-го
            {
                if (generatedArray[i] == generatedArray[j]) // Якщо знайшли ідентичний елемент (лінійний пошук)
                {
                    count++; // Збільшуємо його лічильник повторень
                    visited[j] = true; // Помічаємо цей дублікат як 'перевірений', щоб зовнішній цикл його потім пропустив
                }
            }
            Console.WriteLine($"Element {generatedArray[i],4} repeats {count} times."); // Виведення результату з форматуванням (по '4' позиції на число для рівного виводу)
        }
    }
```

## Завдання 4: Лінійний пошук мін/макс в масиві
```csharp
    static void Task4()
    {
        Console.Clear();
        Console.WriteLine("=== Task 4: Find min and max using linear search ===\n");
        if (generatedArray == null || generatedArray.Length == 0) { Console.WriteLine("Please generate array in Task 1 first."); return; }

        int min = generatedArray[0], minIdx = 0; // Початково мінімумом вважаємо нульовий елемент масиву
        int max = generatedArray[0], maxIdx = 0; // Аналогічно для максимуму - встановлюємо перший елемент

        for (int i = 1; i < generatedArray.Length; i++) // Починаємо цикл з 1-го індексу і до кінця
        {
            if (generatedArray[i] < min) // Якщо поточний елемент менший за знайдений раніше мінімум
            {
                min = generatedArray[i]; // Оновлюємо змінну мінімуму
                minIdx = i; // Запам'ятовуємо його індекс
            }
            if (generatedArray[i] > max) // Якщо поточний елемент більший за знайдений раніше максимум
            {
                max = generatedArray[i]; // Оновлюємо максимум
                maxIdx = i; // Запам'ятовуємо цей індекс
            }
        }

        Console.WriteLine($"Minimum element: {min} at index {minIdx}"); // Виводимо мінімум і на якому він місці
        Console.WriteLine($"Maximum element: {max} at index {maxIdx}"); // Виводимо максимум і його індекс
    }
```

## Завдання 5: Бінарний пошук (свій метод + вбудований)
```csharp
    static void Task5()
    {
        Console.Clear();
        Console.WriteLine("=== Task 5: Binary search in array ===\n");
        if (generatedArray == null || generatedArray.Length == 0) { Console.WriteLine("Please generate array in Task 1 first."); return; }

        int target = ReadInt("Enter the element to search for: "); // Запитуємо у користувача число, що потрібно знайти

        // Custom Binary Search (власна реалізація бінарного пошуку)
        int left = 0, right = generatedArray.Length - 1; // Встановлюємо початково ліву та праву межу масиву
        int customIndex = -1; // Змінна для збереження результату пошуку (-1 означатиме, що не знайдено)
        while (left <= right) // Поки діапазон пошуку не звузиться і межі не перетнуться
        {
            int mid = left + (right - left) / 2; // Обчислюємо середину безпечним від переповнень способом
            if (generatedArray[mid] == target) // Якщо елемент посередині - це саме шукане значення
            {
                customIndex = mid; // Зберігаємо знайдений індекс
                break; // Перериваємо пошук
            }
            else if (generatedArray[mid] < target) // Увага: остільки наш масив сортований ЗА СПАДАННЯМ, якщо середина МЕНША за target...
            {
                right = mid - 1; // ... значить потрібне більше число лежить ЛІВІШЕ від середини, тому праву межу зсуваємо вліво
            }
            else // Якщо середина більша за target...
            {
                left = mid + 1; // ... треба шукати менші числа правіше від середини
            }
        }

        if (customIndex != -1) // Якщо індекс був знайдений
            Console.WriteLine($"[Custom Binary Search] Element {target} found at index {customIndex}."); // Виводимо
        else
            Console.WriteLine($"[Custom Binary Search] Element {target} is NOT present in the array."); // Або повідомлення про відсутність

        // Using Array.BinarySearch (за допомогою системного класу, що було необхідно за завданням)
        int arrIndex = Array.BinarySearch(generatedArray, target, new DescendingComparer()); // Використовуємо вбудований метод з кастомним компаратором (щоб розповісти системі, що масив спадає)
        if (arrIndex >= 0) // Вбудована функція повертає >= 0 якщо знайшла
            Console.WriteLine($"[Array.BinarySearch] Element {target} found at index {arrIndex}.");
        else
            Console.WriteLine($"[Array.BinarySearch] Element {target} is NOT present in the array.");
    }
```

## Завдання 6: Робота з двовимірним масивом (Матриця)
```csharp
    static void Task6()
    {
        Console.Clear();
        Console.WriteLine("=== Task 6: Matrix generation and sum calculations ===\n");
        
        int rows = ReadInt("Enter number of rows: ", 1, 100); // Зчитуємо кількість рядків матриці (1-100)
        int cols = ReadInt("Enter number of columns: ", 1, 100); // Кількість стовпчиків

        matrix = new int[rows, cols]; // Створюємо об'єкт двовимірного масиву (матриці) заданих розмірів
        for (int i = 0; i < rows; i++) // Зовнішній цикл для проходження кожного рядка
        {
            for (int j = 0; j < cols; j++) // Внутрішній цикл для проходження стовпчиків (конкретної комірки рядка)
            {
                matrix[i, j] = rand.Next(-50, 51); // Генерація випадкового числа в кожну комірку [-50..50]
            }
        }

        Console.WriteLine("\nGenerated Matrix:");
        for (int i = 0; i < rows; i++) // Другий аналогічний подвійний цикл, але для виведення на екран
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],4} "); // Виведення кожного елемента з вирівнюванням у 4 позиції вправо (для рівної таблички)
            }
            Console.WriteLine(); // Після виведення всіх стовпців одного рядка робимо перехід на новий рядок
        }

        Console.WriteLine();
        int targetRow = ReadInt($"Enter row index to sum (0 to {rows - 1}): ", 0, rows - 1); // Зчитуємо індекс потрібного рядка
        int targetCol = ReadInt($"Enter column index to sum (0 to {cols - 1}): ", 0, cols - 1); // Зчитуємо індекс потрібного стовпця

        long rowSum = 0; // Змінна для підрахунку суми цілого рядка (long бо сума може бути великою)
        for (int j = 0; j < cols; j++) rowSum += matrix[targetRow, j]; // Додаємо на всі стовпчики в фіксованому рядку (targetRow)

        long colSum = 0; // Змінна для суми стовпчика
        for (int i = 0; i < rows; i++) colSum += matrix[i, targetCol]; // Додаємо на всі рядки у фіксованому стовпчику (targetCol)

        Console.WriteLine($"\nSum of elements in row {targetRow}: {rowSum}"); // Вивід результату для рядка
        Console.WriteLine($"Sum of elements in col {targetCol}: {colSum}");   // Для стовпчика
    }
```

## Завдання 7: Мін/Макс матриці через Math
```csharp
    static void Task7()
    {
        Console.Clear();
        Console.WriteLine("=== Task 7: Min and Max in matrix using Math methods ===\n");
        if (matrix == null || matrix.Length == 0) { Console.WriteLine("Please generate matrix in Task 6 first."); return; }

        int rows = matrix.GetLength(0); // Вбудований метод двовимірного масиву для отримання розмірності 0 (кількості рядків)
        int cols = matrix.GetLength(1); // Вбудований метод розмірності 1 (для отримання кількості стовпців)

        int min = matrix[0, 0], minR = 0, minC = 0; // Початково мінімальним вважається елемент [0, 0], змінні R і C для запису рядка і стовпця
        int max = matrix[0, 0], maxR = 0, maxC = 0; // Аналогічно для максимального

        for (int i = 0; i < rows; i++) // Перебираємо рядки
        {
            for (int j = 0; j < cols; j++) // Перебираємо стовпці
            {
                int current = matrix[i, j]; // Беремо поточне значення з цієї комірки

                int tempMin = Math.Min(min, current); // Використовуємо метод методу класу Math.Min, який повертає менше з 2 чисел
                if (tempMin < min) // Якщо нове число справді менше за наш зафіксований мінімум
                {
                    min = tempMin; // Зберігаємо нове значення як найменше
                    minR = i; minC = j; // Зберігаємо його координати матриці
                }

                int tempMax = Math.Max(max, current); // Метод Math.Max - обчислює більше число з поточного макс. і цього елемента
                if (tempMax > max) // Якщо знайшли нове максимальне
                {
                    max = tempMax; // Оновлюємо
                    maxR = i; maxC = j; // Запам'ятовуємо координати (індекси)
                }
            }
        }

        Console.WriteLine($"Minimum element: {min} at [Row {minR}, Col {minC}]"); // Вивід мінімуму та позиції
        Console.WriteLine($"Maximum element: {max} at [Row {maxR}, Col {maxC}]"); // Вивід максимуму
    }
```

## Завдання 8: Метод половинного ділення (Бісекції)
```csharp
    static void Task8()
    {
        Console.Clear();
        Console.WriteLine("=== Task 8: Roots of nonlinear equation (Bisection method) ===\n");
        Console.WriteLine("Equation: 6x^4 - 3x^3 + 8x^2 - 25 = 0\n"); // Вивід самого рівняння для користувача

        double epsilon = 1e-6; // Точність (похибка) для наближеного знаходження кореня (0.000001)
        Console.WriteLine($"Scanning domain [-10, 10] with epsilon = {epsilon}...\n"); // Область пошуку обрано від -10 до 10 емпіричним шляхом
        
        int rootsFound = 0; // Лічильник кількості знайдених коренів
        for (double x = -10; x <= 10; x += 0.05) // Розбиваємо весь можливий інтервал [-10; 10] на маленькі відрізки розміром по 0.05
        {
            double a = x; // Початок маленького відрізка
            double b = x + 0.05; // Кінець маленького відрізка
            double fa = EquationF(a); // Обчислюємо значення функції в точці a (в лівій межі відрізка)
            double fb = EquationF(b); // Значення функції в точці b (в правій межі)

            if (fa * fb <= 0) // Згідно теореми Больцано-Коші: якщо знаки на кінцях відрізка різні, їх добуток від'ємний. Це значить що на цьому відрізку графік перетинає X=0 (існує корінь)
            {
                double root = Bisection(a, b, epsilon); // Виклик нашої функції бісекції для точного пошуку цього кореня на даному відрізку
                Console.WriteLine($"Found root: x = {root:F6}"); // Виводимо знайдений корінь (з 6 знаками після коми)
                Console.WriteLine($"Verification: F({root:F6}) = {EquationF(root):F10}\n"); // Здійснення перевірки - підставляємо корінь у ф-цію. Має вийти дуже близько до нуля
                rootsFound++; // Збільшуємо загальний лічильник
            }
        }

        if (rootsFound == 0) Console.WriteLine("No roots found in [-10, 10]."); // Якщо коренів на проміжку зовсім не виявлено
    }
```

## Завдання 9: Операції з рядками (без використання вбудованих функцій Replace, Insert, IndexOf)
```csharp
    static void Task9()
    {
        Console.Clear();
        Console.WriteLine("=== Task 9: String operations ===\n");

        Console.Write("Enter initial string: "); // Просимо ввести початковий рядок
        string text = Console.ReadLine() ?? ""; // Зчитуємо його. "?? """ - оператор об'єднання з null: якщо ReadLine поверне null, замінюємо на пустий рядок (запобігає помилці)

        // Пошук
        Console.Write("\nEnter substring to search for: ");
        string searchStr = Console.ReadLine() ?? ""; // Підрядок для пошуку
        int searchIdx = CustomIndexOf(text, searchStr); // Наша власна функція пошуку підрядка
        if (searchIdx != -1) // Якщо повернуло не -1, значить знайшли
            Console.WriteLine($"Substring found at index {searchIdx}.");
        else
            Console.WriteLine("Substring not found."); // Інакше не знайдено

        // Заміна
        Console.Write("\nEnter substring to replace: ");
        string replaceOld = Console.ReadLine() ?? ""; // Запитуємо що саме замінити (шматочок тексту)
        Console.Write("Enter new substring to replace with: "); 
        string replaceNew = Console.ReadLine() ?? ""; // На що його слід замінити
        string afterReplace = CustomReplaceAll(text, replaceOld, replaceNew); // Виклик нашого власного методу заміни
        Console.WriteLine($"After Replace: {afterReplace}"); // Виведення результату
        text = afterReplace; // Оновлюємо змінну тексту для наступних кроків

        // Вставка
        Console.Write("\nEnter substring to insert: ");
        string insertStr = Console.ReadLine() ?? ""; // Запис рядка для вставки
        int insertIdx = ReadInt($"Enter index to insert at (0 to {text.Length}): ", 0, text.Length); // Зчитування індексу з перевіркою (індекс не може бути більшим за довжину тексту)
        string afterInsert = CustomInsert(text, insertIdx, insertStr); // Виклик власної функції вставки
        Console.WriteLine($"After Insert: {afterInsert}");
        text = afterInsert; // Зберігаємо результат

        // Видалення
        Console.Write("\nEnter substring to delete: ");
        string deleteStr = Console.ReadLine() ?? ""; // Запис того, що треба вилучити
        string afterDelete = CustomRemove(text, deleteStr); // Виклик вилучення
        Console.WriteLine($"After Delete: {afterDelete}");
        text = afterDelete;

        Console.WriteLine($"\nFinal string: {text}"); // Остаточний результат після всіх операцій
    }
```

## Допоміжні методи та алгоритми (Helper methods)

### QuickSortDescending (Швидке сортування за спаданням)
```csharp
    // Допоміжний метод друку масиву у зручному форматі
    static void PrintArray(int[] arr)
    {
        if (arr == null || arr.Length == 0) Console.WriteLine("Array is empty."); // Якщо масиву немає чи він порожній
        else Console.WriteLine(string.Join(", ", arr)); // Зливає всі елементи в один рядок, розділяючи комою
    }

    // Рекурсивна функція алгоритму QuickSort
    static void QuickSortDescending(int[] arr, int left, int right)
    {
        if (left < right) // Рекурсія продовжується тільки якщо індекс зліва менший ніж індекс справа
        {
            int pivot = Partition(arr, left, right); // Знаходження опорного елементу (pivot) і переміщення його на остаточну правильну позицію
            QuickSortDescending(arr, left, pivot - 1); // Рекурсивне сортування лівої частини відносно pivot'у
            QuickSortDescending(arr, pivot + 1, right); // Рекурсивне сортування правої частини масиву
        }
    }

    // Розділення масиву для QuickSort (спеціально адаптовано під спадання)
    static int Partition(int[] arr, int left, int right)
    {
        int pivotValue = arr[right]; // Опорним елементом обирається крайній правий елемент
        int i = left - 1; // Індекс елементу, який належить до групи тих, які більші за pivot
        for (int j = left; j < right; j++) // Проходимо від початку і до опорного елементу
        {
            if (arr[j] >= pivotValue) // Якщо поточний елемент більший-рівний за опорний (тобто сортуємо за СПАДАННЯМ!)
            {
                i++; // Збільшуємо індекс групи "більших елементів"
                // Міняємо місцями arr[i] та arr[j] (класичний обмін - swap) за допомогою тимчасової temp
                int temp = arr[i]; 
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        // В кінці ставимо опорний елемент між групами
        int t = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = t;
        return i + 1; // Повертаємо індекс опорного елементу, на який він встав
    }

    // Спеціальний клас компаратора для перевантаженого системного бінарного пошуку Array.BinarySearch за спаданням
    class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y) // Метод інтерфейсу IComparer порівняння 2-х чисел
        {
            return y.CompareTo(x); // Навмисно повертає обернене значення стандартного порівняння, щоб вбудований алгоритм правильно працював для спадного масиву
        }
    }
```

### Математичні функції Bisection
```csharp
    // Функція, з якої шукаються корені в Завданні 8
    static double EquationF(double x)
    {
        return 6 * Math.Pow(x, 4) - 3 * Math.Pow(x, 3) + 8 * Math.Pow(x, 2) - 25; // Просте обчислення значення многочлена 6x^4 - 3x^3 + 8x^2 - 25
    }

    // Алгоритм бісекції (половинного ділення)
    static double Bisection(double a, double b, double epsilon)
    {
        while ((b - a) / 2.0 > epsilon) // Цикл працює поки довжина половини відрізка більша за допустиму похибку (epsilon)
        {
            double mid = (a + b) / 2.0; // Беремо координату середини відрізка
            if (EquationF(mid) == 0.0) return mid; // Якщо пощастило і значення точно в нулі - повертаємо результат

            if (EquationF(a) * EquationF(mid) < 0) // Перевіряємо, в якій половині змінився знак: якщо знаки на кінцях [a; mid] різні...
                b = mid; // Отже, корінь лежить у лівій половині, зсуваємо праву межу b до центру
            else
                a = mid; // Отже, корінь лежить у правій половині, зсуваємо ліву межу a до центру
        }
        return (a + b) / 2.0; // Повертає приблизне значення кореня (як середину останнього відрізку, що залишився)
    }
```

### Користувацькі функції по роботі з рядками
```csharp
    // Власний метод пошуку першого входження підрядка. Замінює стандартний string.IndexOf()
    static int CustomIndexOf(string source, string target, int startIndex = 0)
    {
        if (string.IsNullOrEmpty(target) || source.Length == 0) return -1; // Перевірка на пусті рядки (запобігає падінню)
        for (int i = startIndex; i <= source.Length - target.Length; i++) // Біжимо по основному тексту, немає сенсу перевіряти кінець, куди підрядок вже не влізе (source.Length - target.Length) 
        {
            bool match = true; // Припускаємо що знайшли збіг
            for (int j = 0; j < target.Length; j++) // Перевіряємо збіг посимвольно в циклі для підрядка
            {
                if (source[i + j] != target[j]) // Якщо бодай один символ не збігається
                {
                    match = false; // То збігу немає
                    break; // Перериваємо внутрішній цикл і йдемо на наступне значення 'i'
                }
            }
            if (match) return i; // Якщо після перевірки усіх букв match залишився true, значить підрядок знайдено з індексу i
        }
        return -1; // Якщо цикл завершився і нічого не знайдено
    }

    // Власна заміна всіх входжень. Замінює string.Replace()
    static string CustomReplaceAll(string source, string oldStr, string newStr)
    {
        if (string.IsNullOrEmpty(oldStr)) return source; // Якщо підрядок, який шукаємо, порожній - повертаємо оригінал
        string result = ""; // Результуючий рядок 
        int i = 0; // Лічильник поточної позиції у тексті
        while (i < source.Length) // Поки не дійдемо до кінця тексту
        {
            int matchIdx = CustomIndexOf(source, oldStr, i); // Шукаємо підрядок починаючи від позиції 'i'
            if (matchIdx == i) // Якщо він починається прямо з поточної букви 'i'
            {
                result += newStr; // То додаємо в результат новий шматок тексту, яким ми замінюємо старий
                i += oldStr.Length; // І стрибаємо вперед (прокручуємо 'i') на довжину того підрядка, який ми щойно замінили, щоб не додавати його.
            }
            else
            {
                result += source[i]; // Інакше (бажаного підрядка там нема) ми просто додаємо поточну літеру до результату
                i++; // І переходимо до наступної по одній букві
            }
        }
        return result; // Повертаємо склеєний рядок
    }

    // Власна функція вставки підрядка в будь-яке місце. Замінює string.Insert()
    static string CustomInsert(string source, int idx, string insertStr)
    {
        string result = ""; // Створюємо пустий контейнер для результату
        for(int i = 0; i < source.Length; i++) // Проходимося по кожному символу оригіналу
        {
            if (i == idx) result += insertStr; // Якщо ми дійшли до потрібного індексу - спершу вписуємо наш підрядок, який треба вставити
            result += source[i]; // і потім дописуємо символ з оригіналу
        }
        if (idx == source.Length) result += insertStr; // Якщо вставка проситься в самий кінець рядка (після останньої букви)
        return result; // Повертаємо
    }

    // Власна функція знищення підрядка з тексту. 
    static string CustomRemove(string source, string target)
    {
        return CustomReplaceAll(source, target, ""); // Хитрий трюк: вона просто використовує нашу функцію CustomReplaceAll, де заміна відбувається на "пустий рядок" - тобто це еквівалент видалення
    }
```

### Допоміжні безпечні функції вводу з оболонками
```csharp
    // Функція безпечного читання цілого числа int "від дурня" 
    static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int result; // Мін і макс за замовчуванням дорівнюють мінімальному і максимальному можливому Int
        while (true) // Безкінечний цикл, з якого вийдемо тільки при правильному вводі
        {
            Console.Write(prompt); // Виводить текст-запит (наприклад 'Enter N: ')
            if (int.TryParse(Console.ReadLine(), out result)) // Спробує перевести рядок від користувача в число int
            {
                if (result >= min && result <= max) // Якщо він перевівся, та ще й попадає в дозволений за умовою діапазон...
                    return result; // ...повертає його для запису у змінну в програмі, перериваючи функцію
                else
                    Console.WriteLine($"Please enter a number between {min} and {max}."); // Сварка за діапазон
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer."); // Сварка за літери чи інші символи замість цифр 
            }
        }
    }

    // Аналогічна безпечна функція для зчитування нецілого числа (типу double)
    static double ReadDouble(string prompt)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out result)) // Перевод тексту у тип з комою
                return result; // Якщо успішно - повертає
            Console.WriteLine("Invalid input. Please enter a valid number."); // Помилка, якщо введено не число
        }
    }
```
