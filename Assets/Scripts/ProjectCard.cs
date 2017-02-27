using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectCard : MonoBehaviour {

    public Text cardName;
    public Text cardExpiryTimeText;
    public int cardExpiryTime;
    public int turnsSincePlayed;
    public Text cardPunishmentText;

    public void SetCardName(string name) {
        cardName.text = name;
        }

    public void SetCardExpiry(int turns) {
        cardExpiryTimeText.text = turns + " turns";
        }

    public void SetCardPunishment(string punishment) {
        cardPunishmentText.text = punishment;
        }

    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, transform.parent.position, 5 * Time.deltaTime);
        }
}
