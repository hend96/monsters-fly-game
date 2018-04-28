using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class EatPlane : MonoBehaviour {

    public  AudioSource sourceSurpris;
    public  AudioSource sourceSlow;
    public  AudioSource sourceSpeed;
    
    public AudioSource sourceKids;
   
    public  Text timeText;
    public  Text LifeText;
    public  Text moneyText;
    public Text levelText;


  
    void winLoadAnotherSense()
    {
        Level.increase();
        if (Level.value <= 3)
        {
            
            switch (Level.value)
            {
                case 2:
                    time.value = 60f;
                    speed.value = 3;

                    Application.LoadLevel("level_2");
                    break;
                case 3:
                    time.value = 60f;
                    speed.value = 3;
                    Application.LoadLevel("level_3");
                    break;

            }
        }
        else
        {
            time.value = 60f;
            speed.value = 2;
            Level.value = 1;
            heart.value=3;
            money.value = 0;
            Application.LoadLevel("finish");
        }
    }

	// Use this for initialization
	void Start () {

        this.levelText.text = "0"+Level.value + "";
        this.timeText.text = time.value + "";
        this.moneyText.text = money.value + "";
        this.LifeText.text = heart.value + "";
	}

   
	// Update is called once per frame
     void Update()
    {

        if (win.value == 1)
        {
            this.winLoadAnotherSense();
            win.value = 0;
            money.value = 0;
        }
        if (heart.value<= 0)
        {
            heart.value = 3;
            time.value = 60f;
            money.value = 0;
            Level.value = 1;
            win.value = 0;
            
          //  new WaitForSeconds(20);
            
            Application.LoadLevel("menu");
        }

	}
     public void OnTriggerEnter(Collider collision)
    {
       

        if (collision.gameObject.tag == "question")
        {
         //   this.winLoadAnotherSense();
            System.Random ran = new System.Random();
            int x = ran.Next(1, 4);

            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
            GameObject clone = new GameObject();

            UnityEngine.Object perfab = new UnityEngine.Object();

            switch(x){

                case 1:
           perfab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/time.prefab", typeof(GameObject));

            clone = Instantiate(perfab, v, Quaternion.identity) as GameObject;
            time.increase();

            this.timeText.text = time.value + "";
            break;
                case 2:
                   perfab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/life.prefab", typeof(GameObject));

                    clone = Instantiate(perfab, v, Quaternion.identity) as GameObject;
            
            heart.increase();
            this.LifeText.text = heart.value + "";
                
            break;
                case 3:
                    perfab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/bouns.prefab", typeof(GameObject));

            clone = Instantiate(perfab, v, Quaternion.identity) as GameObject;

            
            money.increase();

            this.moneyText.text = money.value + "";

            break;
            }

            clone.SetActive(true);
            collision.gameObject.SetActive(false);

            this.sourceSurpris.Play();

        }

        if (collision.gameObject.tag == "speed")
        {
            

            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
             
             UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/speed.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

            clone.SetActive(true);


            collision.gameObject.SetActive(false);


            if (speed.value == 1 && Level.value == 1 ||
                speed.value == 2 && (Level.value == 1 || Level.value == 2))
            {
                C_Speed.flag = true;
                 speed.increase();
            }


            sourceSpeed.Play();
            


        }

        if (collision.gameObject.tag == "slow")
        {
           

            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);

            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/slow.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

            clone.SetActive(true);


            collision.gameObject.SetActive(false);

            if (speed.value == 2 && Level.value==1 ||
                speed.value==3 && (Level.value==1 ||Level.value==2) )
            {
                C_slow.flag = true;
                speed.decrease();
            }

            
            sourceSlow.Play();


        }
        if (collision.gameObject.tag == "heart")
        {
            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);

            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/life.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

            clone.SetActive(true);


            collision.gameObject.SetActive(false);
            heart.increase();



            sourceKids.Play();


            this.LifeText.text = heart.value + "";



        }
        if (collision.gameObject.tag == "money")
        {
            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z + 5);

            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/bouns.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

            clone.SetActive(true);

            collision.gameObject.SetActive(false);
            money.increase();

            sourceKids.Play();


            this.moneyText.text = money.value + "";

        }
        if (collision.gameObject.tag == "time")
        {
            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);

            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/time.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

            clone.SetActive(true);




            collision.gameObject.SetActive(false);

            if (time.value < 60)
            {
                time.increase();
            }



            sourceKids.Play();


            this.timeText.text = time.value + "";

        }

    }

}
