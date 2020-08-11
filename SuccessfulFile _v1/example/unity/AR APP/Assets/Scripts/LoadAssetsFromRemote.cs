using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadAssetsFromRemote : MonoBehaviour
{
    [SerializeField]
    private string _label;

    GameObject siniBro;

    // Start is called before the first frame update
    void Start()
    {
        Get(_label);
    }

    private async void Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;

        Debug.Log(locations);

        foreach(var location in locations)
        {
            siniBro = await Addressables.InstantiateAsync(location).Task;

        }
    }
}
