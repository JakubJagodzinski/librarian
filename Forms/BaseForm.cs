using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarian.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.FormClosed += (s, e) => Application.Exit();
        }
    }
}
