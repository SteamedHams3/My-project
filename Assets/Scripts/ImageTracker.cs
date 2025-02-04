using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; // include xr library

public class ImageTracker : MonoBehaviour
{
[SerializeField]
ARTrackedImageManager m_TrackedImageManager;

public GameObject shipPrefab;// image to appear on marker image
public GameObject FlagPrefab; // image to appear on marker image

void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
{
    AudioSource source = GetComponent<AudioSource>();
    foreach (var newImage in eventArgs.added)
    {
        // Handle added event
        
        GameObject newObject = GameObject.Instantiate(shipPrefab);
        newObject.transform.SetParent(newImage.transform, false);
        source.Play();

        if(newImage.referenceImage.name == "boat") {
            GameObject.Instantiate (FlagPrefab);
            newObject.transform.SetParent(newImage.transform, false);
            source.Play();
        }
    }

    foreach (var updatedImage in eventArgs.updated)
    {
        // Handle updated event
    }

    foreach (var removedImage in eventArgs.removed)
    {
        // Handle removed event
    }
}
}
