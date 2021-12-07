public static class Inputs {
    private const string path = "Inputs\\";
    private const string ext = ".txt";

    public static IEnumerable<T> Read<T>(string name) {
        var lines = File.ReadAllLines(path + name + ext, System.Text.Encoding.UTF8);
        return lines.Select(x => (T)System.Convert.ChangeType(x, typeof(T)));
    }

    public static IEnumerable<T> ReadCsv<T>(string name) {
        return Read<string>(name).First().Split(',').Select(x => (T)System.Convert.ChangeType(x, typeof(T)));
    }
}