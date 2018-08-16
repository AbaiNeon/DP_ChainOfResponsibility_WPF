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

namespace WpfApp1
{
    
    public partial class MainWindow : Window
    {
        //счетчик
        public int count;

        public MainWindow()
        {
            InitializeComponent();
            count = 0;
        }

        private async void BtnGenerateRequestClick(object sender, RoutedEventArgs e)
        {
            string tmpRequest = "запрос" + count++.ToString();

            IHandler h1 = new Handler1(listOperator1);
            IHandler h2 = new Handler2(listOperator2);
            IHandler h3 = new Handler3(listOperator3, listUnhandled);

            h1.Next = h2;
            h2.Next = h3;

            await Task.Run(() => 
            {
                h1.HandleRequest(tmpRequest);
            });
        }

        private void BtnHandleOp1Click(object sender, RoutedEventArgs e)
        {
            if (listOperator1.Items.Count == 0)
            {

            }
            else
            {
                //del from list
                string str = (string)listOperator1.Items.GetItemAt(0);
                listOperator1.Items.RemoveAt(0);

                //add to handled
                listHandled.Items.Add(str);
            }
        }
    }
}
