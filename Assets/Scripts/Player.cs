using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Color defaultColor;
    public Color selectedColor;
    private Material mat;

    private int _life;
    public int life
    {
        get { return _life; }
        set
        {
            // Constrained from 0-999
            if (value < 0)
                _life = 0;
            else if (value > 999)
                _life = 999;
            else
                _life = value;
        }
    }

    private int _infect;
    public int infect
    {
        get { return _infect; }
        set
        {
            // Constrained from 0-10
            if (value < 0)
                _infect = 0;
            else if (value > 10)
                _infect = 10;
            else
                _infect = value;
        }
    }

    private int[] _commander;
    public int[] commander
    {
        get { return _commander; }
        set { _commander = value; }
    }

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.color = defaultColor;
        commander = new int[Master.instance.totalPlayers];
    }

    // Called to assign damage to this Player
    public void takeDamage(int value, bool inf)
    {
        if (!inf)
            life -= value;
        else if (inf)
            infect += value;
    }

    // Called to add life to this Player
    public void gainLife(int value)
    {
        life += value;
    }
}
