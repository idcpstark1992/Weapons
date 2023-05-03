using UnityEngine;

public class WeaponSelector : MonoBehaviour 
{
    [SerializeField] private NormalCannonController         NormalCannon;
    [SerializeField] private AntiGravityCannonController    AntiGravityCannon;
    [SerializeField] private CustomCannonController         CustomCannon;
    private ISelectableWeapon[] CannonWeaponArray = new ISelectableWeapon[3];

    private void Start()
    {
        CannonWeaponArray[0] = NormalCannon;
        CannonWeaponArray[1] = AntiGravityCannon;
        CannonWeaponArray[2] = CustomCannon;
        ChangeWeapon(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            Utils.SetCustomWeaponMode(false);
            EventsHolder.USE_GRAVITY?.Invoke(true);
            EventsHolder.ON_CUSTOM_WEAPON_MODE?.Invoke(false);
            ChangeWeapon(0);
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Utils.SetCustomWeaponMode(false);
            EventsHolder.USE_GRAVITY?.Invoke(false);
            EventsHolder.ON_CUSTOM_WEAPON_MODE?.Invoke(false);
            ChangeWeapon(1);
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Utils.SetCustomWeaponMode(true);
            EventsHolder.USE_GRAVITY?.Invoke(true);
            ChangeWeapon(2);
        }
            
    }
    private void ChangeWeapon(int _index)
    {
        EventsHolder.ON_SELECTED_WEAPON?.Invoke();
        CannonWeaponArray[_index].OnSelected();
    }

}
