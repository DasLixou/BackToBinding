using BackToBinding;
using BackToBinding.Utils;
using CommandLine;
using Newtonsoft.Json;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandContext>(args)
              .WithParsed(context => {
                  Translate(context);
              });
    }

    internal static void Translate(CommandContext ctx)
    {
        var target = JsonConvert.DeserializeObject<DataTarget>(File.ReadAllText(ctx.InputFilename));

        Directory.CreateDirectory(ctx.OutputDirectory);

        target.Translate(ctx.OutputDirectory);

        foreach (var type in BackType.NotResolvedTypes)
        {
            Console.WriteLine($"[WARNING] Couldn't find type {type} - Creating empty struct..");
            // TODO: Resolving Macros for types and create empty structs
        }
    }
}

/**/