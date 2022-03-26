namespace ApplicationAvansSOA3
{
    public class Rapport
    {
        private readonly string name;
        private readonly DateTime rapportDate;
        private readonly DateTime editedDate;
        private readonly ExportFormats exportFormats;
        private readonly Sprint sprint;

        public Rapport(string name, Sprint sprint)
        {
            this.name = name;
            rapportDate = DateTime.Now;
            editedDate = DateTime.Now;
            exportFormats = ExportFormats.textfile;
            this.sprint = sprint;
        }

        public string GetName()
        {
            return name;
        }
    }
}