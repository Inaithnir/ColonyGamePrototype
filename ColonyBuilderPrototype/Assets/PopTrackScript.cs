using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEngine;

public class PopTrackScript : MonoBehaviour
{
    int Population;
    Text MyText;

    // Start is called before the first frame update
    void Start() {
        Population = Colony.PlayerColony.ColonyPopulation;
        MyText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        Population = Colony.PlayerColony.ColonyPopulation;
        MyText.text = "Population: " + Population;
    }
}
