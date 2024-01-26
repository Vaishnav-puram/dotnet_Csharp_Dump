using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("inside main()");
        DirectoryInfo curr = new DirectoryInfo(".");
        DirectoryInfo myDir = new DirectoryInfo(@"C:\\Users\Vaishnav Puram");
        Console.WriteLine(curr.FullName);
        Console.WriteLine(myDir.Name);
        Console.WriteLine(myDir.Parent);
        Console.WriteLine(myDir.CreationTime);
        DirectoryInfo directory = new DirectoryInfo("C:\\Users\\Vaishnav Puram\\Desktop\\csharpFile");
        directory.Create();
        string[] customers =
        {
            "Jone Doe",
            "Amar",
            "Karan"
        };
        string textFile = @"C:\Users\Vaishnav Puram\Desktop\csharpFile\customers.txt";
        File.WriteAllLines(textFile,customers);
        foreach (string customer in File.ReadAllLines(textFile))
        {
            Console.WriteLine(customer);
        }
        FileInfo[] textFiles=directory.GetFiles("*.txt",searchOption:SearchOption.AllDirectories);
        Console.WriteLine(textFiles.Length);
        foreach(FileInfo file in textFiles)
        {
            Console.WriteLine(file.Name);
        }
        string textFile2 = @"C:\Users\Vaishnav Puram\Desktop\csharpFile\customers2.txt";
        FileStream fs = File.Open(textFile2,FileMode.Create);
        string data = "This is written from program.cs";
        byte[] bytes=Encoding.Default.GetBytes(data);
        fs.Write(bytes, 0, bytes.Length);
        fs.Position = 0;
        byte[] fileByteArray = new byte[bytes.Length];
        for(int i = 0; i < fileByteArray.Length; i++)
        {
            fileByteArray[i]=(byte)fs.ReadByte();
        }
        Console.WriteLine(Encoding.Default.GetString(fileByteArray));
        fs.Close();
        string textFile3 = @"C:\Users\Vaishnav Puram\Desktop\csharpFile\streams.txt";
        StreamWriter sw = new StreamWriter(textFile3);
        sw.WriteLine("This is writtern from program.cs");
        sw.WriteLine("new Line");
        sw.Close();
        StreamReader sr=new StreamReader(textFile3);
        Console.WriteLine("Peek : {0} ", Convert.ToChar(sr.Peek()));
        Console.WriteLine("First Line : {0} ", sr.ReadLine());
        Console.WriteLine("Everything : {0} ",sr.ReadToEnd());
        sr.Close();
        string textFile4 = @"C:\Users\Vaishnav Puram\Desktop\csharpFile\binaryData.txt";
        FileInfo binFile=new FileInfo(textFile4);
        BinaryWriter binaryWriter = new BinaryWriter(binFile.OpenWrite());
        string name = "vaishnav";
        int age = 23;
        string hobbies = "movies,TV Shows";
        binaryWriter.Write(name);
        binaryWriter.Write(age);
        binaryWriter.Write(hobbies);
        binaryWriter.Close();
        BinaryReader binaryReader = new BinaryReader(binFile.OpenRead());
        Console.WriteLine(binaryReader.ReadString());
        Console.WriteLine(binaryReader.ReadInt32());
        Console.WriteLine(binaryReader.ReadString());
        binaryReader.Close();
    }
    
}
