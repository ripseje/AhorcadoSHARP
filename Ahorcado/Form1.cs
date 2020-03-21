using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        String palabraOculta = "";
        int numeroFallos = 0;
        Boolean victoria = false;
        Boolean derrota = false;

        public Form1()
        {
            InitializeComponent();
            palabraOculta = palabra();
            String aux = "";
            for (int i=0; i < palabraOculta.Length; i++)
            {
                aux = aux + "_ ";
            }
            label1.Text = aux;
        }

        private void letraPulsada(object sender, EventArgs e)
        {
            Button miBoton = (Button)sender;
            String letra = miBoton.Text;
            String palabra = label1.Text;
            letra = letra.ToUpper();
            if (palabraOculta.Contains(letra) && !(victoria) && !(derrota))
            {
                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    if (palabraOculta[i] == letra.ToCharArray()[0])
                    {
                        palabra = palabra.Substring(0, 2 * i) + letra + palabra.Substring(2 * i + 1);
                    }
                }
                label1.Text = palabra;
            }
            else
            {
                numeroFallos++;
            }
            if (!label1.Text.Contains('_'))
            {
                numeroFallos = -100;
                victoriaX();
            }
            
            miBoton.Enabled = false;
            if (!victoria && !derrota)
            {
                switch (numeroFallos)
                {
                    case 0: pictureBox1.Image = Properties.Resources.ahorcado1; break;
                    case 1: pictureBox1.Image = Properties.Resources.ahorcado2; break;
                    case 2: pictureBox1.Image = Properties.Resources.ahorcado3; break;
                    case 3: pictureBox1.Image = Properties.Resources.ahorcado4; break;
                    case 4: pictureBox1.Image = Properties.Resources.ahorcado5; break;
                    case 5: pictureBox1.Image = Properties.Resources.ahorcado6; break;
                    case 6: pictureBox1.Image = Properties.Resources.ahorcadofin; derrotaX();  break;
                    case -100: pictureBox1.Image = Properties.Resources.acertasteTodo; break;
                    default: pictureBox1.Image = Properties.Resources.ahorcadofin; break;
                }
            }
            
            

        }

        public string palabra()
        {
            String[] listaPalabras = {"HOLA", "VALEKAKA", "BORREGUITO", "BABYYODA",
                                            "DELYNITH", "FORESKIN", "ANDERE", "FUNCIONARIO", "CHINO", "GALLOS",
                                            "OSU", "TRONCO", "COJONES", "BOOLEAN", "STRING", "PAPI", "CELESTINA",
                                            "ARKANOID", "FRAXITO"};

            Random ran = new Random();
            int posicion = ran.Next(listaPalabras.Length);
            return listaPalabras[posicion].ToUpper();
            
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void victoriaX()
        {
            pictureBox1.Image = Properties.Resources.acertasteTodo;
            victoria = true;
        }

        public void derrotaX()
        {
            pictureBox1.Image = Properties.Resources.ahorcadofin;
            derrota = true;
        }
    }
}
