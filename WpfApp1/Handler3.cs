using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    public class Handler3 : IHandler
    {
        ListBox _listBox;
        ListBox _listUnhandled;
        public IHandler Next { get; set; }

        //конструктор
        public Handler3(ListBox listBox, ListBox listUnhandled)
        {
            _listBox = listBox;
            _listUnhandled = listUnhandled;
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
            else 
            {
                _listBox.Dispatcher.Invoke(() =>
                {
                    _listBox.Items.Add(request);
                });

                //ждем секунду
                Thread.Sleep(1000);

                //отклоняем запрос и выкидываем его в "необработанные"
                _listBox.Dispatcher.Invoke(() =>
                {
                    _listBox.Items.Remove(request);
                });
                _listUnhandled.Dispatcher.Invoke(() =>
                {
                    _listUnhandled.Items.Add(request);
                });
            }
        }
    }
}
