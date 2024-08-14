using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int live = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (live<0)
        {
            Destroy(gameObject);
        }
    }

    internal void RecibeDamage(int damage=20)
    {
        live-=damage;
    }
}
