using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			//var encoder = Encoding.ASCII;
			vm.RegisterCommand('.', b => { write((char)b.Memory[b.MemoryPointer]); });
			vm.RegisterCommand('+', b => { b.Memory[b.MemoryPointer] = unchecked((byte)(b.Memory[b.MemoryPointer]+1)); });
			vm.RegisterCommand('-', b => { b.Memory[b.MemoryPointer] =unchecked((byte)(b.Memory[b.MemoryPointer]-1)); });
            vm.RegisterCommand(',', b => { b.Memory[b.MemoryPointer] = (byte)read.Invoke(); });
			vm.RegisterCommand('>', b => { 
				
				if (b.MemoryPointer < b.Memory.Length-1)
					b.MemoryPointer++;
				else
					b.MemoryPointer = 0; 
			});

			vm.RegisterCommand('<', b => {
                if (b.MemoryPointer == 0)
                    b.MemoryPointer=b.Memory.Length-1;
                else
                    b.MemoryPointer--; 
			});

			var chars1 = CharactersBetween('A', 'Z');
            var chars2 = CharactersBetween('a', 'z');
            var chars3 = CharactersBetween('0', '9');

			var allChars = chars1.Concat(chars2).Concat(chars3);

            foreach (var c in allChars)
			{
				vm.RegisterCommand(c, b => { b.Memory[b.MemoryPointer] = (byte)c; });
			}


        }

        public static char[] CharactersBetween(char start, char end)
        {
            return Enumerable.Range(start, end - start + 1).Select(c => (char)c).ToArray();
        }
    }
}