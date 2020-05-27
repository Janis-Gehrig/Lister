using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;


namespace ListerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string row;
        string fileName = null;
        string[] words = null;
        string columnRowDefault = null;
        string checkAenderung = null;
        string newText = null;
        int tSize = 9;
        bool control = false;
        private static System.Timers.Timer reloadTimer;
        bool checkTranspo = false;

        DataTable OldTable = new DataTable();




        //----------------Buttons-------------------
        private void Click_syn(object sender, RoutedEventArgs e)
        {
            if (btn_autoSync.Content == FindResource("sync"))
            {
                btn_autoSync.Content = FindResource("nosync");
            }
            else
            {
                btn_autoSync.Content = FindResource("sync");
            }
           
        }

        private void Click_SaveFile(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Transpose(object sender, RoutedEventArgs e)
        {
            if (checkTranspo == false)
            {
                checkTranspo = true;
            }
            else
            {
                checkTranspo = false;
            }
            //dataGridView1.DataSource = null;
            getData();
        }
        private void Click_openSource(object sender, RoutedEventArgs e)
        {
            OpenFile();
            getData();
        }


        private void Clicked_incSize(object sender, RoutedEventArgs e)
        {
            
        }
        private void Clicked_decSize(object sender, RoutedEventArgs e)
        {

        }

        //------------Shortcuts-----------------------------


        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Open your File",
                //Filter = " ",
                FileName = "",
            };

                
               if (ofd.ShowDialog() == true)
                {
                fileName = ofd.FileName;
                Console.WriteLine(fileName);
                }
            
               
            
        }

        public void getData()
        {
            DataTable dT = new DataTable();
            OldTable = dT;
            columnRowDefault = null;

            if (fileName == null)
            {
                OpenFile();
            }

            if (checkTranspo == false)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path: fileName);

                int rowCounter = 0;
                int counter = 0;
                int idxrow = 1;

                while ((row = file.ReadLine()) != null)
                {

                    System.Console.WriteLine(row);
                    if (rowCounter == 0)
                    {
                        checkAenderung = row;
                        columnRowDefault = row;
                        Console.WriteLine(columnRowDefault);
                    }
                    string dummy = Convert.ToString(idxrow) + "|";
                    if (rowCounter >= 1)
                    {
                        checkAenderung = checkAenderung + Environment.NewLine + row;
                        row = dummy + row;
                    }
                    string[] words = row.Split('|');

                    var wordsList = new List<string>(words);
                    wordsList.RemoveAt(wordsList.Count - 1);


                    if (rowCounter == 0)
                    {
                        int idx = 1;
                        dT.Columns.Add("Index" + Environment.NewLine + "Kürzel" + Environment.NewLine + "Bezeichnung");

                        // create column

                        foreach (var word in wordsList)
                        {

                            string acronym = "";
                            string description = "";

                            if (word.Contains("="))
                            {
                                string[] assignment = word.Split('=');
                                acronym = assignment[0];
                                description = assignment[1];
                            }
                            else
                            {
                                acronym = word;
                            }

                            dT.Columns.Add(idx + Environment.NewLine + acronym + Environment.NewLine + description, Type.GetType("System.String"));
                            idx++;
                        }
                    }
                    else
                    {
                        // create rows

                        dT.Rows.Add(wordsList.ToArray());
                        idxrow++;
                    }

                    rowCounter++;
                    counter++;
                }
                myDataGrid.ItemsSource = dT.DefaultView;
                file.Close();
                
            }
            else
            {
             /*var transposeDt =  DataGridtoDataTable(myDataGrid);
                Console.WriteLine(transposeDt);
              transposeDt =  TransposeDataTable(transposeDt);
              myDataGrid.ItemsSource = transposeDt.DefaultView;*/
            }
        }

        public DataTable TransposeDataTable(DataTable dt)
        {
            DataTable transposedTable = new DataTable();

            DataColumn firstColumn = new DataColumn(dt.Columns[0].ColumnName);
            transposedTable.Columns.Add(firstColumn);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataColumn dc = new DataColumn(dt.Rows[i][0].ToString());
                transposedTable.Columns.Add(dc);
            }

            for (int j = 1; j < dt.Columns.Count; j++)
            {
                DataRow dr = transposedTable.NewRow();
                dr[0] = dt.Columns[j].ColumnName;

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    dr[k + 1] = dt.Rows[k][j];
                }

                transposedTable.Rows.Add(dr);
            }

            return transposedTable;
        }


        public DataTable DataGridtoDataTable(DataGrid dg)
        {
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            string[] Lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);
            DataTable dn = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                dn.Columns.Add(Fields[i].ToUpper(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0) - 1; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dn.NewRow();
                for (int f = 0; f < Cols; f++)
                {
                    Row[f] = Fields[f];
                }
                dn.Rows.Add(Row);
            }
            return dn;

        }
    }
   
}

