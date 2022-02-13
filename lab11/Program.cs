using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab11
{
    public class Program
    {
        static void FirstTask()
        {
            Stack <Person> stack = new Stack<Person>();
            stack = ChooseAction(stack);
            if (stack.Count != 0) StackClone(stack);
            
        }

        static void SearchInStack(Stack<Person> stack)
        {
            if (stack.Count != 0)
            {
                Console.Write("Введите имя для поиска: ");
                Console.WriteLine(); string searchName = Console.ReadLine();
                int cnt = 0, elem_cnt = 0;
                foreach(Person obj in stack)
                {
                    ++elem_cnt;
                    if (obj.FirstName == searchName) Console.WriteLine($"{++cnt}-е совпадение на {elem_cnt} элементе стэка");
                }
            }
        }
        static void SortStack(Stack<Person> stack)
        {
            if (stack.Count != 0)
            {
                List<Person> tmpList = new List<Person>();
                while (stack.Count != 0)
                {
                    tmpList.Add(stack.Peek());
                    stack.Pop();
                }
                tmpList.Sort();
                for (int i = 0; i < tmpList.Count; ++i)
                    stack.Push(tmpList[tmpList.Count - i - 1]);
                Console.WriteLine("\tОтсортированный стэк по именам:");
                foreach (Person obj in stack) Console.WriteLine(obj.FirstName);
            }
            else Console.WriteLine("Стэк пустой!");
            
        }
        static void StackClone(Stack<Person> stack)
        {
            Stack<Person> newStack = new Stack<Person>(stack.Count);

            foreach(Person obj in stack)
                newStack.Push((Person)obj.Clone());
            //newStack.Pop();

            Console.WriteLine("newStack:"); PrintStack(newStack);
            Console.WriteLine("oldStack:"); PrintStack(stack);
        }
             
        static Stack<Person> ChooseAction(Stack<Person> stack)
        {
            //Console.WriteLine(stack.Count); 
            Console.WriteLine("Введите действие:\n1.Добавление\n2.Удаление\n3.Количество объектов заданного класса\n4.Вывести имена объектов заданного класса\n5.Вывести классы с самым длинным именем объектов\n6.Напечатать стэк\n7.Отсортировать стэк\n8.Найти значение в стэке\n9. Назад");
            bool correct; int variant;
            do
            {
                correct = Int32.TryParse(Console.ReadLine(), out variant) && variant >= 1 && variant <= 9;
                if (!correct) Console.WriteLine("Try one more time...");
            } while (!correct);
            
            switch (variant)
            {
               case 1:
               {
                    AddElem(stack);
                    ChooseAction(stack);
                    break;
               }
               case 2:
               {
                    DelElems(stack);
                    ChooseAction(stack);
                    break;
               }
                case 3:
                    {
                        FirstQuery(stack);
                        ChooseAction(stack);
                        break;
                    }
                case 4:
                    {
                        SecondQuery(stack);
                        ChooseAction(stack);
                        break;
                    }
                case 5:
                    {
                        ThirdQuery(stack);
                        ChooseAction(stack);
                        break;
                    }
                case 6:
                    {
                        PrintStack(stack);
                        ChooseAction(stack);
                        break;
                    }
                case 7:
                    {
                        SortStack(stack);
                        ChooseAction(stack);
                        break;
                    }
                case 8:
                    {
                        SearchInStack(stack);
                        ChooseAction(stack);
                        break;
                    }
               case 9:
                    {
                        Console.WriteLine("Успешный выход!");
                        break;
                    }
                    
                    

             }
            
            
            return stack;
            
        }

        static void PrintStack(Stack<Person> stack)
        {
            if (stack.Count == 0) Console.WriteLine("Стэк пустой!");
            else
            {
                int cnt = 0;
                foreach(Person obj in stack)
                {
                    Console.WriteLine($"{++cnt}. object name = {obj.FirstName}, class name = {obj.GetType().Name}");
                }
            }
        }
        static void ThirdQuery(Stack<Person> stack)
        {
            int max = 0;
            foreach(Person obj in stack)
            {
                if (obj.FirstName.Length > max) max = obj.FirstName.Length;
            }

            int cnt = 0;
            foreach(Person obj in stack)
            {
                if (obj.FirstName.Length == max) Console.WriteLine($"{++cnt}.{obj.GetType().Name}, FirstName = {obj.FirstName}, Length = {obj.FirstName.Length}");
            }
            if (cnt == 0) Console.WriteLine("Стэк пустой!");
        }
        static void SecondQuery(Stack<Person> stack)
        {
            Console.WriteLine("Задайте название класса:");
            string className = Console.ReadLine();
            int cnt = 0;
            foreach (Person obj in stack)
            {
                if (obj.GetType().Name == className) Console.WriteLine($"{++cnt}. {obj.FirstName}, class: {obj.GetType().Name}"); ;
            }
            if (cnt == 0) Console.WriteLine($"Объектов класса {className} не найдено!");
        }
        static void FirstQuery(Stack<Person> stack)
        {
            Console.WriteLine("Задайте название класса:");
            string className = Console.ReadLine();
            int cnt = 0;
            foreach(Person obj in stack)
            {
                if (obj.GetType().Name == className) ++cnt;
            }
            if (cnt == 0) Console.WriteLine($"Объектов класса {className} не найдено!");
            else Console.WriteLine($"Объектов класса {className}: {cnt}");
        }
        static void DelElems(Stack<Person> stack)
        {
            while(stack.Count != 0)
            {
                stack.Pop();
            }
            Console.WriteLine("Стэк успешно очищен!");
        }
        static void AddElem(Stack<Person> stack)
        {
            bool correct = true;
            Console.WriteLine("Введите название класса для добавления:\n1.Person\n2.Engineer\n3.Worker\n4.Administration");
            Int32.TryParse(Console.ReadLine(), out int className);
            do
            {
                switch (className)
                {
                    case 1:
                        {
                            stack.Push(new Person ("Ben"));
                            
                            correct = true;
                            break;
                        }
                    case 2:
                        {
                            stack.Push(new Engineer ("Sasha", "BigFac", "Software Engineer"));

                            correct = true;
                            break;
                        }
                    case 3:
                        {
                            stack.Push(new Worker ("Morty", "Tesla", "Cleaner"));

                            correct = true;
                            break;
                        }
                    case 4:
                        {
                            stack.Push(new Administration ("Jo"));

                            correct = true;
                            break;
                        }
                    default:
                        {
                            correct = false;
                            Console.WriteLine("Try one more time...");
                            Int32.TryParse(Console.ReadLine(), out className);
                            break;
                        }

                }
            } while (!correct);
            
        }
        
        static void SecondTask()
        {
            Dictionary<Person, Person> dict = new Dictionary<Person, Person>();
            dict = ChooseAction(dict);
            if (dict.Count != 0) CloneDict(dict);
        }

        static void PrintDict(Dictionary<Person,Person> dict)
        {
            if (dict.Count != 0)
            {
                foreach (var item in dict)
                {
                    if (item.Value.GetType().Name == "Worker" && item.Value is Worker worker)
                        Console.WriteLine($"Ключ: Name = {item.Key.FirstName}, Значение: factoryName = {worker.factoryName}, position = {worker.positionName}");
                    else if (item.Value.GetType().Name == "Engineer" && item.Value is Engineer engineer)
                        Console.WriteLine($"Ключ: Name = {item.Key.FirstName}, Значение: factoryName = {engineer.factoryName}, position = {engineer.positionName}");
                    else if (item.Value.GetType().Name == "Administration" && item.Value is Administration admin)
                        Console.WriteLine($"Ключ: Name = {item.Key.FirstName}, Значение: Name = {admin.FirstName}, position = Admin");
                }
            }
            else Console.WriteLine("Словарь пустой!");
        }

        static void DelElems(Dictionary<Person,Person> dict)
        {
            Console.Write("Введите имя работника (ключ) для его удаления из словаря: "); string workerName = Console.ReadLine();
            int cnt = 0;
            foreach(var item in dict)
            {
                if (item.Key.FirstName == workerName) { dict.Remove(item.Key); ++cnt; }
            }
            Console.WriteLine($"Всего удалено объектов с именем {workerName}: {cnt}");
        }
        static void AddElem(Dictionary<Person,Person> dict)
        {
            Console.WriteLine("Введите название класса для добавления:\n1.Worker\n2.Engineer\n3.Administration\n4.Назад");
            Int32.TryParse(Console.ReadLine(), out int className);
            switch (className)
            {
                case 1:
                    {
                        if(!dict.TryAdd(new Person ("Ben"), new Worker ("Ben","Tesla","Dvornik")))
                        {
                            Console.WriteLine("Такой объект уже есть. Попробуй еще раз!");
                            AddElem(dict);
                        }
                        
                       
                        
                        break;
                    }
                case 2:
                    {
                        if(!dict.TryAdd(new Person ("John"), new Engineer ("John","Big Inc.","Software Engineer" )))
                        {
                            Console.WriteLine("Такой объект уже есть. Попробуй еще раз!");
                            AddElem(dict);
                        }

                       
                        break;
                    }
                case 3:
                    {
                        if (!dict.TryAdd(new Person ("Morty"), new Administration ("Morty" )))
                        {
                            Console.WriteLine("Такой объект уже есть. Попробуй еще раз!");
                            AddElem(dict);
                        }
                        
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Успешный выход!");
                        break;
                    }
                
                default:
                    {
                        Console.WriteLine("Try one more time...");
                        AddElem(dict);
                        break;
                    }

            }
        }

        static void FirstQuery(Dictionary<Person,Person> dict)
        {
            Console.WriteLine("Задайте название класса:");
            string className = Console.ReadLine();
            int cnt = 0;
            foreach (var item in dict)
            {
                if (item.Value.GetType().Name == className) ++cnt;
            }
            if (cnt == 0) Console.WriteLine($"Объектов класса {className} не найдено!");
            else Console.WriteLine($"Объектов класса {className}: {cnt}");
        }

        static void SecondQuery(Dictionary<Person,Person> dict)
        {
            Console.WriteLine("Задайте название класса:");
            string className = Console.ReadLine();
            int cnt = 0;
            foreach (var item in dict)
            {
                if (item.Value.GetType().Name == className) Console.WriteLine($"{++cnt}. {item.Key.FirstName}, class: {item.Value.GetType().Name}"); ;
            }
            if (cnt == 0) Console.WriteLine($"Объектов класса {className} не найдено!");
        }

        static void ThirdQuery(Dictionary<Person,Person> dict)
        {
            int max = 0;
            foreach (var item in dict)
            {
                if (item.Key.FirstName.Length > max) max = item.Key.FirstName.Length;
            }

            int cnt = 0;
            foreach (var item in dict)
            {
                if (item.Key.FirstName.Length == max) Console.WriteLine($"{++cnt}.{item.Value.GetType().Name}, FirstName = {item.Key.FirstName}, Length = {item.Key.FirstName.Length}");
            }
            if (cnt == 0) Console.WriteLine("Словарь пустой!");
        }

        static Dictionary<Person,Person> SortDict(Dictionary<Person,Person> dict)
        {
            SortedDictionary<Person, Person> newDict = new SortedDictionary<Person, Person>();
            foreach(var item in dict)
                newDict.TryAdd(item.Key, item.Value);

            if (dict.Count != 0) Console.WriteLine("Словарь отсортирован!");
            else Console.WriteLine("Словарь пустой!");
            return new Dictionary<Person, Person>(newDict);
        }

        static void SearchInDict(Dictionary<Person,Person> dict)
        {
            Console.WriteLine("Введите имя, по которому хотите найти сотрудников:");
            string name = Console.ReadLine();
            
            if (dict.ContainsKey(new Person (name)))
            {
                Console.WriteLine("\tСотрудник успешно найден:");
                if (dict[new Person(name)] is Worker worker) Console.WriteLine($"FirstName = {worker.FirstName}, factoryName = {worker.factoryName}, position = {worker.positionName}");
                else if (dict[new Person(name)] is Engineer engineer) Console.WriteLine($"FirstName = {engineer.FirstName}, factoryName = {engineer.factoryName}, position = {engineer.positionName}");
                else if (dict[new Person(name)] is Administration admin) Console.WriteLine($"FirstName = {admin.FirstName}, position = Admin");

            }
            else Console.WriteLine($"Сотрудников с именем {name} не найдено!");
        }

        static void CloneDict(Dictionary<Person,Person> dict)
        {
            Dictionary<Person, Person> newDict = new Dictionary<Person, Person>(dict.Count);
            foreach(var item in dict)
                newDict.Add((Person)item.Key.Clone(), (Person)item.Value.Clone());
            
            newDict.Remove(new Person("John"));
            Console.WriteLine("\tdict:");
            PrintDict(dict);
            Console.WriteLine("\tnewDict(клонированный):");
            PrintDict(newDict);
            
        }
        
        static Dictionary<Person, Person> ChooseAction(Dictionary<Person, Person> dict)
        {
            //Console.WriteLine(stack.Count);
            Console.WriteLine("Введите действие:\n1.Добавление\n2.Удаление\n3.Количество объектов заданного класса\n4.Вывести имена объектов заданного класса\n5.Вывести классы с самым длинным именем объектов\n6.Напечатать словарь\n7.Отсортировать словарь\n8.Найти значение в словаре\n9. Назад");
            
            Int32.TryParse(Console.ReadLine(), out int variant);
             

            switch (variant)
            {
                case 1:
                    {
                        AddElem(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 2:
                    {
                        DelElems(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 3:
                    {
                        FirstQuery(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 4:
                    {
                        SecondQuery(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 5:
                    {
                        ThirdQuery(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 6:
                    {
                        PrintDict(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 7:
                    {
                        dict = SortDict(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 8:
                    {
                        SearchInDict(dict);
                        ChooseAction(dict);
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Успешный выход!");
                        break;
                        
                    }
                default:
                    {
                        Console.WriteLine("Try one more time...");
                        break;
                    }


            }


            return dict;

        }

        static Stack<Person> RemoveStackPerson(Stack<Person> stack, Person toDelete)
        {

            Stack<Person> newStack = new Stack<Person>();
            
            if (stack.Count != 0)
            {
                foreach (Person item in stack)
                {
                    if (item.FirstName != toDelete.FirstName) newStack.Push(new Person(item.FirstName));
                }
            }
            else Console.WriteLine("Стэк пустой, нечего удалять!");

            return newStack;
        }

        static Stack<string> RemoveStackString(Stack<string> stack, string toDelete)
        {
            Stack<string> newStack = new Stack<string>();

            if (stack.Count != 0)
            {
                foreach (string item in stack)
                {
                    if (item != toDelete) newStack.Push(item);
                }
            }
            else Console.WriteLine("Стэк пустой, нечего удалять!");

            return newStack;
        }

        static void RemoveDictPerson(Dictionary<Person,Worker> dict, Person toDelete)
        {
            if (dict.Count != 0) dict.Remove(toDelete);
            else Console.WriteLine("Словарь пустой!");
        }

        static void RemoveDictString(Dictionary<string, Worker> dict, string toDelete)
        {

            if (dict.Count != 0) dict.Remove(toDelete);
            else Console.WriteLine("Словарь пустой!");
        }

        static void AddStackPerson(Stack<Person> stack, Person toInsert)
        {
            stack.Push(toInsert);
        }

        static void AddStackString(Stack<string> stack, string toInsert)
        {
            stack.Push(toInsert);
        }

        static void AddDictPerson(Dictionary<Person, Worker> dict, Worker value)
        {
            if (!dict.TryAdd(value.BasePerson, value)) Console.WriteLine("Такое значение уже есть!");
        }

        static void AddDictString(Dictionary<string, Worker> dict, Worker value)
        {
            if (!dict.TryAdd(value.FirstName, value)) Console.WriteLine("Такое значение уже есть!");
        }

        static void ThirdTaskMenu(TestCollections collset)
        {
            Console.WriteLine("1. Добавить в стэк с Person\n2. Добавить в стэк со string\n3. Удалить из стэка с Person\n4. Удалить из стэка со string\n5. Добавить в словарь с ключом Person\n6. Добавить в словарь с ключом string\n7. Удалить из словаря с ключом Person\n8. Удалить из словаря с ключом string\n9. Замеры на 1000 эл-тах\n10. Назад");
            Int32.TryParse(Console.ReadLine(), out int task);
            switch (task)
            {
                case 1:
                    {
                        Console.Write("Введите желаемое имя объекта Person для добавления: ");
                        AddStackPerson(collset.StackPerson, new Person(Console.ReadLine()));
                        Console.WriteLine("Измененный стэк:");
                        foreach (Person item in collset.StackPerson) Console.WriteLine(item.FirstName);
                        
                        
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Введите желаемое имя (строка) для добавления: ");
                        AddStackString(collset.StackString, Console.ReadLine());
                        
                        Console.WriteLine("Измененный стэк:");
                        foreach (string item in collset.StackString) Console.WriteLine(item);
                        
                        
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 3:
                    {
                        Console.Write("Введите желаемое имя объекта Person для удаления: ");
                        collset.StackPerson = RemoveStackPerson(collset.StackPerson, new Person(Console.ReadLine()));
                        if (collset.StackPerson.Count != 0)
                        {
                            Console.WriteLine("Измененный стэк:");
                            foreach (Person item in collset.StackPerson) Console.WriteLine(item.FirstName);
                        }
                        
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 4:
                    {
                        Console.Write("Введите желаемое имя (строка) для удаления: ");
                        collset.StackString = RemoveStackString(collset.StackString, Console.ReadLine());
                        if (collset.StackString.Count != 0)
                        {
                            Console.WriteLine("Измененный стэк:");
                            foreach (string item in collset.StackString) Console.WriteLine(item);
                        }
                        
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 5:
                    {
                        Console.Write("Введите желаемые имя, название завода, должность объекта Worker для добавления (Ключ - имя (баз. класс)): ");
                        
                        AddDictPerson(collset.DictPerson, new Worker(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                        Console.WriteLine("Измененный словарь:");
                        foreach (var item in collset.DictPerson) Console.WriteLine($"Key: {item.Key.FirstName} Value: {item.Value.factoryName}, {item.Value.positionName}");
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 6:
                    {
                        Console.Write("Введите желаемые имя, название завода, должность объекта Worker для добавления: ");

                        AddDictString(collset.DictString, new Worker(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                        Console.WriteLine("Измененный словарь:");
                        foreach (var item in collset.DictString) Console.WriteLine($"Key: {item.Key} Value: {item.Value.factoryName}, {item.Value.positionName}");
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 7:
                    {
                        Console.Write("Введите желаемое имя объекта Person для удаления: ");
                        RemoveDictPerson(collset.DictPerson, new Person(Console.ReadLine()));
                        if (collset.DictPerson.Count != 0)
                        {
                            Console.WriteLine("Измененный словарь:");
                            foreach (var item in collset.DictPerson) Console.WriteLine($"Key: {item.Key.FirstName} Value: {item.Value.factoryName}, {item.Value.positionName}");
                        }
                        
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 8:
                    {
                        Console.Write("Введите желаемое имя объекта (строка) для удаления: ");
                        RemoveDictString(collset.DictString, Console.ReadLine());
                        if (collset.DictString.Count != 0)
                        {
                            Console.WriteLine("Измененный словарь:");
                            foreach (var item in collset.DictPerson) Console.WriteLine($"Key: {item.Key} Value: {item.Value.factoryName}, {item.Value.positionName}");
                        }
                        
                        ThirdTaskMenu(collset);
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("Успешный выход!");
                        break;
                    }
                case 9:
                    {
                       
                        collset.DictPerson.Clear();
                        collset.DictString.Clear();
                        collset.StackPerson.Clear();
                        collset.StackString.Clear();
                        for (int i = 0; i < 1000; ++i)
                        {
                            collset.DictPerson.Add(new Person($"Ben{i + 1}"), new Worker($"Ben{i + 1}", "Fac", "Position"));
                            collset.DictString.Add($"Ben{i + 1}", new Worker($"Ben{i + 1}", "Fac", "Position"));
                            collset.StackPerson.Push(new Person($"Ben{i + 1}"));
                            collset.StackString.Push($"Ben{i + 1}");
                        }
                        Stopwatch stopwatch = new Stopwatch();

                        Console.WriteLine("Сравнение скорости Dictionary<Person,Worker> and Dictionary<string,Worker>:"); // DICTS

                        DictPersonSearch(collset.DictPerson, new Worker("Ben1", "Fac", "Position"), stopwatch);

                        DictStringSearch(collset.DictString, new Worker("Ben1", "Fac", "Position"), stopwatch);

                        
                        DictPersonSearch(collset.DictPerson, new Worker("Ben500", "Fac", "Position"), stopwatch);

                        DictStringSearch(collset.DictString, new Worker("Ben500", "Fac", "Position"), stopwatch);

                        
                        DictPersonSearch(collset.DictPerson, new Worker("Ben1000", "Fac", "Position"), stopwatch);

                        DictStringSearch(collset.DictString, new Worker("Ben1000", "Fac", "Position"), stopwatch);


                        DictPersonSearch(collset.DictPerson, new Worker("Ben1001", "Fac", "Position"), stopwatch);

                        DictStringSearch(collset.DictString, new Worker("Ben1001", "Fac", "Position"), stopwatch);

                        Console.WriteLine("\nСравнение Stack<Person> and Stack<string>:\n"); // STACKS

                        StackPersonSearch(collset.StackPerson, "Ben1", stopwatch);

                        StackStringSearch(collset.StackString, "Ben1", stopwatch);
                        

                        StackPersonSearch(collset.StackPerson, "Ben500", stopwatch);

                        StackStringSearch(collset.StackString, "Ben500", stopwatch);
                        

                        StackPersonSearch(collset.StackPerson, "Ben1000", stopwatch);

                        StackStringSearch(collset.StackString, "Ben1000", stopwatch);


                        StackPersonSearch(collset.StackPerson, "Ben1001", stopwatch);

                        StackStringSearch(collset.StackString, "Ben1001", stopwatch);

                        Console.WriteLine();
                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Try one more time...");
                        ChooseTask();
                        break;
                    }
            }
        }
        static void DictStringSearch(Dictionary<string,Worker> dict, Worker worker, Stopwatch stopwatch)
        {
            bool found = true;
            stopwatch.Restart();
            if (!dict.ContainsKey(worker.BasePerson.ToString()))  found = false; 
            stopwatch.Stop();
            Console.WriteLine($"(DictString.Key){worker.BasePerson.FirstName}: " + stopwatch.ElapsedTicks + " Found: " + found);

            found = true;
            stopwatch.Restart();
            if (!dict.ContainsValue(worker)) found = false ;
            stopwatch.Stop();
            Console.WriteLine($"(DictString.Value){worker.FirstName}: " + stopwatch.ElapsedTicks + " Found: " + found);
        }
        static void DictPersonSearch(Dictionary<Person,Worker> dict, Worker worker, Stopwatch stopwatch)
        {
            bool found = true;
            stopwatch.Restart();
            if (!dict.ContainsKey(worker.BasePerson)) found = false;
            stopwatch.Stop();
            Console.WriteLine($"(DictPerson.Key){worker.BasePerson.FirstName}: " + stopwatch.ElapsedTicks + " Found: " + found);

            found = true;
            stopwatch.Restart();
            if (!dict.ContainsValue(worker)) found = false;
            stopwatch.Stop();
            Console.WriteLine($"(DictPerson.Value){worker.FirstName}: " + stopwatch.ElapsedTicks + " Found: " + found);
        }
        static void StackStringSearch(Stack<string> stack, string place, Stopwatch stopwatch)
        {
            bool found = true;
            stopwatch.Restart();
            if (!stack.Contains(place)) found = false;
            stopwatch.Stop();
            Console.WriteLine($"(StackString){place}: " + stopwatch.ElapsedTicks + " Found: " + found);
        }
        static void StackPersonSearch (Stack<Person> stack, string place, Stopwatch stopwatch)
        {
            bool found = true;
            stopwatch.Restart();
            if (!stack.Contains(new Person(place))) found = false;
            stopwatch.Stop();
            Console.WriteLine($"(StackPerson){place}: " + stopwatch.ElapsedTicks + " Found: " + found);
        }

        static void ThirdTask()
        {
            TestCollections collSet = new TestCollections(5);
            ThirdTaskMenu(collSet);

            
        }
        static void ChooseTask()
        {
            Console.WriteLine("1. Первое задание (Стэк)\n2. Второе задание (Словарь)\n3. Третье задание\n4. Выход");
            Int32.TryParse(Console.ReadLine(), out int task);
            switch(task)
            {
                case 1:
                    {
                        FirstTask();
                        ChooseTask();
                        break;
                    }
                case 2:
                    {
                        SecondTask();
                        ChooseTask();
                        break;
                    }
                case 3:
                    {
                        ThirdTask();
                        ChooseTask();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Успешный выход!");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Try one more time...");
                        ChooseTask();
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            ChooseTask();
           
        }
    }
}
