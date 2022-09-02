namespace HealthCareManagement.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true)]
    public class ModelViewColumnAttribute : Attribute
    {
        public string DiplayName { get; set; }
        public bool ToDisplay { get; set; } = false;

        //public ModelViewColumnAttribute(string diplayName, bool toDisplay = true)
        //{
        //    DiplayName = diplayName;
        //    ToDisplay = toDisplay;
        //}
    }
}
