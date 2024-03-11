using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using BLogic;

namespace Laba1
{
    /// <summary>
    /// Форма с гистограммой
    /// </summary>
    public partial class Form4 : Form
    {
        /// <summary>
        /// Объект класса основной формы
        /// </summary>
        Form1 _form1 { set; get; }
        /// <summary>
        /// Форма с гистограммой
        /// </summary>
        /// <param name="form1">Основная форма, содержащая лист студентов,необходимый для рисования гистограммы</param>
        public Form4(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            DrawHystogramm();
        }
        /// <summary>
        /// Действия, происходящее при загрузке гистограммы
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Функция, рисующая гистограмму распределения студентов по специальностям
        /// </summary>
        private void DrawHystogramm()
        {
            GraphPane pane = zg1.GraphPane; // Получим панель для рисования
            pane.CurveList.Clear(); // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.YAxis.Title.Text = "Количество студентов"; //Подписываем ось Oy
            pane.XAxis.Title.Text = "Специальность"; //Подписываем ось Ox
            List<string> names = new List<string>(); // Подписи под столбцами
            List<double> values = new List<double>(); // Высота столбцов
            // Заполним данные
            foreach (var person in _form1.logic.HystogrammWF())
            {
                string s=person.Key;
                names.Add(s);
                values.Add(person.Value);
            }
            double[] doubles = new double[values.Count];
            string[] strings = new string[names.Count];
            //копируем листы с данными в массивы, потому что так требует ZedGraph
            for(int i=0;i<values.Count;i++)
            {
                doubles[i]=values[i];
            }
            for (int i = 0; i < names.Count; i++)
            {
                strings[i] = names[i];
            }
            // Создадим кривую-гистограмму
            // Первый параметр - название кривой для легенды
            // Второй параметр - значения для оси X, т.к. у нас по этой оси будет идти текст, а функция ожидает тип параметра double[], то пока передаем null
            // Третий параметр - значения для оси Y
            // Четвертый параметр - цвет
            BarItem curve = pane.AddBar("Распределение студентов по специальностям", null, doubles, Color.Blue);
            pane.Title.Text = "Распределение студентов по специальностям"; //Изменение заголовка
            pane.XAxis.Type = AxisType.Text; // Настроим ось X так, чтобы она отображала текстовые данные
            pane.XAxis.Scale.TextLabels = strings; // Уставим для оси наши подписи
            zg1.AxisChange(); // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            zg1.Invalidate(); // Обновляем график
        }
        /// <summary>
        /// Действия,происходящее при загрузке формы с гистограммой
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void Form4_Load(object sender, EventArgs e)
        {
        }
    }
}
