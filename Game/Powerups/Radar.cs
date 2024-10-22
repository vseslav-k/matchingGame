using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : Powerup
{
    public override void applyPowerUp()
    {

        GameObject[] ores = GameObject.FindGameObjectsWithTag(GlobVars.oreTag);


        Ore ore1 = ores[0].GetComponent<Ore>();
        Ore ore2 = ores[0].GetComponent<Ore>();

        foreach (GameObject i in ores) {

            Ore iore = i.GetComponent<Ore>();

            if (!iore.isGuessed()) {
                ore1 = iore;
                break;
            }

        }



        for(int i = 0; i < ores.Length; i++)
        {
            ore2 = ores[i].GetComponent<Ore>();

            if (ore1 == ore2) {
                continue;
            }

            if (ore2.isGuessed())
            {
                continue;
            }


            if (ore1.getGemIdx() == ore2.getGemIdx()){
                break;
            }

        }

        Player.instance.ForceSetOreSelection(ore1, ore2);



        Debug.Log("Uses: "+uses);
        if (uses <= 0)
        {
            Destroy(gameObject);
        }

    }




}
