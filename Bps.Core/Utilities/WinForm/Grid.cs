namespace Bps.Core.Utilities.WinForm
{
    public class Grid
    {
        public int Id { get; set; }
        public string Tipi { get; set; }
        public string View { get; set; }
        public Grid(int _id, string _tipi)
        {
            Id = _id;
            Tipi = _tipi;
        }
        public Grid(int _id, string _tipi, string _view)
        {
            Id = _id;
            Tipi = _tipi;
            View = _view;
        }
    }
}