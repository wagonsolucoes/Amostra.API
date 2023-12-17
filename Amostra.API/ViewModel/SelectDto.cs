namespace Amostra.API.ViewModel
{
    public class SelectDto
    {
        public Guid id { get; set; }
        public string val { get; set; }
        public string txt { get; set; }
        public bool bChecked { get; set; } = false;
        public bool bVisible { get; set; } = true;
    }
}
