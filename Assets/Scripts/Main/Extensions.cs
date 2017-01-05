using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static string FilterFileExtension(this string s, string ext)
    {
#if !MOBILE_INPUT
                s = s.Substring(s.LastIndexOf("/") + 1 );
#else
        s = s.Substring(s.IndexOf("\\") + 1);
#endif
        s = s.Substring(0, s.Length - ext.Length);
        return s;
    }
    public static void ActivateFirstChild(this GameObject obj)
    {
        obj.transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 1; i < obj.transform.childCount; i++)
        {
            var child = obj.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }
    //Disables parent with tag parameter, enables uncle object name after the '>'
    public static void SwitchPage(this GameObject obj, string tag)
    {
        var par = obj.FindParentWithTag(tag);
        var uncle = par.FindSiblingWithName(obj.name.Split('>')[1]);
        par.InvertActivity();
        uncle.InvertActivity();
    }
    //Inverts active state of the GameObject. e.g. if active, set inactive.
    public static void InvertActivity(this GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
    //Finds the parent of the gameobject which has the same tag as the string parameter
    public static GameObject FindParentWithTag(this GameObject obj, string tag)
    {
        var par = obj.transform.parent;
        do if (par.tag == tag) return par.gameObject;
        while ((par = par.parent) != null);
        return null;
    }
    //Finds the sibling of the gameobject which has the same name as the string parameter
    public static GameObject FindSiblingWithName(this GameObject obj, string name)
    {
        var par = obj.transform.parent;
        for (int i = 0; i < par.childCount; i++)
        {
            var child = par.GetChild(i);
            if (child.name == name)
                return child.gameObject;
        }
        return null;
    }
    //Loads the scene with the same name of the object name after the underscore '_'
    public static void SwitchScene(this GameObject obj)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(obj.name.Split('_')[1]);
    }
}
