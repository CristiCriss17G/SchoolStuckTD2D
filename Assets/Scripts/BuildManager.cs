using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject[] standardTurretPrefabs;
    public static int turretIndex = 0;

    private GameObject turretToBuild;

    private float timeToRandomize = 1f;

    public GameObject TurretToBuild
    {
        get
        {
            return turretToBuild;
        }
    }

    public TextMeshProUGUI turretsCost;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var turret in standardTurretPrefabs)
            turret.GetComponent<Turret>().Cost = turret.GetComponent<Turret>().baseCost;

        turretIndex = 0;
        int turretToChooseIndex = Random.Range(0, standardTurretPrefabs.Length);
        turretToBuild = standardTurretPrefabs[turretToChooseIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToRandomize <= 0)
        {
            int turretToChooseIndex = Random.Range(0, standardTurretPrefabs.Length);
            turretToBuild = standardTurretPrefabs[turretToChooseIndex];
            timeToRandomize = 1f;
        }
        else
        {
            timeToRandomize -= Time.deltaTime;
        }

        turretsCost.text = "";
        foreach (var turret in standardTurretPrefabs)
            turretsCost.text += "Turret " + turret.name + " costs: " + turret.GetComponent<Turret>().Cost + "\n";
    }
}
