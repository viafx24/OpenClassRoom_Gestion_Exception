// ce petit programme est parfait pour illustrer le foncionnement de la console avec une fenètre ainsi que la gestion
// de nos propres exception avec une fenètre de dialogue.
// quelque trucs sans grand sens comme la grande fenètre de form1 qui s'ouvre à la fin; peu important; je ne prends pas le temps 
// de voir comment la virer l'exemple est parlant.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenClassRoom_Gestion_Exception
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                Console.Write("Entrez un nombre : ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(
                    "100/nombre = {0}",
                    100 / n);
                if (n == 5)
                {
                    throw new MyException();
                }
                    
            }

            catch (MyException ex)
            {
                ex.DisplayError();
            }
            finally
            {
                Console.WriteLine("Quel que soit le résultat, ceci est affiché.");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class MyException : Exception
    {
        DateTime m_errorTime;
        static ushort s_errorNumber;

        public MyException()
            : base("Vous avez choisi 5.")
        {
            m_errorTime = DateTime.Now;
            s_errorNumber++;
        }

        public MyException(string message)
            : base(message)
        {
            m_errorTime = DateTime.Now;
            s_errorNumber++;
        }

        public void DisplayError()
        {
            MessageBox.Show(
                base.Message,
                string.Format(
                    "Erreur n°{0} survenue à {1}.",
                    s_errorNumber,
                    m_errorTime.ToLongTimeString()),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
