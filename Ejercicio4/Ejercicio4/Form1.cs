using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo f;
            string ruta;
            if (textBox1.Text.StartsWith("%") && textBox1.Text.EndsWith("%"))
            {
                textBox1.Text = textBox1.Text.Replace("%", " ").Trim();
                ruta = Environment.GetEnvironmentVariable(textBox1.Text);
            }
            else 
            {
                ruta = textBox1.Text;
            }
            Console.WriteLine();
            Console.WriteLine("GetEnvironmentVariables: ");
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);

            if (Directory.Exists(ruta)) 
            {
                f = new FileInfo(ruta);
                Directory.SetCurrentDirectory(f.FullName);
                textBox2.Text = Directory.GetCurrentDirectory() + "\r\n";
                string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
                foreach (string item in dirs)
                {
                    textBox2.Text += item.ToString()+"\r\n";
                }
            }
            else 
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Directorio introducido no existe","¡Alerta!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}