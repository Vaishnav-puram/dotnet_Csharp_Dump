namespace DelgCal;
public class MathSystem{
    public delegate int CALC(int value);
    public int Execute(CALC calculate,int value){
        return calculate(value);
    }
}