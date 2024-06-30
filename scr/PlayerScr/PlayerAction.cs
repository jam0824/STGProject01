using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    private bool isShooting = false; // ���˒����ǂ����̃t���O
    private float nextFireTime = 0f; // ���ɒe�𔭎˂ł��鎞��

    // ���G���Ԃ̕b��
    public float invincibilityDuration = 2.0f;
    // �_�ł���Ԋu
    public float blinkInterval = 0.1f;
    private bool isMeshRendererEnable = true;

    PlayerManager playerManager;


    private void Start() {
        playerManager = GetComponent<PlayerManager>();
        
    }

    public Vector3 PlayerMove(GameObject gameObject, Vector3 movement, float velocity) {
        if (movement == Vector3.zero) return gameObject.transform.position;
        Vector3 pos = gameObject.transform.position;
        pos.x += movement.x * velocity;
        pos.z += movement.z * velocity;
        return pos;
    }

    public void ShootStart() {
        if (!isShooting) {
            StartCoroutine(Shoot());
        }
    }
    public void SetIsShooting(bool flag) {
        isShooting = flag;
    }
    IEnumerator Shoot() {
        isShooting = true;
        while (isShooting) {
            if (Time.time >= nextFireTime) {
                nextFireTime = Time.time + playerManager.fireRate;
                Instantiate(playerManager.bulletPrefab, playerManager.firePoint.position, playerManager.firePoint.rotation);
            }
            yield return null; // �t���[�����ƂɃ`�F�b�N���s��
        }
    }

    public void HitEnemyBullet(Collision collision) {
        Debug.Log("EnemyBulletHit!!!!!!!!!!!!!!!!!!");
        StartBlinkPlayer(playerManager.GetPlayer());
        DeleteEnemyBullet(collision.gameObject);
    }

    private void DeleteEnemyBullet(GameObject obj) {
        GameManager.Instance.CalcBulletNum(-1);
        Destroy(obj);
    }

    //���G�X�^�[�g
    public void StartBlinkPlayer(GameObject player) {
        StartCoroutine(BlinkPlayer(player));
    }
    IEnumerator BlinkPlayer(GameObject player) {
        float elapsedTime = 0f;
        while (elapsedTime < invincibilityDuration) {
            //��莞�Ԃ��ƂɃ��b�V����enabled�𔽓]
            isMeshRendererEnable = !isMeshRendererEnable;
            ToggleSkinnedMeshRenderers(player, isMeshRendererEnable);
            

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        // �Ō�Ƀ����_���[��\������
        ToggleSkinnedMeshRenderers(player, true); 
    }

    void ToggleSkinnedMeshRenderers(GameObject player, bool enable) {
        // �e�I�u�W�F�N�g�̂��ׂĂ̎q�I�u�W�F�N�g����Skinned Mesh Renderer���擾
        SkinnedMeshRenderer[] skinnedMeshRenderers = player.GetComponentsInChildren<SkinnedMeshRenderer>();

        // �eSkinned Mesh Renderer�̗L��/������ݒ�
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers) {
            skinnedMeshRenderer.enabled = enable;
        }
    }



}
