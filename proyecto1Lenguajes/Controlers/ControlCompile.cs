using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto1Lenguajes.Controlers
{
    class ControlCompile
    {
        private RichTextBox richTextBox;

        public ControlCompile(RichTextBox richTextbox)
        {
            this.richTextBox = richTextbox;
            //getLines();
        }

        private void getLines()
        {
            String[] words = richTextBox.Text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                MessageBox.Show(words[i]);
            }            
        }

        //public void addFilter(RichTextBox codeRichTextBox)
        //{
        //    try
        //    {
        //        codeRichTextBox.TextChanged += (ob, ev) =>
        //        {
        //            var word = codeRichTextBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //            var result = from b in reserved
        //                         from c in word
        //                         where c == b
        //                         select b;

        //            int start = 0;
        //            foreach (var item in result)
        //            {
        //                start = codeRichTextBox.Text.IndexOf(item, start);
        //                codeRichTextBox.Select(start, item.Length);
        //                codeRichTextBox.SelectionColor = Color.Green;
        //                codeRichTextBox.SelectionStart = codeRichTextBox.Text.Length;
        //                start++;
        //            }

        //            codeRichTextBox.SelectionColor = Color.White;
        //            codeRichTextBox.SelectionStart = codeRichTextBox.Text.Length;

        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("error " + e.Message);
        //    }
        //}
    }
}
