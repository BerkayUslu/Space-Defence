using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetLaserVelocity();
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.1f);
    }

}
