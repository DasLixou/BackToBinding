﻿using BackToBinding;
using BackToBinding.Utils;
using CommandLine;
using Newtonsoft.Json;
using System.Text;

public static class Program
{
    internal static DataTarget target;

    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandContext>(args)
              .WithParsed(context => {
                  Translate(context);
              });
    }

    internal static void Translate(CommandContext ctx)
    {
        target = JsonConvert.DeserializeObject<DataTarget>(File.ReadAllText(ctx.InputFilename));

        Directory.CreateDirectory(ctx.OutputDirectory);

        target.Translate(ctx.OutputDirectory, ctx.MainName);

        foreach (var type in BackType.NotResolvedTypes)
        {
            Console.WriteLine($"[WARNING] Couldn't find type {type} - Creating empty struct '{type}.back'..");
            StringBuilder content = new();
            content.AutogeneratedInfo();
            content.AppendLine("struct " + type + " {");
            content.AppendLine("\t// Created an empty struct cause type '" + type + "' want't found.");
            content.AppendLine("}");
            File.WriteAllText(Path.Combine(ctx.OutputDirectory, $"{type}.back"), content.ToString());
        }
    }
}

/**/