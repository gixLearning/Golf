using System;
using System.Collections.Generic;

namespace Golf {

    internal class Game {
        private Player player;
        private const float GRAVITY = 9.8f;
        private const int MAX_SWINGS = 20;
        private const double LENGHT_OF_COURSE = 6580;
        private const double MAX_DISTANCE_AWAY = 10000;
        private List<string> logMessages;
        private double angle;
        private double velocity;

        public bool GameEnded { get; set; }

        public Game(Player player) {
            this.player = player;
            logMessages = new List<string>();
            GameEnded = false;
        }

        public void Play() {
            Console.Clear();
            bool gameEnd = false;
            double distanceLeft = LENGHT_OF_COURSE;
            string input;

            Console.WriteLine($"Distance to hole: {distanceLeft}m");
            Console.ReadLine();

            while (!gameEnd) {
                Console.Write("Swing at what angle? ");
                input = Console.ReadLine();
                angle = double.Parse(input);

                Console.Write("Swing at what force? (m/s)? ");
                input = Console.ReadLine();
                velocity = double.Parse(input);

                player.Swings++;

                double distance = Math.Round(TravelDistance(angle, velocity), 0);
                distanceLeft -= distance;
                distanceLeft = Math.Abs(distanceLeft);

                try {
                    if (player.Swings >= MAX_SWINGS) {
                        throw new TooManySwingsException("Too many swings.");
                    }

                    if (distanceLeft > MAX_DISTANCE_AWAY) {
                        Console.WriteLine($"The golfball flew {distance}m!");
                        throw new TooFarAwayException("Yep, that's too far away");
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message + " : " +  ex.GetType());
                    break;
                }

                LogSwings(distance, player.Swings);

                if (distanceLeft <= 0) {
                    gameEnd = true;
                    GameEnded = true;
                }

                Console.WriteLine($"Traveldistance: {distance}m");
                Console.WriteLine($"Distance left: {distanceLeft}m");
                Console.WriteLine($"Swings: {player.Swings}");
                Console.WriteLine();
            }
        }

        private double TravelDistance(double angle, double velocity) {
            double angleInRadians = (Math.PI / 180) * angle;
            return Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * angleInRadians);
        }

        private void LogSwings(double distance, int swing) {
            string message = String.Format($"Swing {swing}, traveled distance: {distance} m.");
            logMessages.Add(message);
        }

        public void ShowLog() {
            if (logMessages.Count == 0) {
                Console.WriteLine();
                Console.WriteLine("Nothing has been recorded yet.");
            }
            else {
                Console.WriteLine();
                foreach (string log in logMessages) {
                    Console.WriteLine(log);
                }
            }
        }
    }
}