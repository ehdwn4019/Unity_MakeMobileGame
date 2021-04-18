using UnityEngine;
using System.Collections;

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //

public class Plane : MonoBehaviour {
	public GameObject prop;
	public GameObject propBlured;

	public bool engenOn;

    public static Plane instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update () 
	{
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * 3 *Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.forward * -3 * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * 3 * Time.deltaTime);


		if (engenOn) {
			prop.SetActive (false);
			propBlured.SetActive (true);
			propBlured.transform.Rotate (1000 * Time.deltaTime, 0, 0);
		} else {
			prop.SetActive (true);
			propBlured.SetActive (false);
		}
	}
}

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //