using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SettingsData
{

    public static List<Position> Locations = new List<Position>{
            new Position { ID = 0, isAvailable = true, Location = new Vector3(-7f, 1, -3.6f), isBlack = true},
            new Position { ID = 1, isAvailable = true, Location = new Vector3(-3f, 1, -3.6f), isBlack = true },
            new Position { ID = 2, isAvailable = true, Location = new Vector3(1f, 1, -3.6f), isBlack = true },
            new Position { ID = 3, isAvailable = true, Location = new Vector3(5f, 1, -3.6f), isBlack = true },
            new Position { ID = 4, isAvailable = true, Location = new Vector3(7f, 1, 3.6f), isBlack = false },
            new Position { ID = 5, isAvailable = true, Location = new Vector3(3f, 1, 3.6f), isBlack = false },
            new Position { ID = 6, isAvailable = true, Location = new Vector3(-1f, 1, 3.6f), isBlack = false },
            new Position { ID = 7, isAvailable = true, Location = new Vector3(-5f, 1, 3.6f), isBlack = false } };

    public static int BlackKarma = 100;
    public static int WhiteKarma = 100;
}

public class Position
{
    public string TakenBy { get; set; }
    public int ID { get; set; }
    public bool isBlack { get; set; }
    public bool isAvailable { get; set; }
    public Vector3 Location { get; set; }
}
