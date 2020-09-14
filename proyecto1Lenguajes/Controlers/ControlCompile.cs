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
        private List<string> reserverdBoolean;
        private List<string> arithmeticOperators;


        public ControlCompile(RichTextBox richTextbox)
        {
            this.richTextBox = richTextbox;
            initCompile();
            reviewChars();
        }

        private void initCompile()
        {
            //this.state = "0";
            reserverdWords = new List<string>() { "SI", "SINO", "SINO_SI", "MIENTRAS", "HACER",
                    "DESDE", "HASTA", "INCREMENTO"};
            arithmeticOperators = new List<string>() { "+", "-", "*", "/", "++", "--"};
            reserverdBoolean = new List<string>() {"verdadero","falso"};
        }                

        public void reviewChars()
        {
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
                        else if (Char.IsDigit(caracter))
                        {
                            goto case 2;
                        }
                        else
                        {
                            goto case 3;
                        }
                    case 1:
                        reviewIdentifier(ref i, caracter, this.richTextBox.Text);
                        break;
                    case 2:
                        Console.WriteLine("Que tal estas, Pedro.");
                        break;
                    case 3:
                        reviewSymbols(ref i, caracter);
                        break;

                }
                isLineBreak(caracter);
            }
        }

        private void reviewIdentifier(ref int i, Char character,String textRTB)
        {
            String word = "";
            for (int x = i; x < textRTB.Length; x++)
            {
                Char caracter = Convert.ToChar(this.richTextBox.Text.Substring(x, 1));
                if ((caracter == ' ') || isLineBreak(caracter) || (Char.IsLetter(caracter)==false && Char.IsDigit(caracter)== false))
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
                paintReservedWords(word, i, Color.Green);
            }
            else if(reserverdBoolean.Contains(word))
            {
                paintReservedWords(word, i, Color.Orange);
            }
            else if (word.Length == 1)
            {
                paintReservedWords(word, i, Color.Brown);
            }
            else {
                paintReservedWords(word, i, Color.Black);
                MessageBox.Show(word + " Es un identificador");
            }
            i--;
        }

        private void reviewSymbols(ref int i ,Char character)
        {
            int countSymbols = 0;
            String word = "";
            if (character == '/')
            {
                word += character;
                if ((i + 2) <= this.richTextBox.Text.Length)
                {
                    character = Convert.ToChar(this.richTextBox.Text.Substring((i + 1), 1));
                    if (character == '/')
                    {
                        reviewComment1(ref i);
                    }
                    else if (character == '*')
                    {
                        reviewComment2(ref i);
                    }
                    else if (character == ' ' || isLineBreak(character))
                    {
                        paintReservedWords(word, i + 1, Color.Blue);
                    }
                    else
                    {
                        // error quizas quisiste poner un comentario
                        MessageBox.Show("Falta / para comentario");
                    }
                }
                else
                {
                    paintReservedWords(word, i + 1, Color.Blue);
                }
            }
            else if (character == ';')
            {
                word += character;
                paintReservedWords(word, i + 1, Color.DeepPink);
            }
            else if (character == '(' || character == ')')
            {
                word += character;
                paintReservedWords(word, i + 1, Color.Blue);
            }
            else if (this.arithmeticOperators.Contains(character.ToString()))
            {
                for (int x = i; x < this.richTextBox.Text.Length; x++)
                {
                    character = Convert.ToChar(this.richTextBox.Text.Substring(x, 1));
                    if (character == ' ' || isLineBreak(character) || character == ';')
                    {
                        break;
                    }
                    else
                    {
                        i++;
                        word += character;
                        countSymbols++;
                    }
                }
                if (countSymbols <= 2)
                {
                    if (this.arithmeticOperators.Contains(word))
                    {
                        paintReservedWords(word, i, Color.Blue);
                    }
                }
                else
                {
                    //Error El operador aritmetico no existe
                }
                i--;
            }
            

        }

        private void reviewComment1(ref int i)
        {
            String word = "";
            for (int x = i; x < this.richTextBox.Text.Length; x++)
            {
                Char character = Convert.ToChar(this.richTextBox.Text.Substring(x, 1));
                if (isLineBreak(character))
                {
                    break;
                }
                else
                {
                    i++;
                    word += character;
                }
            }
            paintReservedWords(word, i, Color.Red);
        }
        private void reviewComment2(ref int i)
        {
            Boolean commentClosed = false;
            String word = "";
            for (int x = i; x < this.richTextBox.Text.Length; x++)
            {
                Char character = Convert.ToChar(this.richTextBox.Text.Substring(x, 1));
                if (character == '*')
                {                    
                    if ((x+1) <= this.richTextBox.Text.Length)
                    {
                        Char character2 = Convert.ToChar(this.richTextBox.Text.Substring((x + 1), 1));
                        if (character2 == '/')
                        {
                            i = i +2;
                            word += character;
                            word += character2;
                            commentClosed = true;
                            break;
                        }
                        else
                        {
                            i++;
                            word += character;
                        }
                    }                 
                }
                else
                {
                    i++;
                    word += character;
                }
            }
            paintReservedWords(word, i, Color.Red);
            if(commentClosed == false)
            { 
                // error falta cierre de comentario
                MessageBox.Show("Error falta cierre de comentario");
            }
        }

        public void paintReservedWords(String word, int start, Color color)
        {
            this.richTextBox.Select(start- word.Length, word.Length);
            this.richTextBox.SelectionColor = color;
            this.richTextBox.SelectionStart = this.richTextBox.Text.Length;
            this.richTextBox.SelectionColor = Color.Black;
            this.richTextBox.SelectionStart = this.richTextBox.Text.Length;
        }

        public Boolean isLineBreak(Char caracter)
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
