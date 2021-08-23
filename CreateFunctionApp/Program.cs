using System;
using System.ComponentModel.DataAnnotations;

using Sharprompt;

namespace CreateFunctionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectName = Prompt.Input<string>("Project name");
            var workerRuntime = Prompt.Select<WorkerRuntime>("Worker runtime");

            switch (workerRuntime)
            {
                case WorkerRuntime.Dotnet:
                    GenerateDotnet(projectName);
                    break;
                case WorkerRuntime.DotnetIsolated:
                    GenerateDotnetIsolated(projectName);
                    break;
                case WorkerRuntime.Node:
                    GenerateNode(projectName);
                    break;
                case WorkerRuntime.Python:
                    break;
                case WorkerRuntime.PowerShell:
                    break;
                case WorkerRuntime.Custom:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        static void GenerateDotnet(string projectName)
        {
            var dotnetVersion = Prompt.Select<DotnetVersion>(".NET runtime version");

            Console.WriteLine($"The project \"{projectName}\" was created successfully with {dotnetVersion}");
        }

        static void GenerateDotnetIsolated(string projectName)
        {
            var dotnetIsolatedVersion = Prompt.Select<DotnetIsolatedVersion>(".NET runtime version");

            Console.WriteLine($"The project \"{projectName}\" was created successfully with {dotnetIsolatedVersion}");
        }

        static void GenerateNode(string projectName)
        {
            var nodeVersion = Prompt.Select<NodeVersion>("Node.js version");
            var nodeLanguage = Prompt.Select<NodeLanguage>("Programming language");

            Console.WriteLine($"The project \"{projectName}\" was created successfully with {nodeVersion}, {nodeLanguage}");
        }
    }

    public enum WorkerRuntime
    {
        [Display(Name = ".NET (In process)")]
        Dotnet,
        [Display(Name = ".NET (Isolated process)")]
        DotnetIsolated,
        [Display(Name = "Node.js")]
        Node,
        [Display(Name = "Python")]
        Python,
        [Display(Name = "PowerShell")]
        PowerShell,
        [Display(Name = "Custom Handler")]
        Custom
    }

    public enum DotnetVersion
    {
        [Display(Name = ".NET Core 3.1 (LTS)")]
        DotnetCore31,
        [Display(Name = ".NET 6 (Preview)")]
        Dotnet6
    }

    public enum DotnetIsolatedVersion
    {
        [Display(Name = ".NET 5 (Current)")]
        Dotnet5,
        [Display(Name = ".NET 6 (Preview)")]
        Dotnet6
    }

    public enum NodeVersion
    {
        [Display(Name = "12 LTS")]
        Node12,
        [Display(Name = "14 LTS")]
        Node14,
        [Display(Name = "16 (Preview)")]
        Node16
    }

    public enum NodeLanguage
    {
        JavaScript,
        TypeScript
    }
}
