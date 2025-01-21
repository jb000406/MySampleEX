using UnityEngine;

namespace MySampleEx
{
    public class UIManager : MonoBehaviour
    {
        #region Variables
        public ItemDataBase database;

        public DynamicInventoryUI playerInventoryUI;
        public StaticInventoryUI playerEquipmentUI;
        public PlayerStatsUI playerStatsUI;
        public DialogUI dialogUI;

        public int itemId = 0;
        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Toggle(playerInventoryUI.gameObject);
                //커서
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                Toggle(playerEquipmentUI.gameObject);

                //커서
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Toggle(playerStatsUI.gameObject);

                //커서
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                AddNewItem();
            }
        }

        public void Toggle(GameObject go)
        {
            go.SetActive(!go.activeSelf);
        }

        public void AddNewItem()
        {
            ItemObject itemObject = database.itemObjects[itemId];
            Item newItem = itemObject.CreateItem();

            playerInventoryUI.inventoryObject.AddItem(newItem, 1);
        }

        public void OpenDialogUI(int dialogIndex)
        {
            Toggle(dialogUI.gameObject);
            dialogUI.StartDialog(dialogIndex);
        }

        public void CloseDialogUI()
        {
            Toggle(dialogUI.gameObject);
        }
    }
}