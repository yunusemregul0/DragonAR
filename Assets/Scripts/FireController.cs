using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject atesEfekti; 
    public GameObject kafaPrefab;
    public void AtesEt()
    {
        kafaPrefab = GameObject.FindWithTag("Head");
        if (atesEfekti != null)
        {
            var dragon = GameObject.FindWithTag("Dragon");
            if (dragon != null)
            {
                Debug.Log("Rotation: " + gameObject.transform.rotation);
                Debug.Log("Kafa PreFab Position: " + kafaPrefab.transform.position);
                GameObject fire = Instantiate(atesEfekti, kafaPrefab.transform.position, dragon.transform.rotation);
                Destroy(fire, 2.3f);
            }
        }
    }
}
