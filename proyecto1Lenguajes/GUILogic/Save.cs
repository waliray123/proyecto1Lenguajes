using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto1Lenguajes.GUILogic
{
    class Save
    {
        private RichTextBox richtextBox;

        public Save(RichTextBox richtextBox1)
        {
            this.richtextBox = richtextBox1;
        }
        public void saveData(String pathFile)
        {
            File.WriteAllText(pathFile, this.richtextBox.Text);
        }

        public void saveAsData()
        {
            SaveFileDialog saveAs = new SaveFileDialog();
            saveAs.Filter = "Documento tipo texto |*.gt";
            saveAs.Title = "Guardar Archivo";
            var res = saveAs.ShowDialog();
            if (res == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(saveAs.FileName);
                write.WriteLineAsync(this.richtextBox.Text);
                write.Close();
            }
        }

    }
}
