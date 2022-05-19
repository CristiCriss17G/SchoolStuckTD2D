using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;
    private float startZ;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        startZ = transform.position.z;
        rend.material.color = hoverColor;
    }

    void OnMouseEnter()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        rend.material.color = hoverColor;
        Debug.Log("Mouse Hover");
    }
    
    void OnMouseExit()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
        rend.material.color = startColor;
        Debug.Log("Mouse Exit");
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.TurretToBuild;
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }
}
