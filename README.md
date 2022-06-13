# BackToBinding

BackToBinding is a tool for automaticly generating bindings from Header Files in BackLang.

## How do I make a binding?

First, you need your header file. Ok, ready?

Get [Raylib's parser](https://github.com/raysan5/raylib/tree/master/parser) and unzip it into a folder.

In this folder, you should see a file named `raylib_parser.c`

Next step is to compile this c file. When you dont have `gcc` installed (test it with running `gcc --version` in your terminal), look up how to install GCC.

When GCC is finally installed, open a terminal in this unzipped folder and type `gcc raylib_parser.c -o raylib_parser.exe` (when you are on linux or mac, remove the `.exe` in the instruction).

Then run the generated application with the given parameters (in my case ill show how to run it on windows in powershell)
```bash
.\raylib_parser.exe -i <myheader.h> -o <myheaderH.json> -f JSON
```
Here it is important to write `-f JSON` because otherwise BackToBinding can't read it.

Now we have our `.json` file generated and can copy it into our unzipped folder of the newest release from BackToBinding.

Now run
```bash
.\BackToBinding.exe -i <myheaderH.json> --mainName <NameOfTheMainFile> -o dist/
```

This will generate all `.back` files in a folder named `dist`.

From there you can use and play with the bindings howevery you want
