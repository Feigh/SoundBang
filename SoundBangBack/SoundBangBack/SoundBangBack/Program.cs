using System;

namespace SoundBangBack
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Server Started");
			GameHandler handler = new GameHandler();
			handler.GameLoop();
		}
	}
}
