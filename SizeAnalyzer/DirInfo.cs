namespace SizeAnalyzer;

public class dInfo
{
	public List<dInfo> Directories { get; set; } = new List<dInfo>();
	public List<fInfo> Files { get; set; } = new List<fInfo>();
	public string Name { get; set; } = "";
	public long Size { get; set; } = 0;
}

public class fInfo
{
	public string Name { get; set; } = "";
	public long Size { get; set; } = 0;
}