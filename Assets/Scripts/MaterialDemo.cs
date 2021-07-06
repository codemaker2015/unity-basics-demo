using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDemo : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Texture2D texture;
    [SerializeField] Color color = Color.red;
    [SerializeField] LightType lightType = LightType.Directional;
    [SerializeField] GameObject cube;
    Light lightComp = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject lightGameObject = new GameObject("The Light");
        lightComp = lightGameObject.AddComponent<Light>();
        lightComp.color = Color.blue;
        lightComp.type = lightType;
        lightGameObject.transform.position = new Vector3(0, 5, 0);
        
        // StartCoroutine(GetBooks("https://retrofit-backend-demo.herokuapp.com/book"));
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) lightComp.GetComponent<Light>().enabled = true;  
        if (Input.GetKey(KeyCode.DownArrow)) lightComp.GetComponent<Light>().enabled = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)){
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("Hit: " + hit.collider.name);
        }
 
    }

    // void Start()
    // {
    //     MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
    //     meshRenderer.material = material;
    //     meshRenderer.material.mainTexture = texture;
    //     meshRenderer.material.color = color;
    //     meshRenderer.material.SetColor("_Color", Color.blue);
    //     meshRenderer.material.EnableKeyword("_EMISSION");
    //     meshRenderer.material.SetColor("_EmissionColor", Color.yellow);
    //     meshRenderer.material.shader = Shader.Find("Standard (Specular setup)");
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    IEnumerator GetBooks(string url) {
        using (WWW www = new WWW(url)) {
            yield return www;
            Debug.Log("Reponse: " + www.text[1]);
        }
    }
}
