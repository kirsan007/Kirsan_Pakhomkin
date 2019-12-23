using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Laba5;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Список слов
        /// </summary>
        
        List<string> lst = new List<string>();
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fldlg = new OpenFileDialog();
            fldlg.Filter = "Текстовый файл |*.txt";
            if (fldlg.ShowDialog() == DialogResult.OK)
            {
                Stopwatch time = new Stopwatch();
                time.Start();
                string text = File.ReadAllText(fldlg.FileName);
                char[] separ = { '\n', ' ', '.', ',', '\t', '/', '?' };
                string[] words = text.Split(separ);
                foreach(string word in words)
                {
                    string wrd = word.Trim();
                    if (!lst.Contains(wrd)) lst.Add(wrd);
                }
                time.Stop();
                this.textBoxReadTime.Text = time.Elapsed.ToString();
                this.textBoxCount.Text = lst.Count().ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл.");
            }
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string word = textBoxSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(word) && lst.Count > 0)
            {
                word = word.ToUpper();
                List<string> res = new List<string>();
                
                    Stopwatch t = new Stopwatch();
                    t.Start();
                    foreach (string wrd in lst)
                    {
                        if (wrd.ToUpper().Contains(word))
                        {
                            res.Add(wrd);
                        }
                    }
                    t.Stop();
                    this.textBoxTimeSearch.Text = t.Elapsed.ToString();
                    this.listBoxResult.BeginUpdate();
                    this.listBoxResult.Items.Clear();

                    foreach (string wrd in res)
                    {
                        this.listBoxResult.Items.Add(wrd);
                    }
                    this.listBoxResult.EndUpdate();
                
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }

        private void LabelTimeSearch_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxTimeSearch_TextChanged(object sender, EventArgs e)
        {

        }

        public static List<ParallelSearchResult> ArrayThreadTask(object paramObj)
        {
            ParallelSearchThreadParam param = (ParallelSearchThreadParam)paramObj;
            //Слово для поиска в верхнем регистре 
            string wordUpper = param.wordPattern.Trim().ToUpper();
            //Результаты поиска в одном потоке 
            List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
            //Перебор всех слов во временном списке данного потока 
            foreach (string str in param.tempList)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = Levenstain.Distance(str.ToUpper(), wordUpper);
                //Если расстояние меньше порогового, то слово добавляется в результат
                if (dist <= param.maxDist)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                    {
                        word = str,
                        dist = dist,
                        ThreadNum = param.ThreadNum
                    };
                    Result.Add(temp);
                }
            }
            return Result;

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            //Слово для поиска 
            string word = this.textBoxSearch.Text.Trim();
            //Если слово для поиска не пусто 
            if (!string.IsNullOrWhiteSpace(word) && lst.Count > 0)
            {
                int maxDist;
                if (!int.TryParse(this.textBoxDist.Text.Trim(), out maxDist))
                {
                    MessageBox.Show("Необходимо указать максимальное расстояние"); return;
                }
                if (maxDist < 1 || maxDist > 5)
                {
                    MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 1 до 5");
                    return;
                }
                int ThreadCount;
                if (!int.TryParse(this.textBoxThreadCount.Text.Trim(), out ThreadCount))
                {
                    MessageBox.Show("Необходимо указать количество потоков"); //потоки, на которые разделяется массив слов исходного файла
                    return;
                }
                Stopwatch timer = new Stopwatch();
                timer.Start();
                // Начало параллельного поиска 
                //Результирующий список 
                List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
                //Деление списка на фрагменты для параллельного запуска в потоках
                List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, lst.Count, ThreadCount);
                int count = arrayDivList.Count;
                //Количество потоков соответствует количеству фрагментов массива
                //Task - класс, используюшийся для параллельного поиска (задача)
                Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count];
                //Запуск потоков 
                for (int i = 0; i < count; i++)
                {
                    //Создание временного списка, чтобы потоки не работали параллельно с одной коллекцией
                    List<string> tempTaskList = lst.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min);
                    tasks[i] = new Task<List<ParallelSearchResult>>(
                        ArrayThreadTask,
                        new ParallelSearchThreadParam()
                        {
                            tempList = tempTaskList,
                            maxDist = maxDist,
                            ThreadNum = i,
                            wordPattern = word
                        });
                    //Запуск потока 
                    tasks[i].Start();
                }
                //ожидание завершения работы всех потоков, чтобы получить результаты поиска
                Task.WaitAll(tasks);
                timer.Stop();
                //Объединение результатов
                for (int i = 0; i < count; i++)
                { Result.AddRange(tasks[i].Result); }
                //------------------------------------------------- 
                // Завершение параллельного поиска 
                //-------------------------------------------------
                timer.Stop();
                //Вывод результатов
                //Время поиска 
                this.textBoxApproxTime.Text = timer.Elapsed.ToString();
                //Вычисленное количество потоков
                this.textBoxThreadCountAll.Text = count.ToString();
                //Начало обновления списка результатов
                this.listBoxResult.BeginUpdate();
                //Очистка списка 
                this.listBoxResult.Items.Clear();
                //Вывод результатов поиска 
                foreach (var x in Result)
                {
                    string temp = x.word + "(расстояние=" + x.dist.ToString() + " поток=" + x.ThreadNum.ToString() + ")";
                    this.listBoxResult.Items.Add(temp);
                }
                //Окончание обновления списка результатов 
                this.listBoxResult.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");

            }
        }
        /// <summary> 
        /// Результаты параллельного поиска 
        /// </summary> 
        //содержит входной массив слов и слово для поиска, максимальное расстояние для нечеткого поиска и номер потока
        public class ParallelSearchResult
        {
            /// <summary> 
            /// Найденное слово 
            /// </summary>
            public string word { get; set; }
            /// <summary> 
            /// Расстояние 
            /// </summary>
            public int dist { get; set; }
            /// <summary> 
            /// Номер потока 
            /// </summary> 
            public int ThreadNum { get; set; }

        }
        /// <summary> 
        /// Параметры которые передаются в поток для параллельного поиска 
        /// </summary> 
        class ParallelSearchThreadParam
        {
            /// <summary> 
            /// Массив для поиска 
            /// </summary> 
            public List<string> tempList { get; set; }
            /// <summary> 
            /// Слово для поиска 
            /// </summary>
            public string wordPattern { get; set; }
            /// <summary>
            /// Максимальное расстояние для нечеткого поиска 
            /// </summary> 
            public int maxDist { get; set; }
            /// <summary> 
            /// Номер потока 
            /// </summary>
            public int ThreadNum { get; set; }


        }
        /// <summary> 
        /// Хранение минимального и максимального значений диапазона 
        /// </summary>
        public class MinMax
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public MinMax(int pmin, int pmax)
            {
                this.Min = pmin;
                this.Max = pmax;
            }
        }
        //Для деления массива на подмассивы
        public static class SubArrays
        {
            /// <summary> 
            /// Деление массива на последовательности(подмассивы) 
            /// </summary> 
            /// <param name="beginIndex">Начальный индекс массива</param> 
            /// <param name="endIndex">Конечный индекс массива</param> 
            /// <param name="subArraysCount">Требуемое количество подмассивов</param> 
            /// <returns>Список пар с индексами подмассивов</returns>
            public static List<MinMax> DivideSubArrays(int beginIndex, int endIndex, int subArraysCount)
            {
                //Результирующий список пар с индексами подмассивов 
                List<MinMax> result = new List<MinMax>();
                //Если число элементов в массиве слишком мало для деления, то возвращается массив целиком 
                if ((endIndex - beginIndex) <= subArraysCount)
                {
                    result.Add(new MinMax(0, (endIndex - beginIndex)));
                }
                else
                {
                    //Размер подмассива 
                    int delta = (endIndex - beginIndex) / subArraysCount;
                    //Начало отсчета 
                    int currentBegin = beginIndex;
                    //Пока размер подмассива укладывается в оставшуюся последовательность
                    while ((endIndex - currentBegin) >= 2 * delta)
                    {
                        //Формируем подмассив на основе начала последовательности
                        result.Add(new MinMax(currentBegin, currentBegin + delta));
                        //Сдвигаем начало последовательности вперед на размер подмассива 
                        currentBegin += delta;
                    }
                    //Оставшийся фрагмент массива
                    result.Add(new MinMax(currentBegin, endIndex));
                }
                //Возврат списка результатов
                return result;
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Имя файла отчета
            string TempReportFileName = "Report_" +
           DateTime.Now.ToString("dd_MM_yyyy_hhmmss");
            //Диалог сохранения файла отчета
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".html";
            fd.Filter = "HTML Reports|*.html";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string ReportFileName = fd.FileName;
                //Формирование отчета
                StringBuilder b = new StringBuilder();
                b.AppendLine("<html>");
                b.AppendLine("<head>");

                b.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset = UTF - 8'/>");
                b.AppendLine("<title>" + "Отчет: " + ReportFileName + "</title>");
                b.AppendLine("</head>");
                b.AppendLine("<body>");
                b.AppendLine("<h1>" + "Отчет: " + ReportFileName + "</h1>");
                b.AppendLine("<table border='1'>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время чтения из файла</td>");
                b.AppendLine("<td>" + this.textBoxReadTime.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Количество уникальных слов в файле</td>");
                b.AppendLine("<td>" + this.textBoxCount.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Слово для поиска</td>");
                b.AppendLine("<td>" + this.textBoxSearch.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Максимальное расстояние для нечеткого поиска </ td > ");
                b.AppendLine("<td>" + this.textBoxDist.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время четкого поиска</td>");
                b.AppendLine("<td>" + this.textBoxTimeSearch.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время нечеткого поиска</td>");
                b.AppendLine("<td>" + this.textBoxApproxTime.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr valign='top'>");
                b.AppendLine("<td>Результаты поиска</td>");
                b.AppendLine("<td>");
                b.AppendLine("<ul>");
                foreach (var x in this.listBoxResult.Items)
                {
                    b.AppendLine("<li>" + x.ToString() + "</li>");
                }
                b.AppendLine("</ul>");
                b.AppendLine("</td>");
                b.AppendLine("</tr>");
                b.AppendLine("</table>");
                b.AppendLine("</body>");
                b.AppendLine("</html>");
                //Сохранение файла
                File.AppendAllText(ReportFileName, b.ToString());
                MessageBox.Show("Отчет сформирован. Файл: " + ReportFileName);
            }
        }
    }
}

