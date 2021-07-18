using UnityEngine;
using Events;
public class Target : MonoBehaviour
{
    public ParticleSystem onDestroyParticles;
    [SerializeField] float health = 100f;
    [SerializeField] [Range(2, 10)] float scoreBonusMultiplier = 2f;
    [SerializeField] float distanceWhereBonusNoLongerApplies = 5f;
    [SerializeField] TransformRef PlayerPosition;
    [SerializeField] GameObject damageTextPrefab;
    public bool isBoss = false;
    private Vector3 playerPosition;
    private DetachChildren detacher;

    private void Start()
    {
        detacher = GetComponent<DetachChildren>();

        if (PlayerPosition == null)
        {
            playerPosition = Vector3.zero;
            return;
        }

        playerPosition = PlayerPosition.value.position;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            var distanceMultiplier = Vector3.Distance(transform.position, playerPosition);

            var multiplier = distanceMultiplier > distanceWhereBonusNoLongerApplies ? Mathf.RoundToInt(distanceMultiplier) : scoreBonusMultiplier * distanceMultiplier;

            if (isBoss)
            {
                multiplier *= scoreBonusMultiplier;
            }

            GameManagerSingleton.instance.GetScore().IncreaseScore(multiplier);
            TryInstantiateDamageText(Mathf.RoundToInt(multiplier), distanceMultiplier);

            Die();
        }
    }

    private void TryInstantiateDamageText(int damageValue, float distance)
    {
        if (damageTextPrefab == null)
        {
            Debug.LogError("no damange text prefab found.");
            return;
        }

        var facePlayer = Quaternion.Euler((transform.position - PlayerPosition.GetPosition()).normalized);
        var instance = Instantiate(damageTextPrefab, this.transform.position, facePlayer);

        var setTextScript = instance.GetComponent<SetUIText>();
        if (setTextScript == null)
        {
            Debug.LogError($"the game object [{instance.gameObject.name}] does not have the SetTextUI script.");
        }
        else
        {
            setTextScript.SetLabel($"{damageValue}");
        }

        var resizeScript = instance.GetComponent<DistanceResize>();
        if (resizeScript == null)
        {
            Debug.LogError($"the game object [{instance.gameObject.name}] does not have the DistanceResize script.");
        }
        else
        {
            resizeScript.Scale(distance);
        }

        var animateDmgScore = instance.GetComponent<AnimateDamageScore>();
        if (animateDmgScore == null)
        {
            Debug.LogError($"the game object [{instance.gameObject.name}] does not have the aniamteDmgScore script.");
        }
        else
        {
            animateDmgScore.SetColorRange(GameManagerSingleton.instance.GetHitRangeEnum(distance));
        }
    }

    public void Die()
    {
        if (detacher != null)
            detacher.DetachAndInvoke();

        Destroy(gameObject);
        ParticleSystem particles = Instantiate(onDestroyParticles, transform.position, transform.rotation);
        Color cubeColor = GetComponentInChildren<MeshRenderer>().material.color;
        particles.GetComponent<ParticleSystemRenderer>().material.color = cubeColor;
    }
}

