using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject particle;
    public float particleCount;
    public GameObject scorchMark;

    void Start()
    {
        Destroy(gameObject,2f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boom")
        {
            Destroy(collision.gameObject);
            //scorchMark.SetActive(true);
            
            for (int i = 0; i < particleCount; i++)
            {
                
                var offset = Random.insideUnitSphere;
                Instantiate(particle, transform.position + offset, transform.rotation);
                Instantiate(scorchMark, transform.position, Quaternion.identity);
            }
            
        }

        Destroy(gameObject);
    }
}