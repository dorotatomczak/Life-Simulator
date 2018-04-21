using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//option to choose when interacting with object in the house

public class Option {

    string text;

    public string Text // copied from Rate in Stat, intention: create getter and setter
    {
        get
        {
            return text;
        }
        set
        {
            this.Text = text;
        }
    }

    public void Initialize(string text)
    {
        this.Text = text;
    }

}
