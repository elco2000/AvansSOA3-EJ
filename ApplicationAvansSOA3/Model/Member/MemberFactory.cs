namespace ApplicationAvansSOA3
{
    public class MemberFactory
    {
        public IMember GetMember(string type)
        {
            switch (type.ToUpper())
            {
                case "DEVELOPER":
                    return new Developer();
                case "SCRUM MASTER":
                    return new ScrumMaster();
                case "PRODUCT OWNER":
                    return new ProductOwner();
            }
            return null;
        }
    }
}