using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;          //the speed at which the gun will fire
    protected float lastFireTime;   //tracks the last time the gun was fired.

    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;

    public float zoomFactor;// controls the zoom level when the player hits the right mouse button
    public int range;       // how far the gun can effectively hit its target
    public int damage;      // how much damage the gun causes.
    private float zoomFOV;  // the field of view based on the zoom factor
    private float zoomSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
        lastFireTime = Time.time - 10;  //could fire the gun immediately when the game start
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Right Click (Zoom)
        if (Input.GetMouseButton(1))    // hit right mouse button
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,
            zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }
    }

    private void processHit(GameObject hitObject)
    {
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().TakeDamage(damage);
        }
    }

    protected void Fire()
    {
        if (ammo.HasAmmo(tag))
        {
        GetComponent<AudioSource>().PlayOneShot(liveFire);
        ammo.ConsumeAmmo(tag);
        }
        else
        {
        GetComponent<AudioSource>().PlayOneShot(dryFire);
        }               
        GetComponentInChildren<Animator>().Play("Fire");

        // This creates a ray and checks what that ray hits.
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            processHit(hit.collider.gameObject);
        }
    }
}
