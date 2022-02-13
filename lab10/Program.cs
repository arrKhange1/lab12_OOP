using System;

namespace lab10
{
    class Program
    {
        static void FirstPart()
        {
            Console.WriteLine("\tFirstPart\n");
            Person[] arr = new Person[4] { new Person { FirstName = "Tony" }, new Worker { FirstName = "Gosha" }, new Administration { FirstName = "Nathan" }, new Engineer { FirstName = "Ben" } };
            foreach (var obj in arr) obj.Print();   // pt.1
            Console.WriteLine();
        }
        static void SecondPart()
        {
            Console.WriteLine("\tSecondPart\n");
            Person[] businessArray = new Person[6] {
                new Worker { FirstName = "John", factoryName = "BigFac Inc.", positionName = "Dvornik" },
                new Worker { FirstName = "Bill", factoryName = "Skynet Inc.", positionName = "Cleaner" },
                new Administration { FirstName = "Admin" },
                new Engineer { FirstName = "Mike", factoryName = "BigFac Inc.", positionName = "Software engineer" },
                new Engineer { FirstName = "Tony", factoryName = "Tesla", positionName = "Software engineer" },
                new Engineer { FirstName = "Angel", factoryName = "Tesla", positionName = "Analytics engineer" }
                };
            Console.WriteLine("Массив сотрудников:");
            foreach (Person obj in businessArray)
            {
                if (obj.GetType().Name == "Engineer" || obj.GetType().Name == "Worker")
                {
                    Worker newObj = (Worker)obj;
                    Console.WriteLine($"FirstName = {obj.FirstName}, factory = {newObj.factoryName}, posName = {newObj.positionName}");
                }
                else Console.WriteLine($"FirstName = {obj.FirstName}");
            }
            Console.WriteLine("\nВыберите один из запросов:\n1. Имена рабочих заданного цеха\n2. Имена рабочих заданной профессии\n3. Количество инженеров на заводе\n\n");
            Choose(GetVar(), businessArray);
            Console.WriteLine();
        }

        static void Choose(int var, Person[] arr)
        {
            switch (var)
            {
                case 1:
                    {
                        Console.WriteLine("Задайте название цеха:");
                        string cehName = Console.ReadLine();
                        int cnt = 0;
                        foreach (var obj in arr)
                        {
                            if (obj is Worker worker && worker.factoryName == cehName) { Console.WriteLine($"{++cnt}. {worker.FirstName}"); }
                        }
                        if (cnt == 0) Console.WriteLine($"Рабочих с цеха {cehName} не нашлось!");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Задайте название профессии:");
                        string posName = Console.ReadLine();
                        int cnt = 0;
                        foreach (var obj in arr)
                        {
                            if (obj is Worker worker && worker.positionName == posName) { Console.WriteLine($"{++cnt}. {worker.FirstName}"); }
                        }
                        if (cnt == 0) Console.WriteLine($"Рабочих профессии \"{posName}\" не нашлось!");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Задайте название завода:");
                        string facName = Console.ReadLine();
                        int cnt = 0;
                        foreach (var obj in arr)
                        {
                            if (obj is Engineer engineer && engineer.factoryName == facName) ++cnt;
                        }
                        Console.WriteLine($"На заводе \"{facName}\" инженеров: {cnt}");
                        break;
                    }
            }
        }
        static int GetVar()
        {
            bool correct; int x;
            do
            {
                correct = Int32.TryParse(Console.ReadLine(), out x) && x > 0 && x < 5;
                if (!correct) Console.WriteLine("Try one more time...");
            } while (!correct);
            return x;
        }

        static void ThirdPart()
        {
            IExecutable[] businessArray = FirstNSecondTasksThirdPart();
            Console.WriteLine();
            ThirdTaskThirdPart(businessArray);
            Console.WriteLine();
            FourthTaskThirdPart();
            Console.WriteLine();
            FifthTaskThirdPart();
        }
        static void FifthTaskThirdPart()
        {
            Person pers1 = new Person("John", new Number(5));
            Person pers2 = (Person)pers1.Clone();
            pers2.FirstName = "Ben";
            pers2.n.Num = 100;
            //при поверхностном копировании в pers2 ТОТ ЖЕ объект что и в pers1, поэтому pers2 перезаписывает фактори нейм в pers1
            Console.WriteLine($"Копирование:\npers1 = {pers1.FirstName}, Num = {pers1.n.Num}; pers2 = {pers2.FirstName} Num = {pers2.n.Num}");


        }
        static void FourthTaskThirdPart()
        {
            Person[] businessArray = new Person[6] {
                new Worker { FirstName = "John"},new Worker { FirstName = "Bill"},new Administration { FirstName = "Admin" },new Engineer { FirstName = "Mike" },new Engineer { FirstName = "Tony" },new Engineer { FirstName = "Angel" }
            };

            Array.Sort(businessArray, new PersonComparer()); // PersonComparer - спец класс-компаратор для объектов Person
            Console.WriteLine("Отсортированный массив с IComparer:");
            foreach (Person obj in businessArray)
                Console.WriteLine(obj.FirstName);

            int index = Array.BinarySearch(businessArray, new Engineer { FirstName = "Angel" }, new PersonComparer());  // поиск объекта в массиве via IComparer
            if (index > -1) Console.WriteLine($"Объект находится на {index} индексе");
            else Console.WriteLine("Объекта нет в массиве");


        }
        static void ThirdTaskThirdPart(IExecutable[] businessArray)
        {
            Array.Sort(businessArray);
            Console.WriteLine("Отсортированный массив с IComparable:");
            foreach (Person obj in businessArray)
            {
                Console.WriteLine(obj.FirstName);
            }
        }
        static IExecutable[] FirstNSecondTasksThirdPart()
        {
            IExecutable[] businessArray = new IExecutable[6] {
                new Worker { FirstName = "John"},new Worker { FirstName = "Bill"},new Administration { FirstName = "Admin" },new Engineer { FirstName = "Mike" },new Engineer { FirstName = "Tony" },new Engineer { FirstName = "Angel" }
            };
            Console.WriteLine("Тест реализованного метода вывода у интерфейса:");
            foreach (var obj in businessArray)
            {
                obj.InterfPrint();
            }
            return businessArray;
        }
        static void Main(string[] args)
        {
            FirstPart();
            SecondPart();
            ThirdPart();

        }
    }
}
