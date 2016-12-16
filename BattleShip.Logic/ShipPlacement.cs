using BattleShip.Data;

namespace BattleShip.Logic
{
    public class ShipPlacement
    {
        Repository repo = Repository.GetInstance();

        public int CheckPosition(int x, int y)
        {
            if (repo.Ships.Count != 0)
                foreach (var ship in repo.Ships)
                    foreach (var location in ship.ShipLoc)
                        if (location.x == x && location.y == y)                          
                            return 1;

            foreach (var click in repo.Clicks)
                if (click.x == x && click.y == y)
                    return 1;

            if (repo.Field[x + 1, y + 1] == 4)
                return 2;

            if (repo.Clicks.Count >= 2)
            {
                if (repo.Field[repo.Clicks[1].x, repo.Clicks[1].y] == 1 && repo.Clicks[1].y != y)
                    return 3;

                if (repo.Field[repo.Clicks[1].x, repo.Clicks[1].y] == 2 && repo.Clicks[1].x != x)
                    return 3;
            }

            if (repo.Clicks.Count != 0 && repo.Field[x + 1, y + 1] != 1 && repo.Field[x + 1, y + 1] != 2)
                return 3;

            if (repo.Clicks.Count == 4)
                return 4;

            return 5;
        }
        /*
         0   "Hint: Place one ship of any type\nby clicking on cells.",
         1   "Hint: Cell already exists.",
         2   "Hint: You cannot place ship near\nexisting one.",
         3   "Hint: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.",
         4   "Hint: Maximum size of a ship is 4 cells.\nUse \"Add ship\" to place current ship firstly.",
         5   "Hint: Cell added.",
         6   "Hint: Place ship firstly."
         7   "Hint: You do not have any\nships of this type left."
         8   "Hint: Ship added.",
         9   "Hint: Place all ships firstly."*/
        public int PlaceShip()
        {
            var location = new Location[repo.Clicks.Count];

            if (repo.Clicks.Count == 0)
                return 6;


            if (repo.Cells[repo.Clicks.Count - 1] == 0)
            {         
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                        if (repo.Field[i, j] != 4)
                            repo.Field[i, j] = 0;
                return 7;
            }

            for (int i = 0; i < repo.Clicks.Count; i++)
            {
                location[i] = repo.Clicks[i];
                ShipPlaced(location[i]);
            }

            repo.Ships.Add(new Ship(repo.Clicks.Count, 0, location));
            repo.Cells[repo.Clicks.Count - 1] -= 1;
            repo.Clicks.Clear();

            return 8;
        }

        public bool StartGame()
        {
            for (int i = 0; i < 4; i++)
                if (repo.Cells[i] != 0)
                    return false;

            return true;
        }

        public void FieldPlacement(int x, int y)
        {
            x = x + 1;
            y = y + 1;

            if (repo.Field[x - 1, y - 1] != 3 && repo.Field[x - 1, y - 1] != 4)
                repo.Field[x - 1, y - 1] = 3;
            if (repo.Field[x - 1, y] != 3 && repo.Field[x - 1, y] != 4)
                repo.Field[x - 1, y] = 1;
            if (repo.Field[x - 1, y + 1] != 3 && repo.Field[x - 1, y + 1] != 4)
                repo.Field[x - 1, y + 1] = 3;
            if (repo.Field[x, y - 1] != 3 && repo.Field[x, y - 1] != 4)
                repo.Field[x, y - 1] = 2;
            if (repo.Field[x, y] != 3 && repo.Field[x, y] != 4)
                repo.Field[x, y] = 5;
            if (repo.Field[x, y + 1] != 3 && repo.Field[x, y + 1] != 4)
                repo.Field[x, y + 1] = 2;
            if (repo.Field[x + 1, y - 1] != 3 && repo.Field[x + 1, y - 1] != 4)
                repo.Field[x + 1, y - 1] = 3;
            if (repo.Field[x + 1, y] != 3 && repo.Field[x + 1, y] != 4)
                repo.Field[x + 1, y] = 1;
            if (repo.Field[x + 1, y + 1] != 3 && repo.Field[x + 1, y + 1] != 4)
                repo.Field[x + 1, y + 1] = 3;
        }

        public void ShipPlaced(Location location)
        {
            int x = location.x + 1;
            int y = location.y + 1;

            repo.Field[x - 1, y - 1] = 4;
            repo.Field[x - 1, y] = 4;
            repo.Field[x - 1, y + 1] = 4;
            repo.Field[x, y - 1] = 4;
            repo.Field[x, y] = 4;
            repo.Field[x, y + 1] = 4;
            repo.Field[x + 1, y - 1] = 4;
            repo.Field[x + 1, y] = 4;
            repo.Field[x + 1, y + 1] = 4;
        }

        public void Clear()
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    repo.Field[i, j] = 0;

            repo.Cells = new int[4] { 4, 3, 2, 1 };

            repo.Clicks.Clear();
            repo.ClicksExtended.Clear();
            repo.Ships.Clear();
        }
    }
}
