using System.Reflection;
using Classes;

Example ex=new Example();
ex.x=12;

Type t=ex.GetType();
MethodInfo? exFun=t.GetMethod("SayStaticHello");
Console.WriteLine(exFun);
exFun?.Invoke(null,null);

MethodInfo? exFunInstance=t.GetMethod("AddInstance");
Console.WriteLine(exFunInstance);
exFunInstance?.Invoke(ex,null);

MethodInfo? exFunWithParams=t.GetMethod("SayHelloWithParams");
Console.WriteLine(exFunWithParams);
exFunWithParams?.Invoke(ex,new Object[]{"Vaishnav"});

Type t1=typeof(MyClass);
FieldInfo[] fields=t1.GetFields(BindingFlags.Public|BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Static);
foreach(FieldInfo f in fields){
    Console.WriteLine($"{f.Name} (of type {f.FieldType}) : "+$"private ? {f.IsPrivate} / static ? {f.IsStatic}");
}

IEnumerable<Type> classList=from c in Assembly.GetExecutingAssembly().GetTypes() where c.IsClass select c ;
foreach(Type T in classList){
    Console.WriteLine(T.Name);
}
