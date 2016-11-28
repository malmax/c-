using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            System.Data.DataSet infoCur = info.GetCursOnDate(DateTime.Now);
            string[] outToForm = new string[infoCur.Tables[0].Rows.Count];
            //var val_ds = (System.Data.DataSet)info.GetCursDynamic(DateTime.Now, DateTime.Now, "R01235"); //Доллар США

            for(int i =0; i< infoCur.Tables[0].Rows.Count; i++)                
            {
                DataRow row = infoCur.Tables[0].Rows[i];
                outToForm[i] = string.Format("{0}({1}) - {2}", row.ItemArray[0].ToString().Trim(), row.ItemArray[1].ToString().Trim(), row.ItemArray[2].ToString().Trim());
            }
            kursOut.Lines = outToForm;
        }

        private void calculateLifeDate_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = dateTimeEndLife.Value - dateTimeStartLife.Value;
            lifeTimeLabel.Text = "Разница в днях между датами = " + timeSpan.ToString();
        }
    }
}
