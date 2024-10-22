using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobVars
{

    //tags
    public static string rockTag = "Rock";
    public static string gemTag = "Gem";
    public static string oreTag = "Ore";
    public static string powerupTag = "Powerup";


    //gems directory
    public static Sprite[] gems = Resources.LoadAll<Sprite>("Sprites/Gems");


    public static int fixedUpdateRate = (int)(1/Time.fixedDeltaTime);

    public static float gameSpeed = 0.5f;


}
