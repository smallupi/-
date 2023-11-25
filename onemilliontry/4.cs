namespace onemilliontry
{
    public class TextConfigurationProvider:ConfigurationProvider
    {
        public string FilePath{get;set;}
        public TextConfigurationProvider(string FileName)
        {
            FilePath = FileName;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            using (StreamReader textReader = new StreamReader(FilePath))
            {
                string? line;
                while((line =textReader.ReadLine()) !=null)
                {
                    string key = line.Trim();
                    string? value = textReader.ReadLine()??"";
                    data.Add(key,value);
                }
            }
        }
    }
    // public static class TExtConfigurationExtensions
    // {
    //     public static IConfigurationBuilder AddTextFile(
    //         this IConfigurationBuilder builder, string path){
    //             if(builder==null)throw new ArgumentNullException(nameof(builder));
    //             else if(string.IsNullOrEmpty(path))throw new ArgumentException("path not found");

    //             var source = new TextConfigurationSource(path);
    //             builder.Add(source);
    //             return builder;
    //         }
    // }

    // internal class TextConfigurationSource : IConfigurationSource
    // {

    // }
}