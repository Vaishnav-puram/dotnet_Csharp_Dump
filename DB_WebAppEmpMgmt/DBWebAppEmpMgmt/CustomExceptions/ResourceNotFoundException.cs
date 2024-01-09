namespace CustomExceptions;
public class ResourceNotFoundException:Exception{
    public ResourceNotFoundException(string msg):base(msg){}
}