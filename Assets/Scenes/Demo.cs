using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] GameObject ball, spinner;
    [SerializeField] float speed = 10f;
    bool showAnim = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            ball.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            showAnim = true;
        }
        if(Input.GetKey(KeyCode.DownArrow))
            ball.transform.Translate(Vector3.back * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftArrow))
            ball.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.RightArrow))
            ball.transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        if(ball.transform.position.z > 5 && showAnim){
            showAnim = false;
            spinner.SetActive(true);
            StartCoroutine("HideSpinner");
        }
    }

    IEnumerator HideSpinner(){
        yield return new WaitForSeconds(2);
        spinner.SetActive(false);
    }
}
