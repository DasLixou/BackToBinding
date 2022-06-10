namespace BackToBinding.Utils
{
    public static class BackType
    {
        private static Dictionary<string, string> BackTypes = new()
        {
            ["unsigned char"] = "u8",

            ["unsigned short"] = "u16",
            ["unsigned short int"] = "u16",

            ["unsigned"] = "u32",
            ["unsigned int"] = "u32",

            ["unsigned long"] = "u64",
            ["unsigned long int"] = "u64",

            ["char"] = "i8",
            ["signed char"] = "i8",

            ["short"] = "i16",
            ["short int"] = "i16",
            ["signed short"] = "i16",
            ["signed short int"] = "i16",

            ["int"] = "i32",
            ["signed"] = "i32",
            ["signed int"] = "i32",

            ["long"] = "i64",
            ["long int"] = "i64",
            ["signed long"] = "i64",
            ["signed long int"] = "i64",

            ["float"] = "f32",

            ["double"] = "f64",

            ["void"] = "none",

            ["bool"] = "bool",
            ["_Bool"] = "bool",
        };

        private static List<string> RegisteredCustoms = new();

        private static List<string> NotResolved = new();

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

            // custom type
            if(!RegisteredCustoms.Contains(type) && !NotResolved.Contains(type))
            {
                NotResolved.Add(type);
            }

            return type;
        }

        public static void Register(string type)
        {
            RegisteredCustoms.Add(type);
            NotResolved.RemoveAll(_ => _ == type);
        }

        public static List<string> NotResolvedTypes => NotResolved;
    }
}
