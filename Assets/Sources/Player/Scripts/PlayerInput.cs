using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
  [SerializeField] private Gun _gun;

  private PlayerMovement _playerMovement;

  private void Awake() => _playerMovement = GetComponent<PlayerMovement>();

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) && _gun.ReadyToShoot == true)
      HitRay();
  }

  private void HitRay()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
      _playerMovement.Rotate(hit.transform,hit.point);
  }
}