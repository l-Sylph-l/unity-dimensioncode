using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManager
{

    private static readonly ShaderManager instance = new ShaderManager();

    static ShaderManager()
    {
    }

    private ShaderManager()
    {
    }

    public static ShaderManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void LerpFloatProperty(Material material, string shaderProperty, float endValue)
    {
        LerpFloatProperty(material, shaderProperty, endValue, 1f);
    }

    public void LerpFloatProperty(Material material, string shaderProperty, float endValue, float speed)
    {
        float valueToModify = material.GetFloat(shaderProperty);

        if (valueToModify > endValue)
        {
            valueToModify -= Time.deltaTime * speed;

            if (valueToModify < endValue)
            {
                valueToModify = endValue;
            }
        }
        else if (valueToModify < endValue)
        {
            valueToModify += Time.deltaTime * speed;

            if (valueToModify > endValue)
            {
                valueToModify = endValue;
            }
        }
        material.SetFloat(shaderProperty, valueToModify);
    }
}
