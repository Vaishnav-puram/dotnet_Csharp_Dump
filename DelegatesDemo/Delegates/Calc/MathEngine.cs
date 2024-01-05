namespace Calc;
delegate int Calculator(int x);
public class MathEngine
{
    static int value = 10;
    public static int add(int a)
    {
        value += a;
        return value;
    }
    public static int sub(int a)
    {
        value -= a;
        return value;
    }
    public static int mul(int a)
    {
        value *= a;
        return value;
    }
    public static int div(int a)
    {
        value /= a;
        return value;
    }
    // public static void Main(String[] args)
    // {
    //     Calculator c1 = new Calculator(add);
    //     Calculator c2 = new Calculator(sub);
    //     Calculator c3 = new Calculator(mul);
    //     Calculator c4 = new Calculator(div);
    //     Console.WriteLine(c1(10));
    //     Console.WriteLine(c2(10));
    //     Console.WriteLine(c3(10));
    //     Console.WriteLine(c4(10));
    //     c1=add;
    //     Console.WriteLine(c1(400));
    // }
}