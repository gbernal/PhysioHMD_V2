using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightDir : MonoBehaviour
{
	public GameObject lighter;
	public GameObject cam;
	Vector3 dir;
    public GameObject leftCube;
    public GameObject rightCube;
	// Update is called once per frame
	void Update ()
	{
		//lighter.transform.position = cam.transform.position;
		lighter.transform.LookAt(this.gameObject.transform);
        leftCube.GetComponent<Renderer>().material.color = Color.white;
        rightCube.GetComponent<Renderer> ().material.color = Color.white;
        RayDetect();

    }

    void RayDetect()
    {
        print(1);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, this.gameObject.transform.position - cam.transform.position, out hit))
        {
            if (hit.transform.gameObject.tag == "Box")
            {
                hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                print(hit.transform.gameObject.name);
            }
        }
    }
}
