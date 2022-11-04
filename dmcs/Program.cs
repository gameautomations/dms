using dm;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
var dm = new Dmsoft();

var DM = dm.DM;

var t = typeof(Idmsoft);

var methods = t.GetMethods();

List<M> ms = new List<M>();



foreach (var method in methods)
{
    var parameters = method.GetParameters();
    var parameterDescriptions = string.Join
        (", ", method.GetParameters()
                     .Select(x => x.ParameterType + " " + x.Name)
                     .ToArray());

    var ps = method.GetParameters();



    var r = new List<Pr>();

    foreach (var p in ps)
    {
        r.Add(new Pr { DeafultValue = p.DefaultValue, Type = p.ParameterType.ToString(), Name = p.Name, IsOut = p.IsOut });
    }

    ms.Add(new M { Name = method.Name, ReturnType = method.ReturnType.ToString(), Parameters = r });
}




string jsonString = JsonSerializer.Serialize(ms);

File.WriteAllTextAsync("WriteLines.json", jsonString);

class M
{
    public string Name { set; get; }
    public string ReturnType { set; get; }
    public List<Pr> Parameters { set; get; }
}

class Pr
{
    public string Name { set; get; }
    public dynamic DeafultValue { set; get; }
    public string Type { set; get; }
    public bool IsOut { set; get; }
}