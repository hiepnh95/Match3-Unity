using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    public override void SetView()
    {
        string prefabname = GetPrefabName();

        if (!string.IsNullOrEmpty(prefabname))
        {
            GameObject prefab = Resources.Load<GameObject>(prefabname);
            if (prefab)
            {
                View = GameObject.Instantiate(prefab).transform;
                SkinItem skinItem = Resources.Load<SkinItem>(Constants.SKIN_ITEM_PATH);
                if (skinItem)
                {
                    if (skinItem.sprites != null && (int)ItemType < skinItem.sprites.Count)
                    {
                        View.GetComponent<SpriteRenderer>().sprite = skinItem.sprites[(int)ItemType];
                    }
                    else
                    {
                        Debug.LogError("Error set SkinItem");
                    }
                }
                else
                {
                    Debug.LogError("SkinItem null");
                }
            }
        }
    }

    protected override string GetPrefabName()
    {
        return Constants.PREFAB_NORMAL_ITEM;
        //string prefabname = string.Empty;
        //switch (ItemType)
        //{
        //    case eNormalType.TYPE_ONE:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_ONE;
        //        break;
        //    case eNormalType.TYPE_TWO:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_TWO;
        //        break;
        //    case eNormalType.TYPE_THREE:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_THREE;
        //        break;
        //    case eNormalType.TYPE_FOUR:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_FOUR;
        //        break;
        //    case eNormalType.TYPE_FIVE:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_FIVE;
        //        break;
        //    case eNormalType.TYPE_SIX:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_SIX;
        //        break;
        //    case eNormalType.TYPE_SEVEN:
        //        prefabname = Constants.PREFAB_NORMAL_TYPE_SEVEN;
        //        break;
        //}

        //return prefabname;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
