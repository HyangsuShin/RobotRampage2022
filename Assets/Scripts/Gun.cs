using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;          //the speed at which the gun will fire
    protected float lastFireTime;   //tracks the last time the gun was fired.
    
    // Start is called before the first frame update
        void Start()
    {
        lastFireTime = Time.time - 10;  //could fire the gun immediately when the game start
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected void Fire()
    {
        GetComponentInChildren<Animator>().Play("Fire");
    }
}
