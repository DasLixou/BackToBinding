namespace BackToBinding.Utils
{
    public static class BackType
    {
        private static Dictionary<string, string> BackTypes = new()
        {
            ["unsigned char"] = "u8",
            ["unsigned int"] = "u32",
            ["char"] = "u8",
            ["int"] = "i32",
            ["float"] = "f32",
            ["void"] = "none",
        };

        public static string Resolve(string type)
        {
            type = type.Trim();
            if (BackTypes.ContainsKey(type))
            {
                return BackTypes[type];
            }
            if (type.Contains('*'))
            {
                type = type.Replace("*", "");
                return Resolve(type) + "*";
            }
            if (type.EndsWith("]"))
            {
                var index = type.IndexOf('[');
                var arrSize = type.Substring(index + 1, type.Length - index - 2);
                type = type.Substring(0, index);
                return Resolve(type) + "[" + arrSize + "]";
            }
            return type;
        }
    }
}
