using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IHandler
    {
        IHandler Next { get; set; }
        void HandleRequest(string request);
    }
}
