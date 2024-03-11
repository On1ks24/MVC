using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLogic;

namespace Laba1
{
    /// <summary>
    /// Основная форма взаимодействия с программой
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Объект класса логики для основной формы взаимодействия с программой
        /// </summary>
        public Logic logic { get; set; }

        /// <summary>
        /// Основная форма взаимодействия с программой
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            logic = new Logic();
            logic.Load();
        }
        /// <summary>
        /// Кнопка добавления студента
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog(this);
        }
        /// <summary>
        /// Кнопка удаления студента
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void button3_Click(object sender, EventArgs e)
        {
            //Обработка исключения, если пользователь пытается удалить невыбранного студента
            try
            {
                int a = dataGridView1.CurrentRow.Index;
                logic.DeleteStudent(a);
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                logic.SaveToFile();
            }
            catch
            {
                MessageBox.Show("Вы не выбрали студента.\nВыбери студента и повторите", "Ошибка");
            }
        }

        /// <summary>
        /// Кнопка для вывода гистограммы
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this);
            form4.ShowDialog();
        }
        /// <summary>
        /// Действия, которые происходят при нажатии на ячейку datagridview
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// Кнопка для вывода студентов в таблицу
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i=0;i<logic.View().Count-1;i=i+4) // цикл по всем свойствам всех студентов(в списке присутсвуют и айди, и имена, и специальности, и группы,поэтому цикл имеет шаг 3).
            {
                dataGridView1.Rows.Add(logic.View()[i+1], logic.View()[i+2], logic.View()[i + 3]);
            }
        }
        /// <summary>
        /// Действия, которые происходят при загрузке основной формы
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
