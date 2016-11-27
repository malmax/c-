using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Dataset;

namespace SwissKnife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void tsbInserteDateTime_Click(object sender, EventArgs e)
        {
            // Вставляем текст в формате rtf
            string rtftext = @"{\rtf1\b " + DateTime.Now.ToString() + @"\b0\par\line}}";
            // Устанавливаем фокус ввода
            rtbNotepad.Focus();
            // Устанавливаем курсор в начало текстового поля    
            rtbNotepad.Select(0, 0);
            // Копируем в буфер обмена данные с указанием типа данных
            Clipboard.SetData(DataFormats.Rtf, (object)rtftext);
            // Вставляем данные из буфера обмена
            rtbNotepad.Paste();
            // Устанавливаем курсор для ввода данных
            rtbNotepad.Select(rtbNotepad.SelectionStart - 1, 0);

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            rtbNotepad.SaveFile(Properties.Settings.Default.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (System.IO.File.Exists(Properties.Settings.Default.FileName))
            {
                rtbNotepad.LoadFile(Properties.Settings.Default.FileName);
                tsslCurrentFile.Text = Properties.Settings.Default.FileName;
            }
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                Properties.Settings.Default.FileName = sfd.FileName;
                Properties.Settings.Default.Save();
                tsslCurrentFile.Text = Properties.Settings.Default.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var weather = new com.cdyne.wsf.Weather();
            var str = weather.GetCityWeatherByZIP(tbZip.Text);
            lblWeather.Text = str.Temperature;
        }

        private void btnKurs_Click(object sender, EventArgs e)
        {
            var info =new ru.cbr.www.DailyInfo();
            DataSet infoXML = info.GetCursOnDate(DateTime.Now);
            infoXML.

                http://www.cbr.ru/scripts/Root.asp?Prtid=DWS


            foreach ( var txt in infoXML.ChildNodes)
            {
                foreach( var val in txt.ChildNodes )
                {
                    Console.WriteLine("{0} - {1}", val.Name, val.innerText);
                }
            }
            XDocument document = XDocument.Parse(infoXML.InnerXml);
            foreach (XElement element in document.Root.Elements())
            {
                Console.WriteLine(element.Name.ToString());

            }
        }

        private void calculateLifeDate_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = dateTimeEndLife.Value - dateTimeStartLife.Value;
            lifeTimeLabel.Text = "Разница в днях между датами = " + timeSpan.ToString();
        }
    }
}
