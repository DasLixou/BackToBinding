namespace BackToBinding.Data
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
            if(BackTypes.ContainsKey(type))
            {
                return BackTypes[type];
            }
            if(type.Contains('*'))
            {
                var without = type.Replace("*", "");
                return Resolve(without) + "*";
            }
            return type;
        }
    }
}
