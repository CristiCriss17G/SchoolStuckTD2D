using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    /*public Color hoverColor;*/
    public Vector3 spawnOffset = new(0, 0, -0.1f);

    private GameObject turret;

    private Renderer rend;
    private Color startColor;
    private float startZ;

    public GameObject gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        /*startColor = rend.material.color;
        startZ = transform.position.z;
        rend.material.color = hoverColor;*/
        rend.enabled = false;
    }

    void OnMouseEnter()
    {
        /*transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        rend.material.color = hoverColor;*/
        rend.enabled = true;
        /*Debug.Log("Mouse Hover");*/
    }

    void OnMouseExit()
    {
        /*transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
        rend.material.color = startColor;*/
        rend.enabled = false;
        /*Debug.Log("Mouse Exit");*/
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there");
            return;
        }


        GameObject turretToBuild = BuildManager.instance.TurretToBuild;
        if (Score.coins >= turretToBuild.GetComponent<Turret>().Cost)
        {
            Score.coins -= turretToBuild.GetComponent<Turret>().Cost;
            turret = Instantiate(turretToBuild, transform.position + spawnOffset, transform.rotation);
            BuildManager.turretIndex++;
            if (BuildManager.turretIndex > 0 && BuildManager.turretIndex % 5 == 0)
                turretToBuild.GetComponent<Turret>().Cost++;
        }
        else
        {
            Debug.Log("Not enough money");
            // TO DO: Not enough money popup
            gameMaster.GetComponent<Score>().Pulse();
        }
    }
}
