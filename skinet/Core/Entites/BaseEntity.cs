using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class BaseEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
