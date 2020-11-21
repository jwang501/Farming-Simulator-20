using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Tools : MonoBehaviour
{
    public GameObject dcane;
    public GameObject can;
    public GameObject seeds;
    public Camera camera;
    public Image cane;
    public Image water;
    public Image seed;
    public Image cane2;
    public Image water2;
    public Image seed2;
    private int currentTool;
    public Animator anim;
    public ParticleSystem vfx;
    public Text get_score;

    private static int score;
    // Start is called before the first frame update
    void Start()
    {
        currentTool = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkTool();
        if (Input.GetButtonDown("Fire1"))
        {
            action();
        }
        get_score.text = score.ToString();
        Debug.Log(score.ToString());
    }
    void checkTool()
    {   
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentTool = (currentTool - 1);
            if (currentTool < 0) currentTool += 3;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentTool = (currentTool + 1) % 3;
        }
        if (currentTool == 0)
        {
            dcane.SetActive(true);
            can.SetActive(false);
            seeds.SetActive(false);
            cane.transform.localScale = new Vector3(1.7f,1.1f,1);
            seed.transform.localScale = new Vector3(1.5f, 1, 1);
            water.transform.localScale = new Vector3(1.5f, 1, 1);
        }
        if (currentTool == 1)
        {
            dcane.SetActive(false);
            can.SetActive(true);
            seeds.SetActive(false);
            water.transform.localScale = new Vector3(1.7f, 1.1f, 1);
            seed.transform.localScale = new Vector3(1.5f, 1, 1);
            cane.transform.localScale = new Vector3(1.5f, 1, 1);
        }
        if (currentTool == 2)
        {
            dcane.SetActive(false);
            can.SetActive(false);
            seeds.SetActive(true);
            seed.transform.localScale = new Vector3(1.7f, 1.1f, 1);
            cane.transform.localScale = new Vector3(1.5f, 1, 1);
            water.transform.localScale = new Vector3(1.5f, 1, 1);
        }
        seed2.transform.localScale = seed.transform.localScale * 1.04f;
        water2.transform.localScale = water.transform.localScale * 1.04f;
        cane2.transform.localScale = cane.transform.localScale * 1.04f;
    }

    void action()
    {   
        if (currentTool == 0) {
            anim.SetTrigger("trigger");
        }
        if (currentTool == 1)
        {
            vfx.Play();
        }
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit, 10))
        {
            Soil_Behavior target = hit.transform.GetComponent<Soil_Behavior>();
            if (target != null)
            {
                switch(currentTool)
                {
                    case 0:
                        StartCoroutine(target.harvest());
                        break;
                    case 1:
                        target.water();
                        break;
                    case 2:
                        target.plant();
                        break;
                }
            }
        }
    }
    public static void stack()
    {
        score+=6;
    }
}
