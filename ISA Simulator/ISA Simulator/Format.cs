using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ISA_Simulator
{
    class Format
    {
        public Regex add = new Regex(@"((add|ADD) (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+), (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+|[0-9]+))$");
        public Regex sub = new Regex(@"((sub|SUB) (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+), (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+|[0-9]+))$");
        public Regex mul = new Regex(@"((mul|MUL) (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+), (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+|[0-9]+))$");
        public Regex div = new Regex(@"((div|DIV) (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+), (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+|[0-9]+))$");
        public Regex and = new Regex(@"((and|AND) (\[(r|R)(1|2|3|4)\]|(r|R)(1|2|3|4)), (\[(r|R)(1|2|3|4)\]|(r|R)(1|2|3|4)|[a-f,A-F,0-9]+h))$");
        public Regex or = new Regex(@"((or|OR) (\[(r|R)(1|2|3|4)\]|(r|R)(1|2|3|4)), (\[(r|R)(1|2|3|4)\]|(r|R)(1|2|3|4)|[a-f,A-F,0-9]+h))$");
        public Regex not = new Regex(@"((not|NOT) (\[(r|R)(1|2|3|4)\]|(r|R)(1|2|3|4)))$");
        public Regex xor = new Regex(@"((xor|XOR) (\[(r|R)(1|2|3|4)\]|(r|R)(1|2|3|4)), ((r|R)(1|2|3|4)|[a-f,A-F,0-9]+h))$");
        public Regex mov = new Regex(@"((mov|MOV) (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+), (\[(r|R)(1|2|3|4)\]|r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+|[0-9]+|[a-f,A-F,0-9]+h))$");
        public Regex IN = new Regex(@"((in|IN) (\[(r|R)(1|2|3|4)\]|(0x[a-f,A-F,0-9]+)|(r(1|2|3|4))))$");
        public Regex OUT = new Regex(@"((out|OUT) (\[(r|R)(1|2|3|4)\]|(0x[a-f,A-F,0-9]+)|(r(1|2|3|4))))$");
        public Regex jmp = new Regex(@"((jmp|JMP) ([a-z]|[A-Z]|[0-9]|_)+)");
        public Regex cmp = new Regex(@"((cmp|CMP) (r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+), (r1|R1|r2|R2|r3|R3|r4|R4|0x[a-f,A-F,0-9]+|[0-9]+))$");
        public Regex je = new Regex(@"((je|JE) ([a-z]|[A-Z]|[0-9]|_)+)$");
        public Regex jne = new Regex(@"((jne|JNE) ([a-z]|[A-Z]|[0-9]|_)+)$");
        public Regex jge = new Regex(@"((jge|JGE) ([a-z]|[A-Z]|[0-9]|_)+)$");
        public Regex jl = new Regex(@"((jl|JL) ([a-z]|[A-Z]|[0-9]|_)+)$");
    }
}
