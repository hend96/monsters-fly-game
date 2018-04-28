using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Touch : MonoBehaviour {

    public GameObject myHeart;
    public GameObject myPlane;
    public AudioSource source;
    public Text LifeText;

    public IEnumerator disappearLife(GameObject clone)
    {
       clone.GetComponent<Object>();
        yield return new WaitForSeconds(1);
        clone.SetActive(false);
    }

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "plane")
        {
            Vector3 v = new Vector3(myHeart.transform.position.x, myHeart.transform.position.y + 20, myHeart.transform.position.z + 10);

            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/life.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

            clone.SetActive(true);

            StartCoroutine(disappearLife(clone));

            // this.GetComponent<SphereCollider>().enabled = false;
            myHeart.SetActive(false);
            heart.increase();

            

            this.source.Play();

            
            this.LifeText.text =  heart.value+"";
          
           /* float lastY = clone.transform.position.y;
            float lastZ = clone.transform.position.z;

           
       while (lastY == 200)
            {
                lastY = clone.transform.position.y;
                lastZ=clone.transform.position.z;
                Vector3 tempV = new Vector3(myHeart.transform.position.x,lastY+10,lastZ+10);
                clone.transform.Translate( tempV);
            }*/

           
        }
    }
}
