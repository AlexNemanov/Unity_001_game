using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject lazerShot;
    public GameObject lazerGun;
    public float shortDelay;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;

    Rigidbody playerShip;
    float nextShortTime;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float xPosition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        playerShip.position = new Vector3(xPosition, 0, zPosition);

        playerShip.rotation = Quaternion.Euler(playerShip.velocity.z * tilt, 0, - playerShip.velocity.x * tilt);

        if (Time.time > nextShortTime && Input.GetButton("Fire1")) {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
            nextShortTime = Time.time + shortDelay;
        }
    }
}
