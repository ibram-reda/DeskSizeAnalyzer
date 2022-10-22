using SizeAnalyzer;
using System.Text.Json;

Console.WriteLine("please wait it will take a few minits");
Console.WriteLine("it could show some error message just neglect it");

System.IO.DirectoryInfo dirInfo = new DirectoryInfo(@"C:\");
dInfo dInfo = new dInfo()
{
	Name = "C:"
};
var size = dirInfo.DirSize(dInfo);
dInfo.Size = size ;


while (true)
{
	// kep me in this 
	display(dInfo);
	Console.WriteLine("are you wanna end ? enter [25] yes");
	var choice = getInt(">> ");
	if(choice == 25)
	{
		break;
	}
}


int getInt(string Msg)
{
	Console.WriteLine(Msg);
	int res = 0;
	while(!int.TryParse(Console.ReadLine(), out res))
	{
		Console.WriteLine(Msg);

	};
	return res;
}
void display(dInfo d)
{
	int choice = -1;
	do
	{
		Console.Clear();
		h1($"info for {d.Name}");
		Console.WriteLine($"total size: {d.Size.ToGb()}");
		int count = 0;
		foreach (var i in d.Directories)
		{
			var s = i.Size.ToGb();
			if (s > 2) Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"  {count++} - {i.Name,40} : {s} GB");
			if (s > 2) Console.ForegroundColor = ConsoleColor.White;

		}
		foreach (var i in d.Files)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"  {i.Name,50} : {i.Size.Tomb()} mb");
			Console.ForegroundColor = ConsoleColor.White;

		}

		choice = getInt($" chose number between [0,{count}] or -1 for Go Back \n >> ");
		if (choice != -1)
			display(d.Directories[choice]);

	} while (choice != -1);
	return;
}

void h1(string Msg)
{
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine(Msg);
	Console.WriteLine("".PadLeft(Msg.Length,'-'));
	Console.ForegroundColor = ConsoleColor.White;
}


