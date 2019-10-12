using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{

    // Variables 
    public float health;
    public int points;
    public int bombs;
    public float energy;
    public int lives;
    public int rings;
    public enum Laser { Single, Double, Max};
    public Laser laserType;

    // Functions
    public PlayerStatus()
    {
        health = 100f;
        points = 0;
        bombs = 3;
        energy = 100f;
        rings = 0;
        lives = 3;
        laserType = Laser.Single;
    }

    public bool isAlive()
    {
        return health > 0;
    }
}
