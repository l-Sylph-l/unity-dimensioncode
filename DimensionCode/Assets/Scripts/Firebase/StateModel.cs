using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateModel
{
    public string email;

    public string level;

    public string part;

    public StateModel(string email, string level, string part)
    {
        this.email = email;
        this.level = level;
        this.part = part;
    }

    //public string Email { get => email; set => email = value; }
    //public double Level { get => level; set => level = value; }
    //public double Part { get => part; set => part = value; }
}
