using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable {

    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;


    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            if(!isOpen) {
                //Open the chest
                OpenChest();
            }else {
                //Chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest() {
        // Dialog window on 
        dialogBox.SetActive(true);
        // Dialog text = contents text
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // Raise the signal to the player to animate
        raiseItem.Raise();
        // Raise the context clue
        context.Raise();
        // set the chest to opened
        isOpen = true;
        anim.SetBool("opened", true);
    }
    public void ChestAlreadyOpen() {
        // Dialog off
        dialogBox.SetActive(false);
        // raise the signal to the player to stop animating
        raiseItem.Raise();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen) {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen) {
            context.Raise();
            playerInRange = false;
        }
    }
}
