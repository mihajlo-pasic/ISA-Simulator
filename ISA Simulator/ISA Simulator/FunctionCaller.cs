using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Simulator
{
    class FunctionCaller
    {
        Instructions instruction = new Instructions();
        Checker checker = new Checker();

        public bool CheckAndCallFunction(string line, ref int i, int totalLines, string[] test)
        {
            try
            {
                if(String.IsNullOrEmpty(line)) return false;
                char[] spearator = { ' ', ',' };
                String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                if (strlist.Length == 1) return false;

                string operation = strlist[0]; 

                if (!checker.Check(line, operation))
                {
                    Console.WriteLine("Linija " + i + " ima gresku.");
                    return true;
                }


                switch (operation)
                {
                    case "add": return instruction.Add(line);
                    case "sub": return instruction.Sub(line);
                    case "mul": return instruction.Mul(line);
                    case "div": return instruction.Div(line);
                    case "and": return instruction.And(line);
                    case "or": return instruction.Or(line);
                    case "not": return instruction.Not(line);
                    case "xor": return instruction.Xor(line);
                    case "mov": return instruction.Mov(line);
                    case "in": return instruction.IN(line);
                    case "out": return instruction.OUT(line);
                    case "jmp": return instruction.JMP(line, ref i, totalLines, test);
                    case "cmp": return instruction.CMP(line);
                    case "je": return instruction.JE(line, ref i, totalLines, test);
                    case "jne": return instruction.JNE(line, ref i, totalLines, test);
                    case "jge": return instruction.JGE(line, ref i, totalLines, test);
                    case "jl": return instruction.JL(line, ref i, totalLines, test);
                    case "ADD": return instruction.Add(line);
                    case "SUB": return instruction.Sub(line);
                    case "MUL": return instruction.Mul(line);
                    case "DIV": return instruction.Div(line);
                    case "AND": return instruction.And(line);
                    case "OR": return instruction.Or(line);
                    case "NOT": return instruction.Not(line);
                    case "XOR": return instruction.Xor(line);
                    case "MOV": return instruction.Mov(line);
                    case "IN": return instruction.IN(line);
                    case "OUT": return instruction.OUT(line);
                    case "JMP": return instruction.JMP(line, ref i, totalLines, test);
                    case "CMP": return instruction.CMP(line);
                    case "JE": return instruction.JE(line, ref i, totalLines, test);
                    case "JNE": return instruction.JNE(line, ref i, totalLines, test);
                    case "JGE": return instruction.JGE(line, ref i, totalLines, test);
                    case "JL": return instruction.JL(line, ref i, totalLines, test);
                    default: return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Nepravilan unos!!");
                return true;
            }
            
        }

    }
}

