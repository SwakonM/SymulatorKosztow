using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;
using System.IO;

namespace OptymalizatorWyceniania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region members
        int count = 1;
        #endregion
        public LinkedList<TabMod> my_list = new LinkedList<TabMod>();
        public MainWindow()
        {
            InitializeComponent();
          
        }

        public void Init()
        {


            TabMod temp = new TabMod("CSD", 1, 0);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);

            temp = new TabMod("MAN", 2, 0);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);
            temp = new TabMod("REG", 2, 1);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);
            temp = new TabMod("PRS", 2, 2);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);
            temp = new TabMod("RPS", 2, 3);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);
            temp = new TabMod("SUB", 3, 0);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);
            temp = new TabMod("CMS", 3, 1);
            temp.t_in = 3.0;
            temp.c_in = 3.0;
            temp.t_out = 5.0;
            temp.c_out = 5.0;
            temp.t_out = 5.0;
            temp.t_forward = 5.0;
            temp.c_forward = 5.0;
            temp.t_back = 5.0;
            temp.c_back = 5.0;
            my_list.AddLast(temp);
        }
        
        private void ButtonWczytajCSVExec(Object Sender, RoutedEventArgs e)
        {
            my_list.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
           openFileDialog.Filter = "CSV (*.csv)| *.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string path = System.IO.Path.GetFullPath(openFileDialog.FileName);

                string[] lines = System.IO.File.ReadAllLines(path);
                TabMod temp;
                var count = 0;
                foreach (string line in lines)
                {
                    if(count>0)
                    {
                        string[] columns = line.Split(',');



                        temp = new TabMod(columns[2], Int32.Parse(columns[3]), Int32.Parse(columns[4]));
                        temp.t_in = Double.Parse(columns[5]);
                        temp.c_in = Double.Parse(columns[6]);
                        temp.t_out = Double.Parse(columns[7]);
                        temp.c_out = Double.Parse(columns[8]);
                        temp.t_out = Double.Parse(columns[9]);
                        temp.t_forward = Double.Parse(columns[10]);
                        temp.c_forward = Double.Parse(columns[11]);
                        temp.t_back = Double.Parse(columns[12]);
                        temp.c_back = Double.Parse(columns[13]);
                        my_list.AddLast(temp);

                    }
                    count++;
                }
            }
           

        }
            private void ButtonWczytajExec(Object Sender, RoutedEventArgs e)
        {
            count = 0;


            mymy.RowDefinitions.Clear();
            mymy.ColumnDefinitions.Clear();
             for(int i =0;i<11;i++)
            {
                ColumnDefinition colDef1;
                colDef1 = new ColumnDefinition();
                mymy.ColumnDefinitions.Add(colDef1);
            }
           

            foreach (TabMod ity in my_list)
            {
               Label l1 = new Label();
               l1.Content= ity.Nazwa;
                l1.Width = 90;
                TextBox t_in = new TextBox();
                t_in.Height = 20;
                t_in.Width = 90;
                t_in.Name = ity.Nazwa+ "t_in";
                t_in.Text = ity.t_in.ToString();
                t_in.Background = Brushes.LightGreen;
                
                var tt_in = new ToolTip();
                if (ity.id_sub == 0)
                    tt_in.Content = "time of servicing the incoming inquiry";
                else
                    tt_in.Content = "time of servicing the incoming inquiry \n in the B-th logistics subunit";
                t_in.ToolTip = tt_in;


                TextBox c_in = new TextBox();
                c_in.Height = 20;
                c_in.Width = 90;
                c_in.Name = ity.Nazwa + "c_in";
                c_in.Text = ity.t_in.ToString();
                c_in.Background = Brushes.Yellow;
                var tc_in = new ToolTip();
                if (ity.id_sub == 0)
                    tc_in.Content = "cost of servicing the incoming inquiry ";
                else
                    tc_in.Content = "cost of servicing the incoming inquiry \n in the B-th logistics subunit. ";
                c_in.ToolTip = tc_in;

                TextBox t_out = new TextBox();
                t_out.Height = 20;
                t_out.Width = 90;
                t_out.Name = ity.Nazwa + "t_out";
                t_out.Text = ity.t_in.ToString();
                t_out.Background = Brushes.LightGreen;
                var tt_out = new ToolTip();
                if (ity.id_sub == 0)
                    tt_out.Content = "time of servicing the outcoming inquiry";
                else
                    tt_out.Content = "time of servicing the outcoming inquiry \n in the B-th logistics subunit";
                t_out.ToolTip = tt_out;

                TextBox c_out = new TextBox();
                c_out.Height = 20;
                c_out.Width = 90;
                c_out.Name = ity.Nazwa + "c_out";
                c_out.Text = ity.c_out.ToString();
                c_out.Background = Brushes.Yellow;
                var tc_out = new ToolTip();
                if (ity.id_sub == 0)
                    tc_out.Content = "cost of servicing the outcoming inquiry ";
                else
                    tc_out.Content = "cost of servicing the outcoming inquiry for in the B-th logistics subunit";
                c_out.ToolTip = tc_out;

                TextBox t_forward = new TextBox();
                t_forward.Height = 20;
                t_forward.Width = 90;
                t_forward.Name = ity.Nazwa + "t_forward";
                t_forward.Text = ity.t_forward.ToString();
                t_forward.Background = Brushes.LightGreen;
                var tt_forward = new ToolTip();
                if (ity.id_sub == 0)
                    tt_forward.Content = "Time of the information flow between the A-th preceding logistics";
                  else
                    tt_forward.Content = "time of the information flow between the A-th main logistics unit and its B-th logistics subunit";
                t_forward.ToolTip = tt_forward;


                TextBox c_forward = new TextBox();
                c_forward.Height = 20;
                c_forward.Width = 90;
                c_forward.Name = ity.Nazwa + "c_forward";
                c_forward.Text = ity.c_forward.ToString();
                c_forward.Background = Brushes.Yellow;
                var tc_forward = new ToolTip();
                if (ity.id_sub == 0)
                    tc_forward.Content = "cost of the information flow between the A-th preceding logistics unit ";
                  else
                    tc_forward.Content = "cost of the information flow between the A-th main \n logistics unit and its B-th logistics subunit ";
                c_forward.ToolTip = tc_forward;

                TextBox t_back = new TextBox();
                t_back.Height = 20;
                t_back.Width = 90;
                t_back.Name = ity.Nazwa + "t_back";
                t_back.Text = ity.t_back.ToString();
                t_back.Background = Brushes.LightGreen;
                var tt_back = new ToolTip();
                if (ity.id_sub == 0)
                    tt_back.Content = "time of the information flow between \n the A-th preceding logistics unit and the subsequent ";
                  else
                    tt_back.Content = "time of the information flow between \n the B-th logistics subunit and the A-th logistics unit";
                t_back.ToolTip = tt_back;

                TextBox c_back = new TextBox();
                c_back.Height = 20;
                c_back.Width = 90;
                c_back.Name = ity.Nazwa + "c_back";
                c_back.Text = ity.c_back.ToString();
                c_back.Background = Brushes.Yellow;
                var tc_back = new ToolTip();
                if (ity.id_sub == 0)
                    tc_back.Content = "cost of the information flow between \nthe A-th preceding logistics unit and the subsequent";
                  else
                    tc_back.Content = "cost of the information flow between \nthe B-th logistics subunit and the main -th logistics unit";
                c_back.ToolTip = tc_back;

                RowDefinition rowDef1;
                rowDef1 = new RowDefinition();
                mymy.RowDefinitions.Add(rowDef1);

               
                mymy.Children.Add(l1);
                mymy.Children.Add(t_in);
                mymy.Children.Add(c_in);
                mymy.Children.Add(t_out);
                mymy.Children.Add(c_out);
                mymy.Children.Add(t_forward);
                mymy.Children.Add(c_forward);
                mymy.Children.Add(t_back);
                mymy.Children.Add(c_back);
                if (ity.id_sub==0)
                {
                    Grid.SetColumn(l1, 0);
                    Grid.SetColumn(t_in, 1);
                    Grid.SetColumn(c_in, 2);
                    Grid.SetColumn(t_out,3);
                    Grid.SetColumn(c_out,4);
                    Grid.SetColumn(t_forward, 5);
                    Grid.SetColumn(c_forward, 6);
                    Grid.SetColumn(t_back, 7);
                    Grid.SetColumn(c_back, 8);
                }
             
                else
                {
                    Grid.SetColumn(l1, 1);
                    Grid.SetColumn(t_in, 2);
                    Grid.SetColumn(c_in, 3);
                    Grid.SetColumn(t_out, 4);
                    Grid.SetColumn(c_out, 5);
                    Grid.SetColumn(t_forward, 6);
                    Grid.SetColumn(c_forward, 7);
                    Grid.SetColumn(t_back, 8);
                     Grid.SetColumn(c_back, 9);
                }
             
                Grid.SetRow(l1, count);
                Grid.SetRow(t_in, count);
                Grid.SetRow(c_in, count);
                Grid.SetRow(t_out, count);
                Grid.SetRow(c_out, count);
                Grid.SetRow(t_forward, count);
                Grid.SetRow(c_forward, count);
                Grid.SetRow(t_back, count);
                Grid.SetRow(c_back, count);
                count++;
            }
               
        }
        private void ButtonObliczExec(Object Sender, RoutedEventArgs e)
        {

            var data_next = new Dictionary<Int32, Double>();//sub mod
            var data_back = new Dictionary<Int32, Double>();//sub mod
            foreach (TabMod ity in my_list)
            {
                if (ity.id_sub == 0)
                {
                    data_next[ity.id_mod] = 0;
                    data_back[ity.id_mod] = 0;
                }
            }



            foreach (TabMod ity in my_list)
            {
                if (ity.id_sub == 0)
                {
                    data_next[ity.id_mod] += ity.t_in * ity.c_in + ity.t_out * ity.c_out + ity.t_forward * ity.c_forward;
                    data_back[ity.id_mod] += ity.t_in * ity.c_in + ity.t_out * ity.c_out + ity.t_back * ity.c_back;
                }
                else
                {
                    data_next[ity.id_mod] += ity.t_in * ity.c_in + ity.t_out * ity.c_out;
                    data_back[ity.id_mod] += ity.t_in * ity.c_in + ity.t_out * ity.c_out;
                }
            }

            Double forward = 0; //koszt forward 
            Double back = 0; //koszt back
            foreach (var ity in data_next)
            {
                forward += ity.Value;
            }
            foreach (var ity in data_back)
            {
                back += ity.Value;
            }
            Double dAmountCoefficient;
            if (Double.TryParse( tbAmountCoefficient.Text.ToString(),out dAmountCoefficient))
            {
                forward += dAmountCoefficient;
                back += dAmountCoefficient;
            }

            tbForward.Text = forward.ToString();
            tbBack.Text = back.ToString();
        }
    }
}
