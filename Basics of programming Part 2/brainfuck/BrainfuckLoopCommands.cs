using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class BrainfuckLoopCommands
	{
		public static void RegisterTo(IVirtualMachine vm)
		{
			OpenBraketDict = GetBraketDictionary('[', vm.Instructions);
			ClosedBraketDict = GetBraketDictionary(']', vm.Instructions);


			vm.RegisterCommand('[', b =>
			{
				if (b.Memory[b.MemoryPointer] == 0)
					vm.InstructionPointer = OpenBraketDict[b.InstructionPointer];
			});
			vm.RegisterCommand(']', b =>
			{
				if (b.Memory[b.MemoryPointer] != 0)
					vm.InstructionPointer = ClosedBraketDict[b.InstructionPointer];
			});
		}

		private static Dictionary<int, int> GetBraketDictionary(char keyBraket, string instructions)
		{
			var braketDictionary = new Dictionary<int, int>();
			var keyBraketPositions = new Stack<int>();

			for (var i = 0; i < instructions.Length; i++)
			{
				if (instructions[i] == '[')
					keyBraketPositions.Push(i);
				else if (instructions[i] == ']')
				{
					if (keyBraket == '[')
						braketDictionary.Add(keyBraketPositions.Pop(), i);
					else
						braketDictionary.Add(i, keyBraketPositions.Pop());
				}
			}
			return braketDictionary;
		}

		public static Dictionary<int, int> OpenBraketDict { get; set; }
		public static Dictionary<int, int> ClosedBraketDict { get; set; }

	}
}