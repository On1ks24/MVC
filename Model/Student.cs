using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    /// <summary>
    /// Класс студента
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Id студента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя студента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Специальность студента
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// Группа студента
        /// </summary>
        public string Group { get; set; }
    }
}
