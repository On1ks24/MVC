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
    /// Форма добавления студента
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// Объект класса основной формы
        /// </summary>
        Form1 _form1 { set;get;}
        /// <summary>
        /// Форма добавления студента
        /// </summary>
        /// <param name="form1">Основная форма, содержащая лист студентов</param>
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }
        /// <summary>
        /// Кнопка добавления студента
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void button1_Click(object sender, EventArgs e)
        {
            _form1.logic.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text);
            Close();
            _form1.logic.SaveToFile();
        }
    }
}
