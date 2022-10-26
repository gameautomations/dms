using dm;

DmFactory.Register();

var a = DmFactory.Create();

Console.WriteLine(a.Ver());
DmFactory.Release(a);
DmFactory.Release(a);
DmFactory.Release(a);
DmFactory.Release(a);
var b = DmFactory.Create();

Console.WriteLine(b.Ver());