namespace BackToBinding.Data.Define
{
    internal class MacroDefinition
    {
        public string Name { get; set; }
        public string[] Parameters;
        public string Value { get; set; }

        public MacroDefinition(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            var openBrace = Name.IndexOf('(');
            var prms = Name.Substring(openBrace + 1, Name.Length - openBrace - 2);
            prms = prms.Replace(" ", "");
            Parameters = prms.Split(',');
        }

        public string Resolve(string Call)
        {
            var openBrace = Call.IndexOf('(');
            var closeBrace = Call.IndexOf(')');
            var prms = Call.Substring(openBrace + 1, closeBrace - openBrace - 1);
            prms = prms.Replace(" ", "");
            var prmsList = prms.Split(',');

            var result = Value;
            for (int i = 0; i < prmsList.Length; i++)
            {
                result = result.Replace(Parameters[i], prmsList[i]);
            }
            return result + Call.Substring(closeBrace + 1);
        }
    }
}
