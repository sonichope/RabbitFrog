using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckData
{
    public readonly static DeckData Instance = new DeckData();
    public bool deckSetFlag = true;
    public DeckObject[] deckObjects = new DeckObject[8];
}
