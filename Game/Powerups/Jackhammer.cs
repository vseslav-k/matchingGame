using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackhammer : Powerup
{

    [SerializeField] float rotationSpeed;
    [SerializeField] float powerupDuration;
    int durationTick=0;
    bool powerupActive=false;

    float originalCooldown;


    private void Start()
    {
        originalCooldown = Player.instance.GetEvalCooldown();
    }

    public override void applyPowerUp() {

        Player.instance.SetEvalCooldown(0.05f);
        powerupActive = true;

    }


    void FixedUpdate()
    {
        powerupTimer();
    }


    void Update()
    {
        animatePowerup();
    }


    void animatePowerup() {
        if (powerupActive)
        {
            Debug.Log("Animating");
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime*100);

        }
    }
    void powerupTimer() {
        if (powerupActive)
        {
            durationTick++;
        }

        if (durationTick >= powerupDuration * GlobVars.fixedUpdateRate)
        {
            removePowerUp();
            durationTick = 0;
        }
    }


    public override void removePowerUp()
    {
        powerupActive = false;
        Player.instance.SetEvalCooldown(originalCooldown);


        if (uses <= 0) {
            Destroy(gameObject);
        }
    }



}
