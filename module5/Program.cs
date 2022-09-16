using System;
using System.Drawing;

class MainProg
{
    public static void Main(string[] args)
    {
        var user = createUser;

    }

    static (string name, string surname, 
        byte age, string[] petsName, 
        string[] favColours) createUser()
    {
        (string name, string surname,
            byte age, bool hasPet,
            byte countOfPets, string[] petsName,
            byte countOfFavColours, string[] favColours) user;

        rightString(out user.name, "Введите имя: ");

        rightString(out user.surname, "Введите фамилию: ");

        rightNumber(out user.age, "Введите возраст: ");
        
        Console.Write("У вас есть питомец? Введите \"Да\", если есть, или любую другую строку, если нет.");
        user.hasPet = (Console.ReadLine() == "Да") ? true : false;

        user.petsName = new string[0];
        if (user.hasPet)
        {
            rightNumber(out user.countOfPets, "Введите количество питомцев: ");
            user.petsName = fillArray(user.countOfPets);
        }

        rightNumber(out user.countOfFavColours, "Введите количество любимых цветов: ");
        user.favColours = fillArray(user.countOfFavColours);

        return (user.name, user.surname, user.age, user.petsName, user.favColours);

    }

    static void aboutUser(in
        (string name,
        string surname,
        byte age,
        string[] petsName,
        string[] favColours) user)
    {
        Console.WriteLine($"Имя: {user.name}");
        Console.WriteLine($"Фамилия: {user.surname}");
        Console.WriteLine($"Возраст: {user.age}");

        if (user.petsName.Length == 0) Console.WriteLine("Питомцев нет");
        else ShowArray(user.petsName, "Питомцы: ");

        if (user.favColours.Length == 0) Console.WriteLine("Любимых цветов нет");
        else ShowArray(user.favColours, "Любимые цвета: ");
    }

    //функция принимает строку, в которую запишется ответ пользователя,
    //и строку о просьбе, что именно ввести
    static void rightString(out string answer,in string ask)
    {
        Console.Write(ask);
        link1:
        answer = Console.ReadLine();
        foreach (char c in answer)
            if ('0' < c && c < '9')
            {
                Console.Write("Вводите только буквы: ");
                goto link1;
            }
    }

    //функция принимает число, в которое запишется ответ пользователя,
    //и строку о просьбе, что именно ввести
    static void rightNumber(out byte num, in string ask)
    {
        Console.Write(ask);
        while (!byte.TryParse(Console.ReadLine(), out num) && num <= 0) {
            Console.Write("Введите число > 1: ");
        }
    }

    //функция заполнения массива строками
    public static string[] fillArray(int num)
    {
        string[] array = new string[num];
        for (int i = 0; i < num; i++)
        {
            array[i] = Console.ReadLine();
        }

        return array;

    }

    //функция вывода массива, принимающая массив строк, которые следует вывести,
    //и строку, описывающую, что выводится
    public static void ShowArray(string[] array, in string what)
    {
        Console.WriteLine(what);
        foreach (string item in array) Console.WriteLine(item);
    }

    public static void Sort(int[] array)
{
        int temp;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}