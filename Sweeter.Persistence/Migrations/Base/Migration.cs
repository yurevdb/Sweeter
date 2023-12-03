namespace Sweeter.Server.Persistence;

public abstract class Migration
{
    #region Must Override Functions

    public abstract void Up();

    public abstract void Down();

    #endregion
}
