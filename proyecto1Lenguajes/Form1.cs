﻿using proyecto1Lenguajes.Controlers;
using proyecto1Lenguajes.GUILogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto1Lenguajes
{
    public partial class Form1 : Form
    {
        private String pathFile;
        private int numberErrors;
        private ControlCompile control;
        public Form1()
        {
            InitializeComponent();
            pathFile = "";
            numberErrors = 0;
            this.control = new ControlCompile(this.richTextBox1, this.dataGridView1, ref this.numberErrors);
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            this.pathFile = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.control = new ControlCompile(this.richTextBox1, this.dataGridView1, ref this.numberErrors);

            int position = this.richTextBox1.SelectionStart;
            int line = this.richTextBox1.GetLineFromCharIndex(position)+1;
            int column = position - this.richTextBox1.GetFirstCharIndexOfCurrentLine();
            this.label2.Text = line.ToString();
            this.label4.Text = column.ToString();
            if (this.numberErrors <= 0)
            {
                MessageBox.Show("Se analizo con exito");
            }
            else
            {
                MessageBox.Show("No se compilo con exito, Existen errores por arreglar");
            }
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load load = new Load(this.richTextBox1);
            this.pathFile = load.getData();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pathFile.Equals(""))
            {
                MessageBox.Show("No se ha cargado ningun archivo",null,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else
            {
                Save save = new GUILogic.Save(this.richTextBox1);
                save.saveData(this.pathFile);
                MessageBox.Show("Se guardo con exito");
            }            
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save save = new GUILogic.Save(this.richTextBox1);
            save.saveAsData();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int position = this.richTextBox1.SelectionStart;
            int line = this.richTextBox1.GetLineFromCharIndex(position) + 1;
            int column = position - this.richTextBox1.GetFirstCharIndexOfCurrentLine();
            this.label2.Text = line.ToString();
            this.label4.Text = column.ToString();

            //this.control.reviewChars();
        }        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
