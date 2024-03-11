using BLogic;
using Model;

Logic logic1 = new Logic();
logic1.Load();
while (true)
{
    Console.WriteLine("Выберите необходимое действие:\n1 - Добавить нового студента\n2 - Удалить студента\n3 - Вывести список всех студентов");
    switch (Console.ReadLine())
    {
        case "1": // Добавить нового студента
            Console.WriteLine("Введите имя студента, которого вы хотите добавить");
            string name = Console.ReadLine();
            Console.WriteLine("Введите специальность студента, которого вы хотите добавить");
            string speciality = Console.ReadLine();
            Console.WriteLine("Введите группу студента, которого вы хотите добавить");
            string group = Console.ReadLine();
            if((name == "") || (speciality=="") || (group==""))
            {
                Console.WriteLine("Невозможно добавить студента с пустыми свойствами");
            }
            else
            {
                logic1.AddStudent(name, speciality, group);
                logic1.SaveToFile();
            }
            break;
        case "2": // Удалить студента
            string s = string.Empty;
            Console.WriteLine("Сначала выводится айди студента, далее его имя, спецаильность и группа");
            for (int i = 0; i < logic1.View().Count(); i = i + 4)
            {
                s = s + logic1.View()[i] + "   " + logic1.View()[i + 1] + " " + logic1.View()[i + 2] + " " + logic1.View()[i + 3] + "\n";
            }
            Console.WriteLine(s);
            int number; // переменная для айди студента
            Console.WriteLine("Введите номер студента, которого вы хотите удалить:\n");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                logic1.DeleteStudent(number);
                logic1.SaveToFile();
            }
            catch
            {
                Console.WriteLine("Вы ввели не номер студента, а что-то другое");
            }
            break;
        case "3": //Вывести всех студентов
            string s1 = string.Empty;
            Console.WriteLine("Сначала выводится айди студента, далее его имя, спецаильность и группа");
            for(int i=0;i<logic1.View().Count();i=i+4)
            {
                s1 = s1 + logic1.View()[i] + "   " + logic1.View()[i+1] + " " + logic1.View()[i+2] + " " + logic1.View()[i+3] + "\n";
            }
            Console.WriteLine(s1);
            break;
    }
}
