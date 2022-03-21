namespace ApplicationAvansSOA3
{
    public class Rapport
    {
        private string name;
        private DateTime rapportDate;
        private DateTime editedDate;
        private ExportFormats exportFormats;

        public Rapport(string name)
        {
            this.name = name;
            this.rapportDate = DateTime.Now;
            this.editedDate = DateTime.Now;
            this.exportFormats = ExportFormats.textfile;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}