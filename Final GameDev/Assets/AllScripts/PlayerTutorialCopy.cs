using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Text for the tutorial level, displays text after the player has reached a certain range
public class PlayerTutorialCopy : MonoBehaviour
{
    private int tutorialscompleted = 0;
    public Transform target;
    [SerializeField] private TMP_Text tutorialtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 12f && tutorialscompleted  < 1) {
            tutorialtext.text = "Oh no! Looks like there are gaps up ahead! you can get past them by using the space button to jump!";
            tutorialscompleted++;
        } else if(transform.position.x > 50f && tutorialscompleted < 2) {
            tutorialtext.text = "These are collectables in the game, you can collect coins to increase your score, and health potions to recover your health";
            tutorialscompleted++;
        } else if(transform.position.x > 78f && tutorialscompleted < 3) {
            tutorialtext.text = "And To Complete The Level, You need to collect a treasure chest like this!";
            tutorialscompleted++;
        } else if(transform.position.x > 96f && tutorialscompleted < 4) {
            tutorialtext.text = "This one isn't real, We still have more of the tutorial to go! But you will collect one at the end of the level";
            tutorialscompleted++;
        } else if(transform.position.x > 114f && tutorialscompleted < 5) {
            tutorialtext.text = "There are even bigger gaps ahead, Your normal jumps wont seem to reach that far...., But you can press shift to sprint and cover that extra distance!";
            tutorialscompleted++;
        } else if(transform.position.x > 205f && tutorialscompleted < 6) {
            tutorialtext.text = "Now Lets meet your enemies, This is Elite, His specailty is attacking you from a distance by throwing his sword";
            tutorialscompleted++;
        } else if(transform.position.x > 241f && tutorialscompleted < 7) {
            tutorialtext.text = "and for your other enemy, Here's Grunt, Unlike Elite, He confronts you directly by using his sword in close combat";
            tutorialscompleted++;
        } else if(transform.position.x > 265f && tutorialscompleted < 8) {
            tutorialtext.text = "These enemies can drain your health bar, which is shown in the top left corner. (Did you notice?), If your helath drops to 0, It's game over, Now for some hands-on practice. Good luck!";
            tutorialscompleted++;
        } else if(transform.position.x > 265f && tutorialscompleted < 9) {
            tutorialtext.text = "";
            tutorialscompleted++;
        } 
    }
}
