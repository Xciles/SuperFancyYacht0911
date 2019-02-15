using System;
using System.ComponentModel.DataAnnotations;

namespace SuperAwesome.Api.Domain
{
    public abstract class BaseDomain<TId>
    {
        [Key]
        public TId Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}