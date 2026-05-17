using Versja.Application;

class Program
{
    static void Main(string[] args)
    {
        string projectFile = args[0];

        Incrementer incrementer = new Incrementer();
        incrementer.IncrementVersion(projectFile);
    }
}
