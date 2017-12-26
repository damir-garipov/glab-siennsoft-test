namespace Glabsiennsoft.Contracts.Common.MIgrations
{
    public interface IMigrator
    {
        void Up();
        void Down(string name);
    }
}