using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float velocity = 10f;
    public GameObject target;

    private void Update()
    {
        transform.position += transform.TransformDirection(Vector3.left) * (velocity * Time.deltaTime);

        if (target == null) return;
        if ((target.transform.position - transform.position).magnitude < 2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
