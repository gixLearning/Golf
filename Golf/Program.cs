using System;

namespace Golf {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("### GOLF ME BRO! ###");
            Console.Read();

            Player player = new Player();
            Game game = new Game(player);
            game.Play();

            if(game.GameEnded) {
                Console.WriteLine("No more golf, bro, you won!");
                game.ShowLog();
            }

            Console.ReadKey();
        }
    }
}