namespace Lpz1
{
    public interface IStorable
    {

        string FilePath { get; }


        void Save(string path);
    }
}