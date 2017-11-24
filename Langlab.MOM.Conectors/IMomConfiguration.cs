namespace Langlab.MOM.Conectors
{
    public interface IMomConfiguration
    {
        string ConnectionString { get; }
        uint NumberOfRetries { get; }
        uint MSBetweenRetries { get; }
    }

    public class MomConfiguration: IMomConfiguration
    {
        public string ConnectionString => "Endpoint=sb://langlab.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9cUEenm6lgxtPBDs6cABY03q6K71+DOAHJTIxdp+qdQ=";
        public uint NumberOfRetries => 3;
        public uint MSBetweenRetries => 300;
    }
}
