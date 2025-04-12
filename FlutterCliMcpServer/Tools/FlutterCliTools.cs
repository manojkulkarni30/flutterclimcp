using System.ComponentModel;
using System.Diagnostics;
using ModelContextProtocol.Server;

namespace FlutterCliMcpServer.Tools;

[McpServerToolType]
public class FlutterCliTools
{
    public static string CreateFlutterProjectForSpecifiedPLatforms([Description("Project Name")] string projectName,
        [Description("Platforms")] string platforms)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        var projectPath = Path.Combine(path, projectName);
        try
        {
            // Step 1: Check if the project already exists
            if (Directory.Exists(projectPath))
            {
                return "Project already exists.";
            }

            // Step 2: Create the Flutter project
            string createCommand = $"flutter create {projectPath} --platforms {platforms}";

            using (Process projectCreateCommand = new Process())
            {
                projectCreateCommand.StartInfo.FileName = "/bin/bash";
                projectCreateCommand.StartInfo.Arguments = $"-c \"{createCommand}\"";
                projectCreateCommand.StartInfo.RedirectStandardOutput = true;
                projectCreateCommand.StartInfo.CreateNoWindow = true;
                projectCreateCommand.StartInfo.UseShellExecute = false;

                projectCreateCommand.Start();
                projectCreateCommand.WaitForExit();

                if (projectCreateCommand.ExitCode != 0)
                {
                    throw new Exception("Flutter project creation failed.");
                }
            }

            // Step 3: Open the project in VS Code
            string openCommand = "code .";
            using (Process openProcess = new Process())
            {
                openProcess.StartInfo.FileName = "/bin/bash";
                openProcess.StartInfo.Arguments = $"-c \"{openCommand}\"";
                openProcess.StartInfo.RedirectStandardOutput = true;
                openProcess.StartInfo.CreateNoWindow = true;
                openProcess.StartInfo.UseShellExecute = false;
                openProcess.StartInfo.WorkingDirectory = projectPath;

                openProcess.Start();
                openProcess.WaitForExit();

                if (openProcess.ExitCode != 0)
                {
                    return "Project created but failed to open project in VS Code.";
                }
            }
            return "Project created and opened in VS Code.";
        }
        catch (Exception ex)
        {
            return $"Project Creation Failed: {ex.Message}";
        }
    }

    [McpServerTool, Description("Create flutter project with specified project name for all platforms")]
    public static string CreateFlutterProject([Description("Project Name")] string projectName)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        var projectPath = Path.Combine(path, projectName);
        try
        {
            // Step 1: Check if the project already exists
            if (Directory.Exists(projectPath))
            {
                return "Project already exists.";
            }

            // Step 2: Create the Flutter project
            string createCommand = $"flutter create {projectPath}";

            Console.WriteLine($"Creating Flutter project at {projectPath}");
            using (Process projectCreateCommand = new Process())
            {
                projectCreateCommand.StartInfo.FileName = "/bin/bash";
                projectCreateCommand.StartInfo.Arguments = $"-c \"{createCommand}\"";
                projectCreateCommand.StartInfo.RedirectStandardOutput = true;
                projectCreateCommand.StartInfo.CreateNoWindow = true;
                projectCreateCommand.StartInfo.UseShellExecute = false;

                projectCreateCommand.Start();
                projectCreateCommand.WaitForExit();

                if (projectCreateCommand.ExitCode != 0)
                {
                    throw new Exception("Flutter project creation failed.");
                }
            }

            // Step 3: Open the project in VS Code
            string openCommand = "code .";
            using (Process openProcess = new Process())
            {
                openProcess.StartInfo.FileName = "/bin/bash";
                openProcess.StartInfo.Arguments = $"-c \"{openCommand}\"";
                openProcess.StartInfo.RedirectStandardOutput = true;
                openProcess.StartInfo.CreateNoWindow = true;
                openProcess.StartInfo.UseShellExecute = false;
                openProcess.StartInfo.WorkingDirectory = projectPath;

                openProcess.Start();
                openProcess.WaitForExit();

                if (openProcess.ExitCode != 0)
                {
                    return "Project created but failed to open project in VS Code.";
                }
            }
            return "Project created and opened in VS Code.";
        }
        catch (Exception ex)
        {
            return $"Project Creation Failed: {ex.Message}";
        }
    }
}
