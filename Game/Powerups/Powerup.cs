using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] protected int uses;

    protected virtual void OnEnable() {
        Actions.PowerupUsed += detectPowerupPressed;
    }

    protected virtual void OnDisable()
    {
        Actions.PowerupUsed -= detectPowerupPressed;
    }

    public virtual void applyPowerUp() {
        Debug.Log("Parent Called");
    }

    public virtual void removePowerUp()
    {

    }

    public virtual void detectPowerupPressed(Powerup pwr) {

    
        if (uses <= 0) {
            return;
        }
        

        if (this.GetType() == pwr.GetType()) {
            uses--;
            applyPowerUp();
        }
    }


}
