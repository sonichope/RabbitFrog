﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckSave : MonoBehaviour
{
    //public static string  cardPoolObject = "null";
    public static string[] cardPoolObject = new string[8];
    public static Image[] iconImage = new Image[8];
    public static Sprite[] nowSprite = new Sprite[8];

    public static bool DeckChack()
    {
        for(int i =0; i < 8; i++)
        {
            if (cardPoolObject[i] != null)
            {
                return false;
            }
        }
        return true;
    }
}