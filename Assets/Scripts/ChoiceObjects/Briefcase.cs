using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briefcase : MonoBehaviour
{
    public float maxXrotation;
    public float maxYrotation;
    public float maxZrotation;

    public List<Mesh> meshes;

    // Start is called before the first frame update
    void Start()
    {
        GiveRandomRotation();
        SelectRandomMesh();
    }

    private void SelectRandomMesh()
    {
        int index = UnityEngine.Random.Range(0, meshes.Count);
        GetComponent<MeshFilter>().mesh = meshes[index];
    }

    private void GiveRandomRotation()
    {
        float xRotation = UnityEngine.Random.Range(-maxXrotation, maxXrotation);
        float yRotation = UnityEngine.Random.Range(-maxYrotation, maxYrotation);
        float zRotation = UnityEngine.Random.Range(-maxZrotation, maxZrotation);
        gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
