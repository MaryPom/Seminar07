// Практическая работа семинара 7
int[,] GeneratsiyaMatritsy(int n, int m)
{
    Random rnd = new Random();
    int[,] matr = new int[n,m];
    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {
            matr[i,j] = rnd.Next(0,100);
        }
    }
    return matr;
}

void VivodMatritsy(int[,] matr)
{
    for(int i = 0; i < matr.GetLength(0); i++)
    {
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i,j]}   ");
        }
        Console.WriteLine();
    }
}

void Task1() 
{
    Console.Write("Введите количество строк матрицы: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    int m = int.Parse(Console.ReadLine());
    int[,] matr = GeneratsiyaMatritsy(n,m);
    Console.WriteLine("Сгенерированная матрица");
    VivodMatritsy(matr);
    Console.WriteLine();

    Console.Write("Введите число: ");
    int x = int.Parse(Console.ReadLine());
    bool found = false;
    for(int i = 0; i < matr.GetLength(0); i++)
    {
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            if(matr[i,j] == x)
            {
                Console.WriteLine($"Элемент находится в ячейке [{i},{j}]");
                found = true;
            }
        }
    }
    if(!found)
    {
        Console.WriteLine("Заданное число не найдено");
    }
    Console.WriteLine();
}

void Task2()
{
    Console.Write("Введите количество строк матрицы: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    int m = int.Parse(Console.ReadLine());
    //генерация и вывод матрицы
    int[,] matr = GeneratsiyaMatritsy(n,m);
    Console.WriteLine("Сгенерированная матрица");
    VivodMatritsy(matr);
    Console.WriteLine();

    Console.WriteLine("Средее арифметическое");
    for(int j = 0; j < matr.GetLength(1); j++)
    {
        int sum = 0;
        for(int i = 0; i < matr.GetLength(0); i++)
        {
            sum += matr[i,j];
        }
        Console.WriteLine($"{j}-го столбца: {sum/(double)matr.GetLength(0)}");
    }
    Console.WriteLine();
}

void Task3()
{
    Console.Write("Введите количество строк матрицы: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    int m = int.Parse(Console.ReadLine());
    //генерация и вывод матрицы
    int[,] matr = GeneratsiyaMatritsy(n,m);
    Console.WriteLine("Сгенерированная матрица");
    VivodMatritsy(matr);
    Console.WriteLine();

    for(int j = 0; j < matr.GetLength(1); j++)
    {
        int temp = matr[0,j];
        matr[0,j] = matr[matr.GetLength(0) - 1,j];
        matr[matr.GetLength(0) - 1,j] = temp;
    }

    Console.WriteLine("После перемены:");
    VivodMatritsy(matr);
    Console.WriteLine();
}

void Task4()
{
    Console.Write("Введите количество строк матрицы: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    int m = int.Parse(Console.ReadLine());
    int[,] matr = GeneratsiyaMatritsy(n,m);
    Console.WriteLine("Сгенерированная матрица");
    VivodMatritsy(matr);
    Console.WriteLine();

    for(int i = 0; i < matr.GetLength(0); i++)
    {
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            for(int k = 0; k < matr.GetLength(1) - j - 1; k++)
            {
                if(matr[i,k] < matr[i,k+1])
                {
                    int temp = matr[i,k];
                    matr[i,k] = matr[i,k+1];
                    matr[i,k+1] = temp;
                }
            }
        }
    }
    Console.WriteLine("После сортировки:");
    VivodMatritsy(matr);
    Console.WriteLine();
}

void Task5()
{
    Console.Write("Введите количество строк матрицы: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    int m = int.Parse(Console.ReadLine());
    int[,] matr = GeneratsiyaMatritsy(n,m);
    Console.WriteLine("Сгенерированная матрица");
    VivodMatritsy(matr);
    Console.WriteLine();

    if(matr.GetLength(0) != matr.GetLength(1))
    {
        Console.WriteLine("Матрица не квадратная, невозможно заменить строки на столбцы");
        Console.WriteLine();
        return;
    }

    for(int i = 0; i < matr.GetLength(0); i++)
    {
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            if(i < j)
            {
                int temp = matr[i,j];
                matr[i,j] = matr[j,i];
                matr[j,i] = temp;
            }
        }
    }
    
    Console.WriteLine("Матрица после изменения:");
    VivodMatritsy(matr);
    Console.WriteLine();
}

async void Task6()
{
    Console.Write("Введите количество строк матрицы: ");
    int n = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    int m = int.Parse(Console.ReadLine());
    int[,] matr = GeneratsiyaMatritsy(n,m);
    Console.WriteLine("Сгенерированная матрица");
    VivodMatritsy(matr);
    Console.WriteLine();
    int minSum = int.MaxValue;
    int rowNum = -1;
    for(int i = 0; i < matr.GetLength(0); i++)
    {
        int sum = 0;
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            sum += matr[i,j];
        }
        if(rowNum == -1)
        {
            rowNum = i;
            minSum = sum;
        }
        else if(sum < minSum)
        {
            rowNum = i;
            minSum = sum;
        }
    }
    Console.WriteLine($"Наименьшая сумма {minSum} находится в строке {rowNum}");
    Console.WriteLine();
}

Console.WriteLine("Какое задание выполнить?");
Console.WriteLine("1. Показать позиции числа, заданного пользователем");
Console.WriteLine("2. Среднее арифметическое");
Console.WriteLine("3. Обменять элементы первой строки и последней строки");
Console.WriteLine("4. Упорядочить по убыванию элементы каждой строки");
Console.WriteLine("5. Заменить строки на столбцы");
Console.WriteLine("6. Найти строку с наименьшей суммой элементов");
Console.Write("Ваш выбор: ");
int task = int.Parse(Console.ReadLine());
Console.WriteLine();
switch(task)
{
    case 1:
        Task1();
        break;
    case 2:
        Task2();
        break;
    case 3:
        Task3();
        break;
    case 4:
        Task4();
        break;
    case 5:
        Task5();
        break;
    case 6:
        Task6();
        break;
}