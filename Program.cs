using BackToBinding.Data;
using System.Text;

StringBuilder builder = new StringBuilder();

// debug
var data = new DataStruct();
data.Name = "Hello";
var field = new TypeField();
field.Name = "a";
data.Fields.Add(field);
// end

data.AsText(0, builder);

File.WriteAllText("dist/Raylib.back", builder.ToString());