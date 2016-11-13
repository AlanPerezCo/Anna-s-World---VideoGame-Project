using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private annaInput player;

    void Start()
    {
        player = gameObject.GetComponentInParent<annaInput>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;

    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}
