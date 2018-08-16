using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1
{
    public class Handler1 : IHandler
    {
        ListBox _listBox;
        public IHandler Next { get; set; }

        //конструктор
        public Handler1(ListBox listBox)
        {
            _listBox = listBox;
        }

        //обработчик
        public void HandleRequest(string request)
        {
            if (_listBox.Items.Count == 0)
            {
                _listBox.Dispatcher.Invoke(() => 
                {
                    _listBox.Items.Add(request);
                });
                
            }
            else if(Next != null)
            {
                _listBox.Dispatcher.Invoke(() =>
                {
                    _listBox.Items.Add(request);
                });

                //ждем секунду
                Thread.Sleep(1000);

                //передать следующему
                _listBox.Dispatcher.Invoke(() =>
                {
                    _listBox.Items.Remove(request);
                });

                Next.HandleRequest(request);
            }
        }
    }
}
