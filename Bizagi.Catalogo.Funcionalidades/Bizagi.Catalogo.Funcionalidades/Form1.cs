using Bizagi.ECM.Manager;
using Bizagi.Test.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Bizagi.Catalogo.Funcionalidades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ECMManager ecm = new ECMManager();
            ObjetoEntradaECM obj = new ObjetoEntradaECM();
            int operacion = 3;
            obj.Header.Token = "HOV510htOeiRa4MONRXgCg==";
            obj.Header.Usuario = "wm";
            obj.Trace.UrlTrace = @"D:\Proyectos\";
            obj.Trace.NombreProceso = "Prueba";
            obj.Trace.NumeroSolicitud ="123456";
            //obj.NumeroRadicado = "35-2303-201710010000003";
            obj.Identificacion = "9530678";
            ecm.EjecutarECM(obj, operacion);

            //CommonMethods c = new CommonMethods();

            //MessageBox.Show(c.ConvertNumbersToLetters(textBox1.Text, true));

        }
        
    }
}
