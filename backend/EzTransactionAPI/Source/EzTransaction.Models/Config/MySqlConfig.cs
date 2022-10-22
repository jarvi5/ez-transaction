namespace EzTransaction.Models.Config;

public class MySqlConfig
{
    public string Server { get; set; } = string.Empty;

    public string Database { get; set; } = string.Empty;

    public string Uuid { get; set; } = string.Empty;

    public string Pwd { get; set; } = string.Empty;

    public string ConnectionString
    {
        get => $"Server={this.Server};Database={this.Database};Uid={this.Uuid};Pwd={this.Pwd};";
    }
}