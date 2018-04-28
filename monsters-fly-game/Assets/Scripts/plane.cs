using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.AI;

public class plane : MonoBehaviour {

    const int Left_mouse=0;
    float time = 10;
    

    public static Vector3 defaultVector = new Vector3(-0.6496f, -31.386f, -71.33f);

    Vector3 lBound = new Vector3(-20, 0, 0);
    Vector3 rBound = new Vector3(130, 0, 0);

    Vector3 downBound = new Vector3(0, 0, 40);
    Vector3 upBound = new Vector3(0, 0, 192);

    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);


    bool surounded = false;
    List<GameObject> xRight;
    List<GameObject> xLeft;
    List<GameObject> zUp;
    List<GameObject> zDown;

    public NavMeshSurface surfaces;
    




    // variable for create wall
    public int flagUp = 2;
    public int flagRight = 2;

    public int weightWall = 0;
    public int heightWall = 0;


    public bool flagEnter = true;
    public Vector3 positionPlane;


    public int UpWall = 2;
    public int RightWall = 2;
    List<GameObject> WallMeshReder = new List<GameObject>();

    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;

	// Use this for initialization
	void Start () {
       
        defaultVector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //alternatively, just: originalPos = gameObject.transform.position;
      //  CompletePlanWithCube();

        positionPlane = new Vector3(transform.position.x,transform.position.y, transform.position.z);
	}

    void CreateBubble(float x,float y,float z)
    {
        Vector3 v = new Vector3(x, y, z-7);
      //  UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/point.prefab", typeof(GameObject));
        //Instantiate(prefab, v, Quaternion.identity);
        UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/cubeWall.prefab", typeof(GameObject));
        
        
       



        if(Level.value==1)
         prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/cubeWall.prefab", typeof(GameObject));
        if(Level.value==2)
             prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/cubeWall2.prefab", typeof(GameObject));
        if(Level.value==3)
                prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/cubeWall3.prefab", typeof(GameObject));



      //  surfaces = Instantiate(prefab, v, Quaternion.identity) as NavMeshSurface;
        
        //surfaces.SetActive(true);
        //NavMeshSurface
      //  surfaces.BuildNavMesh(); 
        // NavMeshSurface surfaces;*/
      //  GameObject newObject = Instantiate(prefab, v, Quaternion.identity) as GameObject;
      //  surfaces.BuildNavMesh(); 
      
          
       
        
     
    }
    void CompletePlanWithCube()
    {
        Vector3 v = new Vector3(-24.4f, 212.4f, 34.11f);

        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                v = new Vector3(-24.4f + (i * 2.5f), 212.4f, 34.11f + (j * 2.5f));
                UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/cubeWall.prefab", typeof(GameObject));

                GameObject newObject = Instantiate(prefab, v, Quaternion.identity) as GameObject;
            }
        }
    }

    int GetClosestObject(string tag, GameObject ball)
    {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        int len = objectsWithTag.Length;

        int allSides = 0;

        xRight = new List<GameObject>();
        xLeft = new List<GameObject>();
        zUp = new List<GameObject>();
        zDown = new List<GameObject>();
        int c1 = 0, c2 = 0, c3 = 0, c4 = 0;

        foreach (GameObject obj in objectsWithTag)
        {

            if (ball.transform.position.x - obj.transform.position.x < 0 && ball.transform.position.x - obj.transform.position.x > -200)
            {
                xRight.Add(obj);
                c1++;
                //Debug.Log("x " + (ball.transform.position.x - obj.transform.position.x));
            }


            if (ball.transform.position.x - obj.transform.position.x > 0 && ball.transform.position.x - obj.transform.position.x < 200)
            {
                xLeft.Add(obj);
                c2++;
                //Debug.Log("-x " + (ball.transform.position.x - obj.transform.position.x));
            }

            if (ball.transform.position.z - obj.transform.position.z < 0 && ball.transform.position.z - obj.transform.position.z > -200)
            {
                zUp.Add(obj);
                c3++;
                // Debug.Log("z " + (transform.position.z - obj.transform.position.z));
            }

            if (ball.transform.position.z - obj.transform.position.z > 0 && ball.transform.position.z - obj.transform.position.z < 200)
            {
                zDown.Add(obj);
                c4++;
                //Debug.Log("-z " + (transform.position.z - obj.transform.position.z));
            }

        }

        if (c1 > 0 && c2 > 0 && c3 > 0 && c4 > 0)
        {
            Debug.Log("yessss");
            surounded = true;
        }

        if (surounded == true)
        {
            // Debug.Log("Z " + zUp.Length +" - X "+ xRight.Length+xLeft.Length);

            foreach (GameObject zobj in zUp)
            {

                foreach (GameObject xobj in xRight)
                {
                    if (zobj.transform.position == xobj.transform.position)
                    {
                        Debug.Log("1");
                        allSides += 1;
                        flag1 = true;
                        break;
                    }
                }

                if (flag1 == true)
                {
                    break;
                }

            }



            foreach (GameObject zobj in zUp)
            {
                foreach (GameObject xobj2 in xLeft)
                {
                    if (zobj.transform.position == xobj2.transform.position)
                    {
                        Debug.Log("2");
                        allSides += 1;
                        flag2 = true;
                        break;
                    }
                }
                if (flag2 == true)
                {
                    break;
                }
            }




            foreach (GameObject zobj in zDown)
            {
                //  Debug.Log("10");
                foreach (GameObject xobj in xRight)
                {
                    if (zobj.transform.position == xobj.transform.position)
                    {
                        Debug.Log("3");
                        allSides += 1;
                        flag3 = true;
                        break;
                    }
                }

                if (flag3 == true)
                {
                    break;
                }

            }

            foreach (GameObject zobj in zDown)
            {

                foreach (GameObject xobj2 in xLeft)
                {
                    if (zobj.transform.position == xobj2.transform.position)
                    {
                        Debug.Log("4");
                        allSides += 1;
                        flag4 = true;
                        break;
                    }
                }

                if (flag4 == true)
                {
                    break;
                }
            }

        }


        return allSides;
    }

    /*
    void createWall(float x, float y, float z,int UpWall,int RightWall,int height,int weight )
    {

       Vector3 vScale=new Vector3(2.5f + weight * 2.5f,
            3.378598f,
             10 + height * 2.5f);

     //  Vector3 v = new Vector3(x + (weight * 2.5f / 2), y, z - 2.5f);

       if (RightWall == 0)
       {
            v = new Vector3(x + (weight * 2.5f / 2), y, z-2.5f);
       }
       if (RightWall == 1)
       {
            v = new Vector3(x - (weight * 2.5f / 2), y, z-2.5f);
       }

        UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/cubeWall.prefab", typeof(GameObject));

        GameObject newObject = Instantiate(prefab, v, Quaternion.identity) as GameObject;

        newObject.transform.localScale =  vScale;


       

    }

   
    void appearWall()
    {
        foreach (GameObject obj in wall.WallMeshReder)
        {
            Renderer rend = obj.GetComponent<Renderer>();
            rend.enabled = true;
        }

        wall.WallMeshReder.Clear();
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "4Wall")
        {

           createWall(positionPlane.x, positionPlane.y, positionPlane.z, UpWall, RightWall,heightWall, weightWall);
            
           // appearWall();

            UpWall = 2;
            RightWall = 2;
            flagUp = 2;
            flagRight = 2;
            weightWall = 0;
            heightWall = 0;
            flagEnter = true;
            
           Debug.Log("in wall");
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "4Wall")
        {
            positionPlane = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            weightWall = 0;
            heightWall = 0;
            UpWall = 2;
            RightWall = 2;
            flagUp = 2;
            flagRight = 2;
            flagEnter = false;
           
            Debug.Log("out wall");
        }
    }
    */
	// Update is called once per frame
	void Update () {


        
         /*  if (this.GetClosestObject("cubeWall", ball1)==4)
            {
                Level.value = 1;
            }*/
        if (money.value%60 == 0 && money.value!=0)
        {
            heart.increase();
        }
            if (heart.value>=(3+2*Level.value))
            {
                win.value = 1;
            }

        if (Input.GetKey("right") && transform.position.x < rBound.x && flagRight!=1)
        {
            CreateBubble(transform.position.x , transform.position.y - 1f, transform.position.z);
            transform.Translate(right*speed.value);
            if (!flagEnter)
            {
                flagRight = 0;
                weightWall++;
            }
            flagUp = 2;
            
            RightWall = 0;
            
        }

        if (Input.GetKey("left") && transform.position.x > lBound.x && flagRight!=0)
        {
            if (!flagEnter)
            {
                flagRight = 1;
                weightWall++;
            }
            RightWall = 1;
            flagUp = 2;
            
            CreateBubble(transform.position.x , transform.position.y-1f, transform.position.z);
            transform.Translate(left*speed.value);
           
        }

        if (Input.GetKey("up") && transform.position.z < upBound.z && flagUp !=1 )
        {
            CreateBubble(transform.position.x, transform.position.y-1f, transform.position.z );
            transform.Translate(0,-1*speed.value,0);
            if (!flagEnter)
            {
                flagUp = 0;
                heightWall++;
            }
            UpWall = 0;
            flagRight = 2;
            
        }

        if (Input.GetKey("down") && transform.position.z > downBound.z && flagUp != 0)
        {
            if (!flagEnter)
            {
                flagUp = 1;
                heightWall++;
            }
            flagRight = 2;
            UpWall = 1;
            CreateBubble(transform.position.x, transform.position.y - 1f, transform.position.z);
            transform.Translate(0,1*speed.value,0);
            
        }
	}
	}
