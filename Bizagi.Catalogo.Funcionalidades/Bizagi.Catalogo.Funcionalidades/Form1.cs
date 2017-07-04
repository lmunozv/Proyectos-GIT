using Bizagi.ECM.Manager;
using Bizagi.Test.Util;
using OnBarcode.Barcode;
using System;
using System.Collections;
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
            obj.Identificacion = "1024";
            ecm.EjecutarECM(obj, operacion);

            //CommonMethods c = new CommonMethods();

            //MessageBox.Show(c.ConvertNumbersToLetters(textBox1.Text, true));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("campo1");
            ArrayList arr = new ArrayList();
            arr.Add(1);
            arr.Add(2);

            DataRow row = dt.NewRow();
            row["campo1"] = 1;
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["campo1"] = 2;
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["campo1"] = 3;
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["campo1"] = 4;
            dt.Rows.Add(row);
            var i =dt.Columns.Count;
            string t = string.Empty;
            var con = 0;
            foreach (var item in arr)
            {
                if (con == 0)
                {
                    t = item.ToString();
                }
                else
                {
                    t = t +","+ item.ToString();
                }
                i++;                
            }
           string fil = "campo1 IN (" +t +") And campo1 =" +2;
            var tt = dt.Select(fil);
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Linear l = new Linear();
            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE128;
            barcode.Data = "123456";
            barcode.X = 2;
            var r= barcode.drawBarcodeAsBytes();
        }
    }
}
