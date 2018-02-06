using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public float carSpeed;
    public float maxPos = 1.2f;
    Vector3 position;
   public  UImanager ui;

    public audiomanager am;
    bool currentPlatformAndroid = true;
    Rigidbody2D rb;
	// Use this for initialization
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif
        am.carSound.Play();
    }
	void Start () {
      
        position = transform.position;
	}

    void AccelorometerMove()

    {
        float x = Input.acceleration.x;
        Debug.Log("X =" + x);
       if (x<-0.1f)
        {
            transform.Translate(x, 0, 0);
        }
        else if(x>0.1f)
        {
            transform.Translate(x, 0, 0);
        }
        else
        {
            //SetVelocityZero();
        }
    }	
	// Update is called once per frame
	void Update () {
        if (currentPlatformAndroid == true)
        {
            // android specific
             TouchMove();
            AccelorometerMove();

        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -1.2f, 1.2f);
            transform.position = position;
        }
        position = transform.position;
        position.x = Mathf.Clamp(position.x, -1.2f, 1.2f);
        transform.position = position;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
       if ( col.gameObject.tag == "EnemyCar")
        {
            //  Destroy(gameObject);
            gameObject.SetActive(false);
            ui.gameOverActivated();
            am.carSound.Stop();
        }
    }
    void TouchMove()
    {
if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if (touch.position.x < middle && touch.phase== TouchPhase.Began)
            {
                MoveLeft();

            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }

        }
else
        {
            SetVelocityZero();
        }
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }
    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }
}
