namespace SybaseManager.Core.Models
{
    public class ConstraintModel
    {
        public string Name { get; }

        public string ColumnName { get; set; }
        
        public string Source { get; }
    }
}