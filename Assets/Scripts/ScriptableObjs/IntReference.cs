﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntReference
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntVariable Variable;

    public IntReference()
    { }

    public IntReference(int value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    // Typecast implícito de IntReference para int. Se tentar ser lido como int, entregará o Value
    public static implicit operator int(IntReference reference)
    {
        return reference.Value;
    }
}