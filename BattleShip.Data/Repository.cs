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
        public List<Location> Clicks { get; set; } = new List<Location>();
        public List<Location> ClicksExtended { get; set; } = new List<Location>();
        public int[,] Field { get; set; } = new int[12, 12];
        public int[] Cells { get; set; } = new int[4] { 4, 3, 2, 1 };
        public List<string> LabelContent { get; set; } = new List<string>
        {
            "Hint: Place one ship of any type\nby clicking on cells.",
            "Hint: Cell already exists.",
            "Hint: You cannot place ship near\nexisting one.",
            "Hint: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.",
            "Hint: Maximum size of a ship is 4 cells.\nUse \"Add ship\" to place current ship firstly.",
            "Hint: Cell added.",
            "Hint: Place ship firstly.",
            "Hint: You do not have any\nships of this type left.",
            "Hint: Ship added.",
            "Hint: Place all ships firstly.",
            "Hint: Field cleared."
        };
    }
}
