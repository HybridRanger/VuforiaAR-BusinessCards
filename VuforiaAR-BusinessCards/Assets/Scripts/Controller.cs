using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Controller : MonoBehaviour
{
    public int scale;
    public GameObject prefab;
    public string parentName;
    //public int numberOfCards;

    private string imageFilePath = "Assets/Resources/Images/";
    private string imageSearchFilter = "*.png";
    private string[] images;
    private int numberOfCards;
    private GameObject[,] arr;
    private int length;


    void Start()
    {
        UpdateImages();
    }

    void Update()
    {

    }



#region GUI control
    private void OnGUI()
    {
        if (GUILayout.Button("UpdateImages"))
        {
            foreach (GameObject card in arr)
            {
                Destroy(card, 0.0f);
            }

            Array.Clear(arr, 0, arr.Length);
            UpdateImages();
        }

        //numberOfCards = Convert.ToInt32(GUI.TextField(new Rect(10, 30, 200, 20), Convert.ToString(numberOfCards), 4));
    }
#endregion



#region update business card images
    private void UpdateImages()
    {
        int count = 0;

        images = (Directory.GetFiles(imageFilePath, imageSearchFilter, SearchOption.TopDirectoryOnly));

        numberOfCards = images.Length;

        length = (int)Mathf.Ceil(Mathf.Sqrt(numberOfCards));

        Debug.Log(length);

        arr = new GameObject[length, length];

        for (int z = 0; z < length; z++)
        {
            for (int x = 0; x < length; x++)
            {
                float
                xPos = (float)((x - (length / 2)) * scale * 0.6),
                zPos = (float)((z - (length / 2)) * scale * 0.9);

                arr[z, x] = Instantiate(prefab, new Vector3(zPos, 0, xPos), Quaternion.identity) as GameObject;
                arr[z, x].transform.parent = GameObject.Find(parentName).transform;

                if (count < images.Length && count < numberOfCards)
                {
                    SetTexture(images[count], x, z);
                    count++;
                }
            }
        }
    }
#endregion



#region set card texture
    private void SetTexture(string image, int x, int z)
    {
        Texture2D texture = Resources.Load((image.Substring(17, 13))) as Texture2D;
        Material material = new Material(Shader.Find("Diffuse"))
        {
            mainTexture = texture
        };
        arr[z, x].GetComponent<Renderer>().sharedMaterial = material;
    }
#endregion
}
