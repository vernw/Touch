using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

    public static Master instance = null;

    private static int _startingLife;
    public int startingLife
    {
        get { return _startingLife; }
        set
        {
            // Constrained from 10-40
            if (value < 10)
                _startingLife = 10;
            else if (value > 40)
                _startingLife = 40;
            else
                _startingLife = value;
        }
    }

    private static int _totalPlayers = 2;
    public int totalPlayers
    {
        get { return _totalPlayers; }
        set
        {
            // Constrained from 0-6
            if (value < 0)
                _totalPlayers = 0;
            else if (value > 6)
                _totalPlayers = 6;
            else
                _totalPlayers = value;

            UpdatePlayers();
            InitPlayers();
        }
    }

    void Awake()
    {
        // Ensures singleton status of Master
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        // Start with two players by default
        InitPlayers();
    }

    void UpdatePlayers()
    {
        // Divides screen space for players
        switch (totalPlayers)
        {
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }

    public void InitPlayers()
    {
        // TODO: Init all players
        for (int i = 0; i < totalPlayers; i++)
        {

        }
    }
}
