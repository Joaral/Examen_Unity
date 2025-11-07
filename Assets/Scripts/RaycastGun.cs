using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LineRenderer line;
    public float lineFadeSpeed;
    public LayerMask mask;
    public float knockbackForce = 10;
    public GameObject player;
    void Update()
    {
        //raycast
        Ray ray = new Ray(player.transform.position, player.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, mask))
        {

            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green); // Para el editor
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);// Para el editor
        }

        //Disparo
        line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, line.startColor.a - Time.deltaTime * lineFadeSpeed);
        line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, line.endColor.a - Time.deltaTime * lineFadeSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, 1);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, 1);

            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 1000);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Character"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * knockbackForce, ForceMode.Impulse);
        }
    }
}
