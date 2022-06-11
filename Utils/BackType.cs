namespace BackToBinding.Utils
{
    public static class BackType
    {
        private static Dictionary<string, string> Aliases = new()
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

        public static (string, bool) Resolve(string type)
        {
            type = type.Trim();
            if (Aliases.ContainsKey(type))
            {
                return (Aliases[type], false);
            }
            if (type.Contains('*'))
            {
                type = type.Replace("*", "");
                var result = Resolve(type);
                result.Item1 += "*";
                return result;
            }
            if (type.EndsWith("]"))
            {
                var index = type.IndexOf('[');
                var arrSize = type.Substring(index + 1, type.Length - index - 2);
                type = type.Substring(0, index);

                var result = Resolve(type);
                result.Item1 += "[" + arrSize + "]";
                return result;
            }
            if(type.StartsWith("const"))
            {
                type = type.Replace("const", "");

                var result = Resolve(type);
                result.Item2 = true;
                return result;
            }

            // custom type
            if(!RegisteredCustoms.Contains(type) && !NotResolved.Contains(type))
            {
                NotResolved.Add(type);
            }

            return (type, false);
        }

        public static void Register(string type)
        {
            RegisteredCustoms.Add(type);
            NotResolved.RemoveAll(_ => _ == type);
        }

        public static void AddAlias(string type, string name)
        {
            if (Aliases.ContainsKey(type)) return;
            Aliases[name] = type;
        }

        public static List<string> NotResolvedTypes => NotResolved;
    }
}
