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
        private List<string> reserverdWords;

        public ControlCompile(RichTextBox richTextbox)
        {
            this.richTextBox = richTextbox;
            initCompile();
            reviewChars();
        }

        public void initCompile() {
            //this.state = "0";
            reserverdWords = new List<string>() { "SI", "SINO", "SINO_SI", "MIENTRAS", "HACER",
                    "DESDE", "HASTA", "INCREMENTO"};
        }                

        public void reviewChars() {
            //int quantityChars = 0;
            String word = "";
            int state = 0;
            for (int i = 0; i < this.richTextBox.Text.Length; i++)
            {
                Char caracter = Convert.ToChar(this.richTextBox.Text.Substring(i, 1));
                switch (state)
                {
                    case 0:
                        if (Char.IsLetter(caracter))
                        {
                            goto case 1;
                        }
                        else if(Char.IsDigit(caracter))
                        {
                            goto case 2;
                        }
                        break;
                    case 1:
                        reviewIdentifier(ref i, caracter, this.richTextBox.Text);
                        break;
                    case 2:
                        Console.WriteLine("Que tal estas, Pedro.");
                        break;

                }
                word = "";
                haySaltoLinea(caracter);
            }
        }

        private void reviewIdentifier(ref int i, Char character,String textRTB)
        {
            String word = "";
            for (int x = i; x < textRTB.Length; x++)
            {                
                Char caracter = Convert.ToChar(this.richTextBox.Text.Substring(x, 1));                
                if ((caracter == ' ') || haySaltoLinea(caracter))
                {
                    break;
                }
                else
                {
                    i++;
                    word += caracter;
                }                
            }
            if (reserverdWords.Contains(word))
            {
                MessageBox.Show(word + " Es una palabra reservada");
                paintReservedWords(word, i);
            }
            else {
                MessageBox.Show(word + " Es un identificador");
            }            
        }

        public void paintReservedWords(String word, int start)
        {
            this.richTextBox.Select(start- word.Length, word.Length);
            this.richTextBox.SelectionColor = Color.Green;
            this.richTextBox.SelectionStart = this.richTextBox.Text.Length;
            this.richTextBox.SelectionColor = Color.Black;
            this.richTextBox.SelectionStart = this.richTextBox.Text.Length;
        }

        public Boolean haySaltoLinea(Char caracter)
        {
            if (caracter.Equals('\n'))
            {
                return true;
            }
            return false;
        }




        //private void getLines()
        //{
        //    foreach (String line in richTextBox.Lines)
        //    {                
        //        String[] words = line.Split(' ');
        //        for (int i = 0; i < words.Length; i++)
        //        {
        //            if (verifyReserved(words[i]) == false)
        //            {
        //                if (verifyAritmethicOperators(words[i]) == false)
        //                {
        //                    if (verifyReservedWords(words[i]) == false)
        //                    {
        //                        MessageBox.Show(words[i]+" No es palabra reservada");
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show(words[i] + " Es una palabra reservada");
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show(words[i]+ " Es un operador Aritmetico");
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show(words[i] + " Es reservada");
        //            }
        //        }
        //    }                     
        //}

        //private Boolean verifyReserved(String word) {
        //    Boolean isReserved = false;
        //    foreach (String reserved in this.reservedWordsCL.getReserved())
        //    {
        //        if (word.Equals(reserved))
        //        {
        //            isReserved = true;
        //            break;
        //        }
        //    }
        //    return isReserved;
        //}

        //private Boolean verifyAritmethicOperators(String word)
        //{
        //    Boolean isReserved = false;
        //    foreach (String reserved in this.reservedWordsCL.getArithmeticOperators())
        //    {
        //        if (word.Equals(reserved))
        //        {
        //            isReserved = true;
        //            break;
        //        }
        //    }
        //    return isReserved;
        //}

        //private Boolean verifyReservedWords(String word)
        //{
        //    Boolean isReserved = false;
        //    foreach (String reserved in this.reservedWordsCL.getReservedWords())
        //    {
        //        if (word.Equals(reserved))
        //        {
        //            isReserved = true;
        //            break;
        //        }
        //    }
        //    return isReserved;
        //}

        //private Boolean verifyRelationalOperators(String word)
        //{
        //    Boolean isReserved = false;
        //    foreach (String reserved in this.reservedWordsCL.getRelationalOperators())
        //    {
        //        if (word.Equals(reserved))
        //        {
        //            isReserved = true;
        //            break;
        //        }
        //    }
        //    return isReserved;
        //}

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
