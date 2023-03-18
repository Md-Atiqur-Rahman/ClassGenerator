using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator
{
    public class Engine
    {
        private string EntityName;
        private string ProjectName;
        public Engine(string entityName, string projectName)
        {
            EntityName = entityName;
            ProjectName = projectName;
        }

        public void GenerateFile(string sourceFile, string destinationFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(sourceFile))
                {
                    using (StreamWriter writer = new StreamWriter(destinationFile))
                    {
                        while (reader.Peek() >= 0)
                        {
                            string line = reader.ReadLine();
                            if (line.Contains("{{EntityName}}"))
                                line = line.Replace("{{EntityName}}", EntityName);
                            if (line.Contains("{{CreationDate}}"))
                                line = line.Replace("{{CreationDate}}", DateTime.Now.ToString("yyyyMMddHHmmss"));
                            if (line.Contains("{{ProjectName}}"))
                                line = line.Replace("{{ProjectName}}", ProjectName);

                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Exception Message: {0}", ex.Message);
            }
        }
        public void Main()
        {
            try
            {
                string destinationFileDirectory = Environment.CurrentDirectory;
                string destinationFilesource = destinationFileDirectory + @"\destinationLocation.txt";
                StreamReader reader = new StreamReader(destinationFilesource);
                string destinationWorkingDir = reader.ReadLine();



                string currentFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string workingDirectory = Path.GetDirectoryName(currentFilePath);
                string sourceFile = "";
                string destinationFile = "";


                
            
                //// Take Input
                //Console.Write("Project Name : ");
                //string ProjectName = Console.ReadLine();
                //Console.Write("Entity Name : ");
                //string EntityName = Console.ReadLine();

                destinationFile += EntityName + ".cs";
                Engine program = new Engine(EntityName, ProjectName);
                // Create Class
                sourceFile = workingDirectory + @"\SampleClass.txt";
                destinationFile = destinationWorkingDir;
                string className = EntityName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".cs";
                destinationFile += className;
                program.GenerateFile(sourceFile, destinationFile);
                Console.WriteLine("********Success********");
                Console.Write("Successfully {0} is created on {1} ", className, destinationWorkingDir);
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Exception Message: {0}", ex.Message);
            }


        }
    }
}
