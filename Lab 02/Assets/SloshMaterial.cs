using UnityEngine;

public class SloshMaterial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float maxRot = 1.0f;
    public Vector2 currRot = Vector2.zero;

    public Vector2 prevPos;

    public float scaling = 2.0f;

    Material myMaterial;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        prevPos = new Vector2(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 motion = currPos - prevPos;
        currRot += motion * scaling;

        currRot *= 0.9f;

        myMaterial.SetFloat("_XRot", currRot.y);
        myMaterial.SetFloat("_ZRot", currRot.x);

        prevPos = currPos;
    }
}
