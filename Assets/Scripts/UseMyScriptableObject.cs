using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UseMyScriptableObject : MonoBehaviour
{
    public MyScriptableObjectClass myScriptableObject;
    private List<Light> myLights;

	void Start ()
    {
        myLights = new List<Light>();
        foreach (Vector3 spawn in myScriptableObject.spawnPoints)
        {
            GameObject myLight = new GameObject("Light");
            myLight.AddComponent<Light>();
            myLight.transform.position = spawn;
            myLight.GetComponent<Light>().enabled = false;

            SerializedObject halo = new SerializedObject(myLight.GetComponent<Light>());
            halo.FindProperty("m_DrawHalo").boolValue = true;
            halo.ApplyModifiedProperties();

            if (myScriptableObject.colorIsRandom)
            {
                myLight.GetComponent<Light>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            }
            else
            {
                myLight.GetComponent<Light>().color = myScriptableObject.thisColor;
            }
            myLights.Add(myLight.GetComponent<Light>());
        }
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (Light light in myLights)
            {
                light.enabled = !light.enabled;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            UpdateLights();
        }
	}

    void UpdateLights()
    {
        foreach (var myLight in myLights)
        {
            myLight.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }
}
