using BackToBinding;
using BackToBinding.Data;
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

        StringBuilder builder = new StringBuilder();

        target.AsText(0, builder);

        File.WriteAllText($"{ctx.OutputDirectory}/{ctx.MainName}.back", builder.ToString());
    }
}

/**/