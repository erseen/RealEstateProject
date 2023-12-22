using Emlak.Api.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emlak.Api.Entity
{
    public class WorkPlace:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
