using System.Collections.Generic;

namespace BattleShip.Data
{
    public class Repository
    {
        private static Repository _repository;

        public static Repository GetInstance()
        {
            if (_repository == null)
                _repository = new Repository();

            return _repository;
        }

        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Ship> EnemyShips { get; set; } = new List<Ship>();
        public List<Location> Clicks { get; set; } = new List<Location>();
        public List<Location> ClicksExtended { get; set; } = new List<Location>();
        public int[,] Field { get; set; } = new int[12, 12];
        public int[] Cells { get; set; } = new int[4] { 4, 3, 2, 1 };
        public Dictionary<int, string> LabelContent { get; set; } = new Dictionary<int, string>()
        {
            { 0, "Hint: Place one ship of any type\nby clicking on cells." },
            { 1, "Hint: Cell already exists." },
            { 2, "Hint: You cannot place ship near\nexisting one." },
            { 3, "Hint: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly." },
            { 4, "Hint: Maximum size of a ship is 4 cells.\nUse \"Add ship\" to place current ship\nfirstly." },
            { 5, "Hint: Cell added." },
            { 6, "Hint: Place ship firstly." },
            { 7, "Hint: You do not have any\nships of this type left." },
            { 8, "Hint: Ship added." },
            { 9, "Hint: Place all ships firstly." },
            { 10, "Hint: Field cleared." },
            { 11, "Hint: Clear current field firstly." },
            { 12, "Hint: Ships placed randomly." },
            { 13, "Hint: You do not have any\nships to place. Use\"Start game\"\nto play or \"Clear field\"to place\nships again." }
        };
    }
}
