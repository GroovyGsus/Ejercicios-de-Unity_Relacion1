using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 10;
    private SpriteRenderer sprite;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        target = new Vector2(-7.5f, -3.3f);
        position = gameObject.transform.position;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h, 0) * speed;

        if (h > 0)
        {
            sprite.flipX = false;
        }
        else if (h < 0)
        {
            sprite.flipX = true;
        }


        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);



    }



    void OnGUI()
    {
        //Event currentEvent = Event.current;
        //Vector2 mousePos = new Vector2();
        //Vector2 point = new Vector2();

        //// compute where the mouse is in world space
        //mousePos.x = currentEvent.mousePosition.x;
        //mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        //point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        //if (Input.GetMouseButtonDown(0))
        //{
        //    // set the target to the mouse click location
        //    target = point;
        //}




        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();



    }
}
