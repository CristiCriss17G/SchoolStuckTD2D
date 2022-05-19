using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    public GameObject TurretToBuild
    {
        get
        {
            return turretToBuild;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
