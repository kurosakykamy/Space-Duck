using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGscroll : MonoBehaviour {

    public float speed = 0;
    public float pos = 0;
    public GameObject duck;
    public Material sky;
    private Material mat;

	// Use this for initialization
	void Start () {

        mat = GetComponent<Renderer>().material;
		
	}



    // Update is called once per frame
    void Update()
    {

        var vel = duck.GetComponent<Rigidbody2D>().velocity.x;

        if (vel != 0f)
        {

            var side = duck.transform.localScale.x;
            pos += speed * side;


            mat.mainTextureOffset = new Vector2(speed * Time.deltaTime, -1);
        }


        if (SceneManager.GetActiveScene().name == "lv1")
        {

            if (duck.GetComponent<Transform>().position.x >= 313)
            {
                GetComponent<Renderer>().material = sky;
            }
            if (duck.GetComponent<Transform>().position.x < 313)
            {
                GetComponent<Renderer>().material = mat;

            }
        }
    }
}

