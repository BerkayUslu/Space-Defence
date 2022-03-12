using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //config Params
    [Range(1f, 10f)] [SerializeField] float moveSpeedX = 10f;
    [Range(1f, 10f)] [SerializeField] float moveSpeedY = 10f;
    [SerializeField] Vector2 laserVelocity = new Vector2(0f, 20f);
    [SerializeField] Vector3 distanceBtwLaserAndShip = new Vector3(0, 0.6f, 1);
    [SerializeField] float padding = 0.5f;
    [SerializeField] GameObject laserShootImage;
    [SerializeField] Text scoreText;
    [SerializeField] float timeBetweenLasers = 0.4f;


    //
    private Coroutine firingCoroutine;
    float startTime;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    //

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        //0-1 kordinat sisteminde kameranın belirli noktasının World Space pozisyonu
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    //
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedX;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedY;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }


    IEnumerator FireContinuously()
    {
        while (true)
        {
            Instantiate(laserShootImage, transform.position + distanceBtwLaserAndShip, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenLasers);
        }
    }

    public Vector2 GetLaserVelocity()
    {
        return laserVelocity;
    }

}
