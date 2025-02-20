using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ISA_Simulator
{
    class Memory
    {
        Dictionary<long, byte> Addresses = new Dictionary<long, byte>();
        public long r1, r2, r3, r4; 
        public int zf = 0;
        public int sf = 0;
        public int of = 0;

        public void resetFlags()
        {
            zf = 0;
            sf = 0;
            of = 0;
        }
        
        public byte FindAddressValue(long addr)
        {
            if (Addresses.ContainsKey(addr)) return Addresses[addr];
            return 0;
        }

        public void WriteInAddress(long addr, byte data)
        {
            Console.WriteLine("Promjena u memoriji na lokaciji 0x" + addr.ToString("X").ToLower() + ": " + data);
            try
            {
                Addresses.Add(addr, data);
            }
            catch (ArgumentException)
            {
                Addresses[addr] = data;
            }

        }


    }
}
