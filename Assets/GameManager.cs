using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    [SerializeField] private float dataScaleDif = 100f;

    public static GameManager Instance { get { return instance; } }
    public float DataScaleDif { get { return this.dataScaleDif; } }

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

}
