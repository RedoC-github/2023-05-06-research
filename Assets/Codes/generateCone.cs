using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.ConeMesh;

public class generateCone : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obj;
    public Material[] mat;
    float calcHeight(float r, float u0, float nu) {
        return r*r*u0/(8*nu);
    }
    float calcRange(float r, float t, float nu) {
        return 2 * Mathf.Sqrt(6*t*nu/(r*r*Mathf.PI));
    }
    void Start()
    {
        string path = "Assets/data.dat";
        string[] rawdata = System.IO.File.ReadAllLines(path);

        for (int idx = 0; idx < rawdata.Length; idx++) {
            string[] data = rawdata[idx].Split('/');

            GameObject objref = Instantiate (obj, new Vector3(float.Parse(data[0]),0,float.Parse(data[1])), Quaternion.identity);
            float H = 0, R = 0;
            float nu = 100f / 2.6f;

            float[,] consts = {{8f,1.5f,1f},{15f,1f,2f},{20f,1.25f,6f},{30f,1.5f,15f}}; //r u0 t
            switch (data[2])
            {
                case "소":
                H = calcHeight(consts[0,0],consts[0,1],nu); R = calcRange(consts[0,0],consts[0,2],nu);
                objref.GetComponent<Cone>().Material = mat[3];
                break;
                case "중":
                H = calcHeight(consts[1,0],consts[1,1],nu); R = calcRange(consts[1,0],consts[1,2],nu);
                objref.GetComponent<Cone>().Material = mat[2];
                break;
                case "대":
                H = calcHeight(consts[2,0],consts[2,1],nu); R = calcRange(consts[2,0],consts[2,2],nu);
                objref.GetComponent<Cone>().Material = mat[1];
                break;
                case "특대":
                H = calcHeight(consts[3,0],consts[3,1],nu); R = calcRange(consts[3,0],consts[3,2],nu);
                objref.GetComponent<Cone>().Material = mat[0];
                break;
            }
            objref.GetComponent<Cone>().ConeRadius = R;
            objref.GetComponent<Cone>().ConeHeight = H;
            Debug.Log((R,H));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
