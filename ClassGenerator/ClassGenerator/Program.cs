// See https://aka.ms/new-console-template for more information
using ClassGenerator;
// Take Input
Console.Write("Entity Name : ");
string EntityName = Console.ReadLine();

var destinationFileDirectory = Environment.CurrentDirectory;
string projectFilesource = destinationFileDirectory + @"\ProjectNameSpace.txt";
StreamReader projectNamereader = new StreamReader(projectFilesource);
string ProjectName = projectNamereader.ReadLine();
Engine program = new Engine(EntityName, ProjectName);
program.Main();
