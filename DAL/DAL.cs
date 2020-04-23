using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL
    {
        ChatDBModel context;

        public DAL()
        {
            context = new ChatDBModel();
        }
    }
}
