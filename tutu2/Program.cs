using System;
using System.Windows.Forms;
using tutu2;

namespace tutu2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // Запускаем форму авторизации
        }
    }
}