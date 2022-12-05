using Microsoft.Win32;
using PhotoCenter.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace PhotoCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private DateTime dateStart;
        private DateTime dateEnd;

        public ReportPage()
        {
            InitializeComponent();
        }

        async void WordExport(string savePath, ReportViewModel reportViewModel)
        {


            await Task.Run(() =>
            {


                Word.Application application = new Word.Application();
                application.Visible = true;

                try
                {
                    object missing = Type.Missing;
                    Word.Document document = application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                    Word.Paragraph paragraph = document.Paragraphs.Add(ref missing);
                    paragraph.Range.Text = $"Отчет c {dateStart.ToString("dd.MM.yyyy")} по {dateEnd.ToString("dd.MM.yyyy")}";
                    paragraph.Range.Font.Name = "Times New Roman";
                    paragraph.Range.Font.Size = 16;
                    paragraph.Range.Font.Bold = 1;
                    paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    paragraph.Range.InsertParagraphAfter();
                    //Таблица
                    paragraph.Range.Font.Size = 12;
                    paragraph.Range.Font.Bold = 0;
                    Word.Table table = document.Tables.Add(paragraph.Range, reportViewModel.NameWorker.Count + 1, 2, ref missing);
                    table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    //Шапка таблицы
                    table.Rows[1].Range.Font.Bold = 1;
                    table.Rows[1].Shading.BackgroundPatternColor = Word.WdColor.wdColorBlue;
                    table.Rows[1].Cells[1].Range.Text = "Сотрудник";
                    table.Rows[1].Cells[2].Range.Text = "Количество заказов";

                    for (int i = 2; i <= table.Rows.Count; i++)
                    {
                        for (int j = 1; j <= table.Columns.Count; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    table.Rows[i].Cells[j].Range.Text = reportViewModel.NameWorker[i - 2];
                                    break;
                                case 2:
                                    table.Rows[i].Cells[j].Range.Text = reportViewModel.CountOrder[i - 2].ToString();
                                    break;
                            }
                        }
                    }


                    //Диаграмма
                    paragraph.Range.InsertParagraphAfter();
                    Word.InlineShape inlineShape = document.InlineShapes.AddChart2(-1, Microsoft.Office.Core.XlChartType.xlPie, paragraph.Range, ref missing);
                    dynamic chartWb = inlineShape.Chart.ChartData.Workbook;
                    dynamic workSheet = chartWb.Sheets["Лист1"];
                    dynamic dataTable = workSheet.ListObjects["Таблица1"];
                    dataTable.DataBodyRange.ClearContents();
                    workSheet.Range["B1"].Value2 = "Прием заказов";
                    for (int i = 0; i < reportViewModel.NameWorker.Count; i++)
                    {
                        workSheet.Range[$"A{i + 2}"].Value2 = reportViewModel.NameWorker[i];
                        workSheet.Range[$"B{i + 2}"].Value2 = reportViewModel.NameWorker[i].ToString();
                    }
                    dataTable.Range.Resize(reportViewModel.NameWorker.Count + 1, 2);

                    //Информация о самом популярном объекте аренды
                    paragraph.Range.InsertParagraphAfter();
                    paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    paragraph.Range.Text = $"Самый активный сотрудник: {reportViewModel.FullName}" +
                    $"(колличество заказов {reportViewModel.ActiveWorker.Order.Count})";

                    //Сохранение
                    document.SaveAs2(savePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing
                        , missing, missing, missing, missing, missing);
                    document.Close(null, null, null);
                    application.Quit(null, null, null);
                    MessageBox.Show("Отчет сохранен успешно!");


                }
                catch(Exception e)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show(e.Message);
                    });
                    application.Quit(null, null, null);
                }
                this.Dispatcher.Invoke(() =>
                {
                    plug.Visibility = Visibility.Hidden;
                });

            });
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            if (DateStart.SelectedDate != null)
            {
                dateStart = DateStart.SelectedDate.Value.Date;
            }
            else
            {
                dateStart = DateTime.Now.Date;
            }

            if (DateEnd.SelectedDate != null)
            {
                dateEnd = DateEnd.SelectedDate.Value.Date;
            }
            else
            {
                dateEnd = DateTime.Now.Date;
            }

            if (dateStart > dateEnd)
            {
                MessageBox.Show("Данный диапазон дат невозможен!");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Doc Files (*.doc)|*.doc";
                if (saveFileDialog.ShowDialog() == true)
                {
                    WordExport(saveFileDialog.FileName, DataContext as ReportViewModel);
                    plug.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
