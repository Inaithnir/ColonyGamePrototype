using GameEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodTrackScript : MonoBehaviour
{

    public GameData.GoodType GoodToTrack;

    GoodsManager PlayerGoods;
    Text MyText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerGoods = Colony.PlayerColony.getGoodsManager();
        MyText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MyText.text = GoodToTrack.ToString() + ": " + Mathf.RoundToInt(PlayerGoods.getAmount(GoodToTrack));
    }



    public void ChangeTrackingGood(GameData.GoodType TypeToTrack) {
        GoodToTrack = TypeToTrack;
    }
}
