using BackToBinding;
using CommandLine;
using Newtonsoft.Json;
using System.Text;

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
    }
}

/**/