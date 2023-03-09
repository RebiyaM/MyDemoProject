namespace MyDemoProject
{
    public static class FileManagement
    {
        public static readonly string WorkingDir = Environment.CurrentDirectory;
        public static readonly string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
        public static readonly string SolutionDir = Directory.GetParent(WorkingDir).Parent.Parent.Parent.FullName;
        public static readonly string OnFailureDir = Path.Combine(ProjectDir + "\\OnFailure").Replace('\\', Path.DirectorySeparatorChar);


        public static void CleanOnFailureFolder()
        {
            Directory.CreateDirectory(OnFailureDir);
            DirectoryInfo di = new(OnFailureDir);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }



    }
}
