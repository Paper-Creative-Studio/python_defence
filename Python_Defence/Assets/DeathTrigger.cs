using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class DeathTrigger : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text tip;
    public Sprite iconSprite;
    [TextArea]
    public string texttext;
    [TextArea]
    public string tiptext;
    public WaveSpawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RollIn()
    {

        icon.sprite = iconSprite;
        
        text.text = texttext;
        tip.text = tiptext;
        gameObject.SetActive(true);
        player.GetComponent<Health>().alive = false;
        StartCoroutine(WaitforOut());
        
    }
    public void CastleRollIn()
    {
        for(int i =0; i< spawner.aliveEnemies.Count; i++)
        {
            
            Destroy(spawner.aliveEnemies[i].gameObject);
        }
        spawner.lose = true;
        icon.sprite = iconSprite;

        text.text = texttext;
        tip.text = tiptext;
        gameObject.SetActive(true);
        player.GetComponent<Health>().alive = false;
        StartCoroutine(WaitforOut());

    }
    IEnumerator WaitforOut()
    {
        yield return new WaitForSecondsRealtime(3);
        player.transform.position = spawnpoint.position;
        Health script = player.GetComponent<Health>();
        anim.SetTrigger("Fadeout");
        script.alive = true;
        script.currentHealth = script.maxHealth;
        StartCoroutine(Disable());
    }
    IEnumerator Disable()
    {
        yield return new WaitForSecondsRealtime(3);
        gameObject.SetActive(false);
    }
    
}
