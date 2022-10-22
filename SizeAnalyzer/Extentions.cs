namespace SizeAnalyzer;

public static class Extentions
{
	public static long DirSize(this DirectoryInfo d, dInfo collection)
	{
		long size = 0;
		// Add file sizes.
		try
		{
			FileInfo[] fis = d.GetFiles();
			foreach (FileInfo fi in fis)
			{
				size += fi.Length;
				collection.Files.Add(new fInfo
				{
					Name = fi.Name,
					Size = fi.Length
				});
			}
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex.Message);
			Console.ForegroundColor = ConsoleColor.White;
		}
		try
		{

			// Add subdirectory sizes.
			DirectoryInfo[] dis = d.GetDirectories();

			foreach (DirectoryInfo di in dis)
			{
				dInfo Newdir = new dInfo
				{
					Name = di.Name,
				};
				var calculatedsize = DirSize(di, Newdir);
				size += calculatedsize;
				Newdir.Size = calculatedsize;
				collection.Directories.Add(Newdir);
			}

		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex.Message);
			Console.ForegroundColor = ConsoleColor.White;
		}
		return size;
	}
	public static float ToGb(this long sizeInbyte)
	{
		return sizeInbyte / 1024 / 1024 / 1024;
	}

	public static float Tomb(this long sizeInbyte)
	{
		return sizeInbyte / 1024 / 1024;
	}


}