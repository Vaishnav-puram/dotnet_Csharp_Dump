namespace Classes;
public class Example{
    public int x;
    public static void SayStaticHello(){
        Console.WriteLine("Hello world from static method...");
    }
    public void SayHelloWithParams(string name){
        Console.WriteLine($"Hello {name}");
    }
    public void AddInstance(){
        Console.WriteLine($"X : {x}");
    }
}