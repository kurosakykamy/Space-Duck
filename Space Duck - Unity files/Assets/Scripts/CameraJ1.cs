using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraJ1 : MonoBehaviour
{

    private Vector2 velocity;

    public float delayX;
    public float delayY;

    public Transform duck;

    public bool Bounds;
    public Vector3 MinCamaraPos;
    public Vector3 MaxCamaraPos;

    // Update is called once per frame
    void Update()
    {

        float posX = Mathf.SmoothDamp(transform.position.x, duck.position.x, ref velocity.x, delayX);
        float posY = Mathf.SmoothDamp(transform.position.y, duck.position.y, ref velocity.y, delayY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (Bounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, MinCamaraPos.x, MaxCamaraPos.x),
                Mathf.Clamp(transform.position.y, MinCamaraPos.y, MaxCamaraPos.y),
                Mathf.Clamp(transform.position.z, MinCamaraPos.z, MaxCamaraPos.z)
                );

        }


        if(SceneManager.GetActiveScene().name == "lv1")
        {

        if ((duck.position.x > 401 && duck.position.y > 22) || (duck.position.x > 433))
        {
            //MinCamaraPos.y = duck.position.y + 3;
            MinCamaraPos = Vector3.Lerp(MinCamaraPos, new Vector3(MinCamaraPos.x, duck.position.y + 3, MinCamaraPos.z),Time.deltaTime * 5);
        }

        if ((duck.position.x < 230) || (duck.position.x > 325  && duck.position.x < 400))
        {
            //MinCamaraPos.y = -3.19f;
            MinCamaraPos = Vector3.Lerp(MinCamaraPos, new Vector3(MinCamaraPos.x, -3.19f, MinCamaraPos.z), Time.deltaTime * 5);
        }

        if (duck.position.x > 230 && duck.position.x < 325)
        {
            //MinCamaraPos.y = duck.position.y + 2;
            MinCamaraPos = Vector3.Lerp(MinCamaraPos, new Vector3(MinCamaraPos.x, duck.position.y + 2, MinCamaraPos.z), Time.deltaTime * 5);

        }

        }

        if (SceneManager.GetActiveScene().name == "lv2")
        {
            MinCamaraPos = Vector3.Lerp(MinCamaraPos, new Vector3(MinCamaraPos.x, duck.position.y + 3, MinCamaraPos.z), Time.deltaTime * 5);

            if (duck.position.x > 570f)
            {
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 12f;
            }


        }

        if (SceneManager.GetActiveScene().name == "lv3")
        {
            MinCamaraPos = Vector3.Lerp(MinCamaraPos, new Vector3(MinCamaraPos.x, duck.position.y + 2, MinCamaraPos.z), Time.deltaTime * 5);




        }
    }

}
