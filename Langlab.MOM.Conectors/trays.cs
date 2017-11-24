using Langlab.Core.MOM;

namespace Langlab.MOM.Conectors
{
    public class OutputTray : BaseMomTray, IOutputTray
    {
        public OutputTray(IMomConfiguration configuration) : base(configuration, "ouputtray") { }
    }

    public class CleanerTray : BaseMomTray, ICleanerTray
    {
        public CleanerTray(IMomConfiguration configuration) : base(configuration, "cleanertray") { }
    }
}
