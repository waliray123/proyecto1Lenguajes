using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1Lenguajes.Controlers
{
    class ReservedWords
    {
        private String[] reserved = { "entero", "decimal", "cadena", "booleano", "caracter" };
        private String[] arithmeticoperators = { "--", "++", "/", "*", "-", "+" };
        private String[] relationaloperators = { ">=", "<=", "==", ">", "<", "!=" };
        private String[] logicoperators = { "||", "&&", "!"};
        private String[] groupingSigns = { "(", ")"};
        private String[] initFinalSigns = { "=", ";" };
        private String[] reservedWords  = { "SINO_SI", "SINO", "SI", "MIENTRAS", "HACER", "DESDE", "HASTA","INCREMENTO" };



        public String[] getReserved()
        {
            return this.reserved;
        }
        public String[] getArithmeticOperators()
        {
            return this.arithmeticoperators;
        }
        public String[] getReservedWords()
        {
            return this.reservedWords;
        }
        public String[] getRelationalOperators()
        {
            return this.relationaloperators;
        }
        public String[] getLogicOperators()
        {
            return this.logicoperators;
        }
        public String[] getGroupingSigns()
        {
            return this.groupingSigns;
        }
        public String[] getInitFinalSigns()
        {
            return this.initFinalSigns;
        }


    }
}
