using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

namespace ISA_Simulator
{
    class Instructions
    {
        public Memory memory = new Memory();

        private long DetermineArgument(string s)
        {
            if (s.Contains("h"))
            {
                s = s.Replace("h", "");
                return Convert.ToInt64(s, 16);
            }

            if (s.Contains("r"))
            {
                if (s.Equals("r1")) return memory.r1;
                else if (s.Equals("r2")) return memory.r2;
                else if (s.Equals("r3")) return memory.r3;
                else if (s.Equals("r4")) return memory.r4;
            }

            if (s.Contains("0x"))
            {
                string temp = s.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                byte data = memory.FindAddressValue(tempLong);
                if (data == 0)
                {
                    Console.WriteLine("Memorijska lokacija " + s + " nije koristena do sada, u njoj se ne nalaze podaci.");
                    return 0;
                }
                return data;
            }

            if(s.Contains("["))
            {
                string temp = s.Replace("[", "");
                temp = temp.Replace("]", "");
                if (temp.Equals("r1")) return memory.FindAddressValue(memory.r1);
                else if (temp.Equals("r2")) return memory.FindAddressValue(memory.r2);
                else if (temp.Equals("r3")) return memory.FindAddressValue(memory.r3);
                else if (temp.Equals("r4")) return memory.FindAddressValue(memory.r4);
                else return 0;
            }

            else
            {
                try
                {
                    long.Parse(s);
                }
                catch (Exception)
                {
                    Console.WriteLine("Broj: " + s + " ne može da se definiše kao long.");
                    throw;
                }
                return Convert.ToInt64(s);
            }
        }
        public bool Add(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch(Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch(temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) + result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) + result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) + result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) + result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long addr = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(addr, (byte) (memory.FindAddressValue(addr) + result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    memory.r1 += result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    memory.r2 += result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    memory.r3 += result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    memory.r4 += result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }
        }

        public bool Mov(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];

            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)result);
                return false;
            }

            switch (s1)
            {
                case "r1":
                    memory.r1 = result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    memory.r2 = result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    memory.r3 = result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    memory.r4 = result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }


        }

        public bool Sub(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];
            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }


            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) - result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) - result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) - result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) - result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)(memory.FindAddressValue(tempLong) - result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    memory.r1 -= result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    memory.r2 -= result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    memory.r3 -= result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    memory.r4 -= result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }

            

           

        }

        public bool Mul(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];
            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) * result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) * result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) * result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) * result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)(memory.FindAddressValue(tempLong) * result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    memory.r1 *= result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    memory.r2 *= result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    memory.r3 *= result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    memory.r4 *= result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }

        }

        public bool Div(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];
            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) / result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) / result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) / result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) / result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)(memory.FindAddressValue(tempLong) / result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    memory.r1 /= result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    memory.r2 /= result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    memory.r3 /= result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    memory.r4 /= result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }

            
        }

        public bool And(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];
            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) & result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) & result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) & result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) & result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)(memory.FindAddressValue(tempLong) & result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    long temp = Convert.ToInt64(memory.r1);
                    memory.r1 = temp & result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    temp = Convert.ToInt64(memory.r2);
                    memory.r2 = temp & result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    temp = Convert.ToInt64(memory.r3);
                    memory.r3 = temp & result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    temp = Convert.ToInt64(memory.r4);
                    memory.r4 = temp & result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }
            
        }

        public bool Or(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];
            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) | result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) | result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) | result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) | result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)(memory.FindAddressValue(tempLong) | result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    long temp = Convert.ToInt64(memory.r1);
                    memory.r1 = temp | result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    temp = Convert.ToInt64(memory.r2);
                    memory.r2 = temp | result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    temp = Convert.ToInt64(memory.r3);
                    memory.r3 = temp | result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    temp = Convert.ToInt64(memory.r4);
                    memory.r4 = temp | result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }

        }

        public bool Not(string line)
        {
            line = line.Substring(4);
            long result;

            

            switch (line)
            {
                case "r1":
                    result = Convert.ToInt64(memory.r1);
                    memory.r1 = ~result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    result = Convert.ToInt64(memory.r2);
                    memory.r2 = ~result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    result = Convert.ToInt64(memory.r3);
                    memory.r3 = ~result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    result = Convert.ToInt64(memory.r4);
                    memory.r4 = ~result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }    

            
        }

        public bool Xor(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string s1 = strlist[1];
            string s2 = strlist[2];
            if (s1.Contains("0x") && s2.Contains("0x")) return true;

            long result;
            try
            {
                result = DetermineArgument(s2);
            }
            catch (Exception)
            {
                return true;
            }

            if (s1.Contains("["))
            {
                string temp = s1.Replace("[", "");
                temp = temp.Replace("]", "");
                switch (temp)
                {
                    case "r1":
                        memory.WriteInAddress(memory.r1, (byte)(memory.FindAddressValue(memory.r1) ^ result));
                        return false;
                    case "r2":
                        memory.WriteInAddress(memory.r2, (byte)(memory.FindAddressValue(memory.r2) ^ result));
                        return false;
                    case "r3":
                        memory.WriteInAddress(memory.r3, (byte)(memory.FindAddressValue(memory.r3) ^ result));
                        return false;
                    case "r4":
                        memory.WriteInAddress(memory.r4, (byte)(memory.FindAddressValue(memory.r4) ^ result));
                        return false;
                    default: return true;
                }
            }

            if (s1.Contains("0x"))
            {
                string temp = s1.Replace("0x", "");
                long tempLong = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(tempLong, (byte)(memory.FindAddressValue(tempLong) ^ result));
                return false;
            }

            switch (s1)
            {
                case "r1":
                    long temp = Convert.ToInt64(memory.r1);
                    memory.r1 = temp ^ result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    temp = Convert.ToInt64(memory.r2);
                    memory.r2 = temp ^ result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3":
                    temp = Convert.ToInt64(memory.r3);
                    memory.r3 = temp ^ result; ;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    temp = Convert.ToInt64(memory.r4);
                    memory.r4 = temp ^ result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }
        }

        public bool OUT(string line)
        {
            line = line.Substring(4);

            if (line.Contains("0x"))
            {
                string temp = line.Replace("0x", "");
                long addr = Convert.ToInt64(temp, 16);
                Console.WriteLine("Sadrzaj memorijske lokacije 0x"+ addr.ToString("X").ToLower() + ": " + memory.FindAddressValue(addr));
                return false;
            }

            switch (line)
            {
                case "r1":
                    Console.WriteLine("Sadrzaj registra r1: " + memory.r1);
                    return false;
                case "r2":
                    Console.WriteLine("Sadrzaj registra r2: " + memory.r2);
                    return false;
                case "r3":
                    Console.WriteLine("Sadrzaj registra r3: " + memory.r3);
                    return false;
                case "r4":
                    Console.WriteLine("Sadrzaj registra r4: " + memory.r4);
                    return false;
                default: return true;
            }
        }

        public bool IN(string line)
        {
            line = line.Substring(3);
            Console.WriteLine("Unesite vrijednost: ");
            string input = Console.ReadLine();
            long result = Convert.ToInt64(input);

            if (line.Contains("0x"))
            {
                string temp = line.Replace("0x", "");
                long addr = Convert.ToInt64(temp, 16);
                memory.WriteInAddress(addr, (byte)result);
                return false;
            }

            switch (line)
            {
                case "r1":
                    memory.r1 = result;
                    Console.WriteLine("Promjena u registru r1: " + memory.r1);
                    return false;
                case "r2":
                    memory.r2 = result;
                    Console.WriteLine("Promjena u registru r2: " + memory.r2);
                    return false;
                case "r3": 
                    memory.r3 = result;
                    Console.WriteLine("Promjena u registru r3: " + memory.r3);
                    return false;
                case "r4":
                    memory.r4 = result;
                    Console.WriteLine("Promjena u registru r4: " + memory.r4);
                    return false;
                default: return true;
            }
        }
        public bool CMP(string line)
        {
            char[] spearator = { ' ', ',' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            long arg1 = DetermineArgument(strlist[1]);
            long arg2 = DetermineArgument(strlist[2]);

            long result = arg1 - arg2;
            if(result == 0) memory.zf = 1;
            else if(result >= 0) memory.sf = 1;
            else if(result<0) memory.of = 1;

            return false;
        }

        public bool JMP(string line, ref int lineNum, int totalLines, string[] test)
        {
            
            //string label = line.Substring(4);
            char[] spearator = { ' ' };
            String[] strlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            string label = strlist[1];

            int tempLineNum = 1;
            for(int i = 1; i<=totalLines; i++)
            {
                if (test[i-1].StartsWith(label))
                {
                    lineNum = tempLineNum;
                    memory.resetFlags();
                    return false;
                }
                tempLineNum++;
            }

            if (tempLineNum >= totalLines)
            {
                Console.WriteLine("Navedena labela nije nadjena.");
                memory.resetFlags();
                return false;
            }

            memory.resetFlags();
            return false;

        }

        public bool JE(string line, ref int lineNum, int totalLines, string[] test)
        {
            if (memory.zf == 1) return JMP(line, ref lineNum, totalLines, test);
            else return false;
        }

        public bool JNE(string line, ref int lineNum, int totalLines, string[] test)
        {
            if (memory.zf == 0) return JMP(line, ref lineNum, totalLines, test);
            else return false;
        }

        public bool JGE(string line, ref int lineNum, int totalLines, string[] test)
        {
            if (memory.sf == 1) return JMP(line, ref lineNum, totalLines, test);
            else return false;
        }

        public bool JL(string line, ref int lineNum, int totalLines, string[] test)
        {
            if (memory.of == 1) return JMP(line, ref lineNum, totalLines, test);
            else return false;
        }

        
    }
}
