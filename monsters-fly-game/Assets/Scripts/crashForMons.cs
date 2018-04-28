using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class crashForMons : MonoBehaviour {
    
    public GameObject expl;
    public Text LifeText;
    public AudioSource sourcePlane;
    public AudioSource sourceFire;

    IEnumerator OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("plane"))
        {
            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/FX_Kandol_Pack/FX_effect_sprite_image01/fx_fumefx/Prefabs/fx_fumefx_fireball.prefab", typeof(GameObject));
            GameObject clone = Instantiate(expl, transform.position, Quaternion.identity) as GameObject;
            clone.SetActive(true);
            heart.decrease();
            this.sourcePlane.Play();
            this.LifeText.text = heart.value + "";

            yield return new WaitForSeconds(2);
           
            other.gameObject.transform.position = plane.defaultVector+new Vector3(0,0,0);
            clone.SetActive(false);
           

        }
        else if (! other.gameObject.CompareTag("4Wall") 
            && ! other.gameObject.CompareTag("backGround")
            && !other.gameObject.CompareTag("point")
            && ! other.gameObject.CompareTag("ball")
            && !other.gameObject.CompareTag("hardBall")
            && !other.gameObject.CompareTag("ground")
            && !other.gameObject.CompareTag("spawner")
            && !other.gameObject.CompareTag("monster")
        && !other.gameObject.CompareTag("partPlane")
             && !other.gameObject.CompareTag("cubeWall"))
        {
           

            Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);

            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/fireWork.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;
            clone.SetActive(true);


            this.sourceFire.Play();
            clone.SetActive(true);
            GameObject myObjectEat = other.gameObject;
           
            myObjectEat.SetActive(false);
            yield return new WaitForSeconds(5);
            clone.SetActive(false);
        }


    }
}
