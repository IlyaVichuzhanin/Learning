using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }

		public Dictionary<char, Action<IVirtualMachine>> Commands = new Dictionary<char, Action<IVirtualMachine>>();

		public VirtualMachine(string program, int memorySize)
		{
			Memory = new byte[memorySize];
			MemoryPointer = 0;
			Instructions = program;
			InstructionPointer = 0;
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
            Commands.Add(symbol, execute);
		}

		public void Run()
		{
			for (var i = InstructionPointer; InstructionPointer < Instructions.Length; InstructionPointer++)
			{
				if (Commands.ContainsKey(Instructions[InstructionPointer]))
				{
                    Commands[Instructions[InstructionPointer]].Invoke(this);
                }
			}	
		}
	}
}