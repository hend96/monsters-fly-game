using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class T_Ball : MonoBehaviour
{
    public GameObject expl;
    public Text LifeText;
    public AudioSource sourcePlane;
    public AudioSource sourceFire;

    
    // Use this for initialization
    IEnumerator OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("plane"))
        {
            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/FX_Kandol_Pack/FX_effect_sprite_image01/fx_fumefx/Prefabs/fx_fumefx_fireball.prefab", typeof(GameObject));
            GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            clone.SetActive(true);
            heart.decrease();

            this.sourcePlane.Play();
            this.LifeText.text = heart.value + "";
           
            other.gameObject.transform.position = plane.defaultVector+new Vector3(0,0,0);
            clone.SetActive(false);
           

        }

        if (other.gameObject.CompareTag("cubeWall"))
        {
            if (Level.value == 3)
            {
                other.gameObject.SetActive(false);
                Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);

                Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/fireWork.prefab", typeof(GameObject));

                GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;
                clone.SetActive(true);


                this.sourceFire.Play();
                clone.SetActive(true);
                GameObject myObjectEat = other.gameObject;

                myObjectEat.SetActive(false);
                yield return new WaitForSeconds(0);
                clone.SetActive(false);
            }
        }
        


    
        



         }
}
