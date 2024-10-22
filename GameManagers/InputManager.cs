using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    [SerializeField] Touch touch;
    [SerializeField] Vector2 touchPosition;
    [SerializeField] Collider2D touchCollider;
    [SerializeField] GameObject lastObjectTouched;


    public Touch GetTouch() {
        return touch;
    }

    public Vector2 GetTouchPosition()
    {
        return touchPosition;
    }


    public Collider2D GetTouchCollider()
    {
        return touchCollider;
    }

    public GameObject GetLastObjectTouched()
    {
        return lastObjectTouched;
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {

        DetectTouch();






    }

    void DetectTouch() {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase != TouchPhase.Began)
            {
                return;
            }


            
            touchCollider = Physics2D.OverlapPoint(touchPosition);



            if (touchCollider != null)
            {
                lastObjectTouched = touchCollider.gameObject;

                if (lastObjectTouched.tag == GlobVars.oreTag)
                {

                    Actions.OrePressed();
                }

                if (lastObjectTouched.tag == GlobVars.powerupTag)
                {
                    Actions.PowerupUsed(lastObjectTouched.GetComponent<Powerup>());
                }
            }

        }
    }
}
