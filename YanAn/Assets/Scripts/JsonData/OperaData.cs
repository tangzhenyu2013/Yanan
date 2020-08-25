using System.Collections.Generic;
using System;
[Serializable]
public class OperaData
{

    public string 男主问题;

    public string 选项A;

    public string 选项B;

    public string 选项C;

    public string 选项D;

    public string 正确答案;
}
[Serializable]
public class OperaCollection
{
    public List<OperaData> context;
}

