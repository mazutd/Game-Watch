using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
	public delegate void Jumper();
	public static event Jumper OnJumperCrash;
	public static event Jumper OnJumperSave;

	[SerializeField]
    private List<Transform> positions = new List<Transform>();
    public int currentPosition = 1;
    float lastMoveTime;
    float moveDelay = 1.0f;
    float deathDelay = 0.5f;

    private bool dead = false;

    public LayerMask layerMask;

    private void Start()
    {
        UpdatePosition();
        lastMoveTime = Time.time;

        StartCoroutine(Move());
    }


    IEnumerator Move()
    {
        while (!dead)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
            
        }
    }



    void MoveToNextPosition()
    {

        if(currentPosition == 0){

            int[] biomes = new int[] {1,8,13};
            System.Random random = new System.Random();
            int useBiome = random.Next(biomes.Length);
            int pickBiome = biomes[useBiome];
            currentPosition = pickBiome;
        }
        else if(currentPosition == 1 || currentPosition == 8 || currentPosition == 13){
            int[] biomes = new int[] {2,9,11,14};
            System.Random random = new System.Random();
            int useBiome = random.Next(biomes.Length);
            int pickBiome = biomes[useBiome];
            currentPosition = pickBiome;
        }

        else if(currentPosition == 2 || currentPosition == 9 || currentPosition == 11 || currentPosition == 14){
            int[] biomes = new int[] {3,10,12};
            System.Random random = new System.Random();
            int useBiome = random.Next(biomes.Length);
            int pickBiome = biomes[useBiome];
            currentPosition = pickBiome;
        }
   
        else if(currentPosition == 3 || currentPosition == 10 || currentPosition == 12 || currentPosition == 15){
            if(currentPosition == 3){
                currentPosition = 4;
            }
            if(currentPosition == 10){
                currentPosition = 5;
            }
            if(currentPosition == 12){
                currentPosition = 6;
            }

        }

        if (currentPosition >= positions.Count)
        {
            DestroyJumper();
        }
        else
        {
            UpdatePosition();
        }

    }

    void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
        if(positions[currentPosition].gameObject.tag == "DangerPosition")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.down,
                                                    Mathf.Infinity, layerMask);
            //om ingen fireman finns under oss
            if( hit.collider == null)
            {
                StartCoroutine( Crash() );
                if (OnJumperCrash != null)
				    OnJumperCrash();
                    

				//gameManager.JumperCrashed();
            }
            else
            {
                StartCoroutine( Save() );
				if (OnJumperSave != null)
					OnJumperSave();
                    currentPosition = currentPosition+50;
            }

        }
    }

    IEnumerator Crash()
    {
        dead = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(deathDelay);
        DestroyJumper();
    }
    IEnumerator Save()
    {
        dead = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;

        yield return new WaitForSeconds(deathDelay);
    }

    void DestroyJumper()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }


}
