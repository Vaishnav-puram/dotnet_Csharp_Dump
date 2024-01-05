namespace DelgCal;
public class Program{
    static int square(int val)=>val*val;
    public static void Main(String[] args){
        var cal=new MathSystem();
        MathSystem.CALC c=square;
        Console.WriteLine(cal.Execute(c,5));

    }
}