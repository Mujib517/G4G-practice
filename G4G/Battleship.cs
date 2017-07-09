using System;
using System.Collections.Generic;
using System.Linq;

public class Battle
{
    public  string Solution(int N, string S, string T)
    {
        var ships = ParseShips(S);
        var hits = ParseHits(T);

        int touched = 0, sunk = 0;

        foreach (var ship in ships)
        {
            var noOfHits = ship.GetHits(hits);
            if (noOfHits > 0)
            {
                if (noOfHits == ship.Size)
                    sunk++;
                else
                    touched++;
            }
        }

        return "" + sunk + "," + touched;
    }

    public List<Position> ParseHits(string strHits)
    {
        var hits = new List<Position>();
        var positions = strHits.Split(' ');
        hits.AddRange(positions.Select(pos => new Position(pos)));
        return hits;
    }

    public IEnumerable<Ship> ParseShips(string strShips)
    {
        var ships = new List<Ship>();
        var shipPositions = strShips.Split(',');
        foreach (var shipCoord in shipPositions)
        {
            string[] pos = shipCoord.Split(' ');
            ships.Add(new Ship(new Position(pos[0]), new Position(pos[1])));
        }
        return ships;
    }
}

public class Ship
{
    public Position TopLeft { get; set; }
    public Position BottomRight { get; set; }

    public Ship(Position topLeft, Position bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public int Size
    {
        get
        {
            return (Math.Abs(TopLeft.X - BottomRight.X) + 1)
                * (Math.Abs(TopLeft.Y - BottomRight.Y) + 1);
        }
    }

    public override string ToString()
    {
        return "(" + TopLeft + ", " + BottomRight + ")";
    }

    public int GetHits(List<Position> positions)
    {
        int hits = 0;
        foreach (var position in positions)
        {
            if (position.Compare(TopLeft) && BottomRight.Compare(position))
                hits++;
        }
        return hits;
    }
}

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(string str)
    {
        X = (str.ToUpper()[1]) - ('A');
        Y = (str[0]) - ('1');
    }

    public bool Compare(Position p2)
    {
        return X >= p2.X && Y >= p2.Y;
    }

    public override string ToString()
    {
        return "(" + X + ", " + Y + ")";
    }
}