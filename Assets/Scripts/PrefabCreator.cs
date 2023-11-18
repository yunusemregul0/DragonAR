using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
   [SerializeField] private GameObject prefab;
   [SerializeField] protected Vector3 prefabVector;

    private GameObject dragon;
    private ARTrackedImageManager imageManager;

    private void OnEnable()
    {
        imageManager = gameObject.GetComponent<ARTrackedImageManager>();
        imageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage image in args.added)
        {
            var testTransform = image.transform;
            testTransform.rotation = Quaternion.identity;
            dragon = Instantiate(prefab, testTransform);
            dragon.transform.position += prefabVector;
        }
    }

}
