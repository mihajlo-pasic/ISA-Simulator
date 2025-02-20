using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ISA_Simulator
{
    class Checker
    {
        Format format = new Format();
        public bool Check(string line, string operation)
        {
            switch (operation)
            {
                case "add": return format.add.IsMatch(line);
                case "sub": return format.sub.IsMatch(line);
                case "mul": return format.mul.IsMatch(line);
                case "div": return format.div.IsMatch(line);
                case "and": return format.and.IsMatch(line);
                case "or": return format.or.IsMatch(line);
                case "not": return format.not.IsMatch(line);
                case "xor": return format.xor.IsMatch(line);
                case "mov": return format.mov.IsMatch(line);
                case "in": return format.IN.IsMatch(line);
                case "out": return format.OUT.IsMatch(line);
                case "jmp": return format.jmp.IsMatch(line);
                case "cmp": return format.cmp.IsMatch(line);
                case "je": return format.je.IsMatch(line);
                case "jne": return format.jne.IsMatch(line);
                case "jge": return format.jge.IsMatch(line);
                case "jl": return format.jl.IsMatch(line);
                case "ADD": return format.add.IsMatch(line);
                case "SUB": return format.sub.IsMatch(line);
                case "MUL": return format.mul.IsMatch(line);
                case "DIV": return format.div.IsMatch(line);
                case "AND": return format.and.IsMatch(line);
                case "OR": return format.or.IsMatch(line);
                case "NOT": return format.not.IsMatch(line);
                case "XOR": return format.xor.IsMatch(line);
                case "MOV": return format.mov.IsMatch(line);
                case "IN": return format.IN.IsMatch(line);
                case "OUT": return format.OUT.IsMatch(line);
                case "JMP": return format.jmp.IsMatch(line);
                case "CMP": return format.cmp.IsMatch(line);
                case "JE": return format.je.IsMatch(line);
                case "JNE": return format.jne.IsMatch(line);
                case "JGE": return format.jge.IsMatch(line);
                case "JL": return format.jl.IsMatch(line);
                default: return false;
            }
        }

    }
}
