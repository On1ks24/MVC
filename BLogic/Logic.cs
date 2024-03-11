using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLogic
{   
    /// <summary>
    /// Этот класс отвечает за логику работы со студентами и их списком.
    /// </summary>
    public class Logic
    {
        /// <summary>
        /// Переменная для автоматического присваивания Id студентам
        /// </summary>
        int id = 1;
        /// <summary>
        /// Этот лист хранит в себе всех студентов.
        /// </summary>
        public List<Student> Students { get; set; }=new List<Student>();
        /// <summary>
        /// Эта функция добавляет студента в лист студентов.
        /// </summary>
        /// <param name="id">Id студента</param>
        /// <param name="name">Имя студента</param>
        /// <param name="speciality">Специальность студента</param>
        /// <param name="group">Группа студента</param>
        public void AddStudent(string name, string speciality, string group)
        {
            Students.Add(new Student()
            {
                Id = id,
                Name = name,
                Speciality = speciality,
                Group = group
            });
            id++;
        }
        /// <summary>
        /// Эта функция отвечает за удаление студента из списка студентов.
        /// </summary>
        /// <param name="id">Id студента</param>
        public void DeleteStudent(int id)
        {
            foreach(Student student in Students)
            {
                if (student.Id == id)
                {
                    Students.Remove(student);
                    break;
                }    
            }
        }
        /// <summary>
        /// Эта функция отвечает за создание списка всех специальностей.Необходима для реализации гистограммы в windows form
        /// </summary>
        /// <returns>Лист всех спецальностей, на которые зачислены студенты</returns>
        public List<string> Specialities()
        {
            List<string> specialities = new List<string>();
            foreach (Student s in Students)
            {
                specialities.Add(s.Speciality);
            }
            return specialities;
        }
        /// <summary>
        /// Эта функция отвечает за реализацию гистограммы в windows form.
        /// </summary>
        /// <returns>Словарь со всеми специальностями и количеством студентов,зачисленных на эту специальность</returns>
        public Dictionary<string, int> HystogrammWF() //функция для гистограммы в windows form
        {
            List<string> special = Specialities();
            Dictionary<string, int> result=special.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            return result;
        }
        /// <summary>
        /// Эта функция отвечает за реализацию вывода всех студентов.
        /// </summary>
        /// <returns>Лист с именами, специальностями и группами студентов</returns>
        public List <string> View()
        {
            List<string> s = new List<string>();
            foreach(Student student in Students)
            {
                s.Add(student.Id.ToString());
                s.Add(student.Name);
                s.Add(student.Speciality);
                s.Add(student.Group);
            }
            return s;
        }
        /// <summary>
        /// Эта функция отвечает за подгрузку студентов из txt файла в список студентов внутри логики
        /// </summary>
        public async void Load()
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\sarae\\source\\repos\\semestr3\\c#\\Laba1\\Students.txt"))
            {
                string text = await reader.ReadToEndAsync();
                string[] words = text.Split(new char[] { '\n' }); //Разделяем содержимое txt файла на строки
                foreach (string w in words)
                {
                    string[] words2 = w.Split(new char[] { ',' }); //Разделяем содержимое txt файла по запятым
                    if (words2.Length > 2)
                    {
                        Students.Add(new Student() { Id=id,Name = words2[0], Speciality = words2[1], Group = words2[2] });
                        id++;
                    }
                }
            }
        }
        /// <summary>
        /// Эта функция отвечает за сохранение студентов в txt файл
        /// </summary>
        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\sarae\\source\\repos\\semestr3\\c#\\Laba1\\Students.txt", false))
            {
                string text = string.Empty;
                foreach (var d in Students)
                {
                    text += d.Name + "," + d.Speciality + ","+d.Group+ "\n";
                }
                writer.WriteLine(text);
            }
        }
    }
}
