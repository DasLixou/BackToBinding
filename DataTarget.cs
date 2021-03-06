using BackToBinding.Data;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding
{
    internal class DataTarget
    {
        private string _outputDir;

        public List<DataAlias> Aliases { get; set; }
        public List<DataStruct> Structs { get; set; }
        public List<DataEnum> Enums { get; set; }
        public List<DataFunction> Functions { get; set; }
        public List<DataDefine> Defines { get; set; }
        public List<DataCallback> Callbacks { get; set; }

        public void Translate(string outputDir, string mainName)
        {
            Aliases.ForEach(alias => alias.Resolve());
            Defines.ForEach(define => define.Resolve());

            _outputDir = outputDir;

            Structs.ForEach(st => Write(st.Name, st));
            Enums.ForEach(e => Write(e.Name, e));

            CreateMainClass(mainName, Functions, Defines);
        }

        public void CreateMainClass(string name, List<DataFunction> functions, List<DataDefine> defines)
        {
            var content = new StringBuilder();
            content.AutogeneratedInfo();

            content.AppendLine("static class " + name + " {");
            defines.ForEach(d => d.AsText(1, content));
            functions.ForEach(f => f.AsText(1, content));
            content.AppendLine("}");

            File.WriteAllText(Path.Combine(_outputDir, $"{name}.back"), content.ToString());
        }

        public void Write(string name, IData dataObj)
        {
            var content = new StringBuilder();
            content.AutogeneratedInfo();

            dataObj.AsText(0, content);

            File.WriteAllText(Path.Combine(_outputDir, $"{name}.back"), content.ToString());
        }
    }
}
