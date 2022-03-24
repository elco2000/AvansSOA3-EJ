namespace ApplicationAvansSOA3
{
    public class ScrumMaster : IMember
    {
        private string name;
        private string role;

        public string GetName()
        {
            return name;
        }

        public string GetRole()
        {
            return role;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetRole(string role)
        {
            this.role = role;
        }
    }
}
